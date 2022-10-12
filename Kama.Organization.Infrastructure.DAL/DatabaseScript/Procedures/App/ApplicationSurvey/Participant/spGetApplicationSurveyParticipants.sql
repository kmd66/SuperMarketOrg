USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyParticipants'))
	DROP PROCEDURE app.spGetApplicationSurveyParticipants
GO

CREATE PROCEDURE app.spGetApplicationSurveyParticipants
	@ASurveyID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@SurveyID UNIQUEIDENTIFIER = @ASurveyID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
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
			surpart.ID,
			surpart.SurveyID,
			surpart.UserID,
			us.FirstName + ' ' + us.LastName UserFullName,
			surpart.[Date],
			sur.[Name] SurveyName
		FROM app.ApplicationSurveyParticipant  surpart
			INNER JOIN app.ApplicationSurveyAnswer suranswer ON suranswer.ParticipantID = surpart.ID
			INNER JOIN app.ApplicationSurveyQuestion surquestion ON surquestion.ID = suranswer.QuestionID
			INNER JOIN app.ApplicationSurveyGroup surgroup ON surgroup.ID = surquestion.GroupID
			INNER JOIN app.ApplicationSurvey sur ON sur.ID = surgroup.ApplicationSurveyID
			LEFT JOIN org.[User] us  ON us.ID = surpart.UserID
		WHERE surpart.SurveyID = @SurveyID
			AND surpart.UserID IS NULL
			--AND (sur.[Name] IS NULL OR sur.[Name] LIKE CONCAT('%', sur.[Name], '%'))
	)

	SELECT * FROM MainSelect		 
	ORDER BY SurveyID desc
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END