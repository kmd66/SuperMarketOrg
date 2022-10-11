USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyRefreshToken'))
	DROP PROCEDURE org.spModifyRefreshToken
GO

CREATE PROCEDURE org.spModifyRefreshToken
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@AIssuedDate DATETIME,
	@AExpireDate DATETIME,
	@AProtectedTicket NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@IssuedDate DATETIME = @AIssuedDate,
		@ExpireDate DATETIME = @AExpireDate,
		@ProtectedTicket NVARCHAR(MAX) = LTRIM(RTRIM(@AProtectedTicket ))

	DELETE org.RefreshToken 
	WHERE UserID = @UserID
		AND ExpireDate < GETDATE()

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1   --insert
			BEGIN

				INSERT INTO org.RefreshToken
					(ID, UserID, IssuedDate, [ExpireDate], ProtectedTicket)
				VALUES
					(@ID, @UserID, @IssuedDate, @ExpireDate, @ProtectedTicket)
			END
			ELSE
			BEGIN     -- update
				UPDATE org.RefreshToken
				SET [ExpireDate] = @ExpireDate
				WHERE ID = @ID
			END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END