USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyQuestionChoices'))
	DROP PROCEDURE app.spGetApplicationSurveyQuestionChoices
GO

CREATE PROCEDURE app.spGetApplicationSurveyQuestionChoices
	@AQuestionID UNIQUEIDENTIFIER,
	@AQuestionIDs NVARCHAR(MAX),
	@AName NVARCHAR(200),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@QuestionID UNIQUEIDENTIFIER = @AQuestionID,
		@QuestionIDs NVARCHAR(MAX) = LTRIM(RTRIM(@AQuestionIDs)),
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS (
		SELECT 
			Count(*) OVER() Total,
			surchoice.ID,
			surchoice.QuestionID,
			surchoice.[Name]
		FROM app.ApplicationSurveyQuestionChoice AS surchoice
			INNER JOIN app.ApplicationSurveyQuestion surquestion ON surquestion.ID = surchoice.QuestionID
			LEFT JOIN OPENJSON(@QuestionIDs) QuestionIDs ON QuestionIDs.value = surchoice.QuestionID
		WHERE surchoice.RemoverPositionID IS NULL
			AND (@QuestionID IS NULL OR surchoice.QuestionID = @QuestionID)
			AND (@QuestionIDs IS NULL OR QuestionIDs.value = surchoice.QuestionID)
			AND (@Name IS NULL OR surchoice.[Name] LIKE CONCAT('%', @Name, '%'))
	)

	SELECT * FROM MainSelect		 
	ORDER BY QuestionID desc
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END