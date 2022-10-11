USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spSetArchive'))
	DROP PROCEDURE app.spSetArchive
GO

CREATE PROCEDURE app.spSetArchive
    @AID UNIQUEIDENTIFIER,
	@AArchiveType TINYINT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID,
			@ArchiveType TINYINT = @AArchiveType,			
			@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN

		UPDATE app.Contact
		SET Archived = @ArchiveType
		WHERE ID = @ID	
				
		EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT

END
