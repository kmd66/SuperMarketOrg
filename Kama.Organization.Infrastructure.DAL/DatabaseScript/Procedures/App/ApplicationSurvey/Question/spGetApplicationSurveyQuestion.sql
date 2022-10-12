USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyQuestion'))
	DROP PROCEDURE app.spGetApplicationSurveyQuestion
GO

CREATE PROCEDURE app.spGetApplicationSurveyQuestion
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT
		question.ID,
		question.GroupID,
		surveyGroup.[Name] as GroupName,
		question.[Type],
		surveyGroup.ApplicationSurveyID,
		question.[Name],
		survey.[Name] as ApplicationSurveyName
	FROM app.ApplicationSurveyQuestion as question
		INNER JOIN app.[ApplicationSurveyGroup] as surveyGroup on surveyGroup.ID = question.GroupID
		INNER JOIN app.[ApplicationSurvey] as survey on survey.ID = surveyGroup.ApplicationSurveyID
	WHERE question.ID = @ID

	RETURN @@ROWCOUNT
END