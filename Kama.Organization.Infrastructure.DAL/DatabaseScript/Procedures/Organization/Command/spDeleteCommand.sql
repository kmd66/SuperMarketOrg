USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spDeleteCommand'))
	DROP PROCEDURE org.spDeleteCommand
GO

CREATE PROCEDURE org.spDeleteCommand
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Node HIERARCHYID

	SET @Node = (SELECT [Node] FROM org.Command WHERE ID = @ID)  

	BEGIN TRY
		BEGIN TRAN

			DELETE FROM org.RolePermission 
			WHERE CommandID = @ID

			DELETE FROM org.Command 
			WHERE [Node].IsDescendantOf(@Node) = 1
			AND ApplicationID = @ApplicationID

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END