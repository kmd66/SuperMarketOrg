USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetCommandsForEnum_'))
	DROP PROCEDURE pbl.spGetCommandsForEnum_
GO

CREATE PROCEDURE pbl.spGetCommandsForEnum_
	@AApplicationID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID
			
	select 
		cmd.ID
		, cmd.[Name]
	FROM org.Command cmd
	WHERE cmd.ApplicationID = @ApplicationID

	RETURN @@ROWCOUNT
END