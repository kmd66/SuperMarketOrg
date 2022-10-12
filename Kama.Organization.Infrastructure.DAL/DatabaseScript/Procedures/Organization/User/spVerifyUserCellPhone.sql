USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spVerifyUserCellPhone'))
	DROP PROCEDURE org.spVerifyUserCellPhone
GO

CREATE PROCEDURE org.spVerifyUserCellPhone
	@AUserID UNIQUEIDENTIFIER,
	@AIsVerified BIT, 
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @UserID UNIQUEIDENTIFIER = @AUserID,
		@IsVerified BIT = COALESCE(@AIsVerified, 0),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))
	
	BEGIN TRY
		BEGIN TRAN

			UPDATE org.[User]
			SET CellPhoneVerified = @IsVerified
			WHERE ID = @UserID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END