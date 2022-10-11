USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyGroup'))
	DROP PROCEDURE app.spGetApplicationSurveyGroup
GO

CREATE PROCEDURE app.spGetApplicationSurveyGroup
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT
		surveyGroup.ID,
		surveyGroup.[Name],
		surveyGroup.ApplicationSurveyID
	FROM app.[ApplicationSurveyGroup] as surveyGroup
	WHERE surveyGroup.ID = @ID
END