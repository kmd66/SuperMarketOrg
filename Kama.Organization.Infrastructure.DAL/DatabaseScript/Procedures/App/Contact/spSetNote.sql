USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spSetNote'))
	DROP PROCEDURE app.spSetNote
GO

CREATE PROCEDURE app.spSetNote
    @AID UNIQUEIDENTIFIER,
	@ANote NVARCHAR(4000),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID,
			@Note NVARCHAR(4000) = @ANote,
			@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN

		UPDATE app.Contact
		SET Note = @Note
		WHERE ID = @ID			
		
		EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT

END