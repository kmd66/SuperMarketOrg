USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetClients'))
	DROP PROCEDURE org.spGetClients
GO

CREATE PROCEDURE org.spGetClients
	  @AApplicationID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID
	
	SELECT 
		Client.ID,
		Client.ApplicationID,
		app.[Name] ApplicationName,
		app.[Code] ApplicationCode,
		app.[Enabled] ApplicationEnabled,
		Client.[Name],
		Client.[Secret],
		Client.[Type],
		Client.[Enabled],
		Client.RefreshTokenLifeTime,
		Client.AllowedOrigin
	FROM org.Client
	INNER JOIN org.[Application] app ON app.ID = client.ApplicationID
	WHERE  ApplicationID = @ApplicationID
	ORDER BY [Name] ASC
	
END
