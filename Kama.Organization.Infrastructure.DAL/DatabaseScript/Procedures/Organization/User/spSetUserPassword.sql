USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spSetUserPassword'))
	DROP PROCEDURE org.spSetUserPassword
GO

CREATE PROCEDURE org.spSetUserPassword
	@AID UNIQUEIDENTIFIER,
	@APassword VARCHAR(1000),
	@APasswordExpireDate SMALLDateTIME,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID,
		@Password VARCHAR(1000) = @APassword,
		@PasswordExpireDate SMALLDateTIME = @APasswordExpireDate,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Result INT

	BEGIN TRY
		BEGIN TRAN

			UPDATE org.[User]
			SET [Password] = @Password,
				PasswordExpireDate = DATEADD(month, 12, GETDATE())
			WHERE ID = @ID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END