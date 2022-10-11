USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetModifyUserValidation'))
	DROP PROCEDURE org.spGetModifyUserValidation
GO

CREATE PROCEDURE org.spGetModifyUserValidation
	@AID UNIQUEIDENTIFIER,
	@ANationalCode VARCHAR(18),
	@AUsername VARCHAR(20),
	@ACellPhone VARCHAR(20),
	@AEmail VARCHAR(256)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@ID UNIQUEIDENTIFIER = @AID,
		@NationalCode VARCHAR(18) = LTRIM(RTRIM(@ANationalCode)),
		@Username VARCHAR(20) = LTRIM(RTRIM(@AUsername)),
		@CellPhone VARCHAR(20) = LTRIM(RTRIM(@ACellPhone)),
		@Email VARCHAR(256) = LTRIM(RTRIM(@AEmail)),
		@IsNationalCodeRepeated bit = 0,
		@IsUserNameRepeated bit = 0,
		@IsEmailRepeated bit = 0,
		@IsCellphoneRepeated bit = 0,
		@IsCellPhoneChanged bit = 0,
		@IsEmailChanged bit = 0

	SET @IsNationalCodeRepeated = COALESCE((SELECT TOP 1 1 FROM org.[User] WHERE ID <> @ID AND REPLACE(NationalCode, ' ', '') = REPLACE(@NationalCode, ' ', '')), 0)
	SET @IsUserNameRepeated = COALESCE((SELECT TOP 1 1 FROM org.[User] WHERE ID <> @ID AND REPLACE(Username, ' ', '') = REPLACE(@Username, ' ', '')), 0)
	SET @IsCellphoneRepeated = COALESCE((SELECT TOP 1 1 FROM org.[User] WHERE ID <> @ID AND REPLACE(CellPhone, ' ', '') = REPLACE(@CellPhone, ' ', '')), 0)
	SET @IsEmailRepeated = COALESCE((SELECT TOP 1 1 FROM org.[User] WHERE ID <> @ID AND REPLACE(Email, ' ', '') = REPLACE(@Email, ' ', '')) ,0)

	IF COALESCE(@CellPhone, '') <> COALESCE((SELECT CellPhone FROM org.[User] WHERE ID = @ID), '')
	BEGIN 
		SET @IsCellPhoneChanged = 1
	END

	IF COALESCE(@Email, '') <> COALESCE((SELECT Email FROM org.[User] WHERE ID = @ID), '')
	BEGIN 
		SET @IsEmailChanged = 1
	END

	SELECT
		@ID, 
		@NationalCode NationalCode,
		@Username Username,
		@CellPhone CellPhone,
		@Email Email,
		@IsNationalCodeRepeated IsNationalCodeRepeated,
		@IsUserNameRepeated IsUserNameRepeated,
		@IsEmailRepeated IsEmailRepeated,
		@IsCellphoneRepeated IsCellphoneRepeated,
		@IsCellPhoneChanged IsCellPhoneChanged,
		@IsEmailChanged IsEmailChanged
END