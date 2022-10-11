USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyGroups'))
	DROP PROCEDURE app.spGetApplicationSurveyGroups
GO

CREATE PROCEDURE app.spGetApplicationSurveyGroups
	@AApplicationSurveyID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@AShowRemov BIT,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@ApplicationSurveyID UNIQUEIDENTIFIER = @AApplicationSurveyID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@ShowRemov BIT = @AShowRemov,
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
			surveyGroup.ID,
			surveyGroup.[Name],
			surveyGroup.RemoverPositionID,
			surveyGroup.ApplicationSurveyID,
			survey.[Name] as ApplicationSurveyName
		FROM app.[ApplicationSurveyGroup] as surveyGroup
			INNER JOIN app.[ApplicationSurvey] as survey on survey.ID = surveyGroup.ApplicationSurveyID
		WHERE survey.RemoverPositionID IS NULL
			AND (@ShowRemov = 1 OR surveyGroup.RemoverPositionID IS NULL)
			AND (@ApplicationID IS NULL OR survey.ApplicationID = @ApplicationID)
			AND (@ApplicationSurveyID IS NULL OR surveyGroup.ApplicationSurveyID = @ApplicationSurveyID)
			AND (@Name IS NULL OR survey.[Name] LIKE CONCAT('%', @Name, '%'))
	)

	SELECT * FROM MainSelect		 
	ORDER BY [ID] desc
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END