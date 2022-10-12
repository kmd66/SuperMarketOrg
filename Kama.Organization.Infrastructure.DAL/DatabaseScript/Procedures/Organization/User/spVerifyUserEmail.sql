USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spVerifyUserEmail'))
	DROP PROCEDURE org.spVerifyUserEmail
GO

CREATE PROCEDURE org.spVerifyUserEmail
	@AUserID UNIQUEIDENTIFIER,
	@AIsVerified BIT, 
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @UserID UNIQUEIDENTIFIER = @AUserID,
	    @IsVerified BIT = @AIsVerified,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Result INT 
	
	BEGIN TRY
		BEGIN TRAN

			UPDATE org.[User]
			SET EmailVerified = @IsVerified
			WHERE ID = @UserID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END