USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyUserSetting'))
	DROP PROCEDURE org.spModifyUserSetting
GO

CREATE PROCEDURE org.spModifyUserSetting
	@AUserID UNIQUEIDENTIFIER,
	@ASetting NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @UserID UNIQUEIDENTIFIER = @AUserID
		, @Setting NVARCHAR(MAX)= LTRIM(RTRIM(@ASetting))

	BEGIN TRY
		BEGIN TRAN

			IF NOT EXISTS (SELECT TOP 1 1 FROM org.UserSetting WHERE UserID = @UserID) -- insert
			BEGIN

				INSERT INTO org.UserSetting
				(ID, UserID, Setting)
				VALUES
				(NewID(), @UserID, @Setting)
			END
			ELSE
			BEGIN -- update
				UPDATE org.UserSetting
				SET Setting = @Setting
				WHERE UserID = @UserID
			END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END