USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyQuestions'))
	DROP PROCEDURE app.spGetApplicationSurveyQuestions
GO

CREATE PROCEDURE app.spGetApplicationSurveyQuestions
	@AGroupID UNIQUEIDENTIFIER,
	@AGroupIDs NVARCHAR(MAX),
	@AName NVARCHAR(1000),
	@AType TINYINT,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@GroupID UNIQUEIDENTIFIER = @AGroupID,
		@GroupIDs NVARCHAR(MAX) = LTRIM(RTRIM(@AGroupIDs)),
		@Name NVARCHAR(1000) = LTRIM(RTRIM(@AName)),
		@Type TINYINT = COALESCE(@AType, 0),
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
			question.ID,
			question.GroupID,
			surveyGroup.[Name] as GroupName,
			question.[Type],
			question.[Name],
			surveyGroup.ApplicationSurveyID,
			survey.[Name] as ApplicationSurveyName
		FROM app.ApplicationSurveyQuestion as question
			INNER JOIN app.[ApplicationSurveyGroup] as surveyGroup on surveyGroup.ID = question.GroupID
			INNER JOIN app.[ApplicationSurvey] as survey on survey.ID = surveyGroup.ApplicationSurveyID
			LEFT JOIN OPENJSON(@GroupIDs) GroupIDs ON GroupIDs.value = question.GroupID
		WHERE question.RemoverPositionID is null
			AND (@GroupID IS NULL OR question.GroupID = @GroupID)
			AND (@GroupIDs IS NULL OR GroupIDs.value = question.GroupID)
			AND (@Name IS NULL OR question.[Name] LIKE CONCAT('%', @Name, '%'))
			AND (@Type < 1 OR question.[Type] = @Type)
	)

	SELECT * FROM MainSelect		 
	ORDER BY [ID] desc
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END