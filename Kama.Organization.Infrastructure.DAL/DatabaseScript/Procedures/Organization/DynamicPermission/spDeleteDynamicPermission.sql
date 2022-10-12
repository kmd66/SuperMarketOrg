USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spDeleteDynamicPermission'))
	DROP PROCEDURE org.spDeleteDynamicPermission
GO

CREATE PROCEDURE org.spDeleteDynamicPermission
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@ID UNIQUEIDENTIFIER = @AID

	BEGIN TRY
		BEGIN TRAN

			DELETE org.DynamicPermissionDetail
			WHERE DynamicPermissionID = @ID

			DELETE org.DynamicPermission
			WHERE ID = @ID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
