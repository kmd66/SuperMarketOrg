USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyUser'))
	DROP PROCEDURE org.spModifyUser
GO

CREATE PROCEDURE org.spModifyUser
    @AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AEnabled BIT,
	@AUsername VARCHAR(20),
	@APassword NVARCHAR(1000),
	@APasswordExpireDate SMALLDATETIME,
	@AFirstName NVARCHAR(200),
	@ALastName NVARCHAR(200),
	@ANationalCode VARCHAR(18),
	@AEmail VARCHAR(256),
	@ACellPhone CHAR(11),
	@AApplicationID UNIQUEIDENTIFIER,
	@AEmailVerified bit,
	@ACellPhoneVerified bit,
	@AForeigner BIT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@Enabled BIT = ISNULL(@AEnabled, 0),
		@Username VARCHAR(20) = LTRIM(RTRIM(@AUsername)),
		@Password VARCHAR(1000) = LTRIM(RTRIM(@APassword)),
		@PasswordExpireDate SMALLDATETIME = LTRIM(RTRIM(@APasswordExpireDate)),
		@FirstName NVARCHAR(50) = LTRIM(RTRIM(@AFirstName)),
		@LastName NVARCHAR(50) = LTRIM(RTRIM(@ALastName)),
		@NationalCode VARCHAR(18) = LTRIM(RTRIM(@ANationalCode)),
		@Email VARCHAR(256) = LTRIM(RTRIM(@AEmail)),
		@CellPhone CHAR(11) = LTRIM(RTRIM(@ACellPhone)),
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@EmailVerified bit = @AEmailVerified,
		@CellPhoneVerified bit = @ACellPhoneVerified,
		@Foreigner BIT = COALESCE(@AForeigner, 0),
		@Log NVARCHAR(MAX) = @ALog,
		@Result nvarchar(max)

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.[User]
				(ID, [Enabled], Username, [Password], PasswordExpireDate, FirstName, LastName, NationalCode, Email, EmailVerified, CellPhone, CellPhoneVerified, Foreigner)
				VALUES
				(@ID, @Enabled, @Username, @Password, @PasswordExpireDate, @FirstName, @LastName, @NationalCode, @Email, @EmailVerified, @CellPhone, @CellPhoneVerified, @Foreigner)
			END
			ELSE
			BEGIN -- update
				UPDATE org.[User]
				SET [Enabled] = @Enabled,
					FirstName = @FirstName,
					LastName = @LastName,
					NationalCode = @NationalCode,
					Email = @Email,
					CellPhone = @CellPhone,
					EmailVerified = @EmailVerified,
					CellPhoneVerified = @CellPhoneVerified,
					Foreigner = @Foreigner
				WHERE ID = @ID
			END

			

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END