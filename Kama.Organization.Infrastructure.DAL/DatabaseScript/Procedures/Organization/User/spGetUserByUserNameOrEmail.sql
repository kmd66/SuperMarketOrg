USE [Kama.Bonyad.Organization]
GO

-- this sp is only for login, because it returns password!!!

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetUserByUserNameOrEmail'))
	DROP PROCEDURE org.spGetUserByUserNameOrEmail
GO

CREATE PROCEDURE org.spGetUserByUserNameOrEmail
	@AUsername VARCHAR(50),
	@AEmail VARCHAR(256),
	@AApplicationID UNIQUEIDENTIFIER,
	@ACurrentUserID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Username VARCHAR(50) = LTRIM(RTRIM(@AUsername)),
		@Email VARCHAR(256) = LTRIM(RTRIM(@AEmail)),
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID, 
		@OrganizationAppplicationID UNIQUEIDENTIFIER
	
	SELECT ID,
      [Enabled],
      Username,
      FirstName,
      LastName,
      NationalCode,
      Email,
      EmailVerified,
      CellPhone,
      CellPhoneVerified,
      [Password]
	FROM org.[User] usr
	WHERE (@Username IS NOT NULL AND usr.Username = @Username) 
		OR (@Email IS NOT NULL AND usr.Email = @Email)

	RETURN @@ROWCOUNT
END