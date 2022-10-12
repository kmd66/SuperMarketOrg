USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyWebServiceUser'))
	DROP PROCEDURE org.spModifyWebServiceUser
GO

CREATE PROCEDURE org.spModifyWebServiceUser
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AUserName NVARCHAR(50),
	@APassword NVARCHAR(1000),
	@AOrganID UNIQUEIDENTIFIER,
	@AEnabled BIT,
	@APasswordExpireDate SMALLDATETIME,
	@ACreatorID UNIQUEIDENTIFIER,
	@AComment NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@UserName NVARCHAR(50) = LTRIM(RTRIM(@AUserName)),
		@Password NVARCHAR(1000) = LTRIM(RTRIM(@APassword)),
		@OrganID UNIQUEIDENTIFIER = @AOrganID,
		@Enabled BIT = COALESCE(@AEnabled, 0),
		@PasswordExpireDate SMALLDATETIME = @APasswordExpireDate,
		@CreatorID UNIQUEIDENTIFIER = @ACreatorID,
		@Comment NVARCHAR(1000) = LTRIM(RTRIM(@AComment))

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.WebServiceUser
				(ID, UserName, Password, OrganID, Enabled, PasswordExpireDate, Comment, CreatorID, CreationDate)
				VALUES
				(@ID, @UserName, @Password, @OrganID, @Enabled, @PasswordExpireDate, @Comment, @CreatorID, GETDATE())
			END
			ELSE    -- update
			BEGIN
				UPDATE org.WebServiceUser
				SET UserName = @UserName, Password = @Password, OrganID = @OrganID, Enabled = @Enabled, PasswordExpireDate = @PasswordExpireDate, Comment = @Comment
				WHERE ID = @ID
			END

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
