USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spDeleteRefreshToken'))
	DROP PROCEDURE org.spDeleteRefreshToken
GO

CREATE PROCEDURE org.spDeleteRefreshToken
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE  @ID UNIQUEIDENTIFIER = @AID
	
	BEGIN TRY
		BEGIN TRAN

			DELETE FROM org.RefreshToken
			WHERE ID = @ID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END