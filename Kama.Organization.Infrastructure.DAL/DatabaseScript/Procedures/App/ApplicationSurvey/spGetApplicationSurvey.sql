USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurvey'))
	DROP PROCEDURE app.spGetApplicationSurvey
GO

CREATE PROCEDURE app.spGetApplicationSurvey
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
		survey.ID,
		survey.ApplicationID,
		survey.[Name],
		survey.[Enable],
		survey.CreationDate
	FROM app.[ApplicationSurvey] as survey
	WHERE survey.ID = @ID

	RETURN @@ROWCOUNT
END