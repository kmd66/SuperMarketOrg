USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetWebServiceUserByUserPass'))
	DROP PROCEDURE org.spGetWebServiceUserByUserPass
GO

CREATE PROCEDURE org.spGetWebServiceUserByUserPass
	@AUserName NVARCHAR(1000),
	@APassword NVARCHAR(4000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@UserName NVARCHAR(1000) = TRIM(@AUserName),
		@Password NVARCHAR(4000) = RTRIM(@APassword)
	
	SELECT 
		usr.ID, 
		usr.UserName, 
		usr.[Password], 
		usr.OrganID, 
		org.[Name] OrganName,
		usr.[Enabled], 
		usr.PasswordExpireDate, 
		usr.Comment
	FROM org.WebServiceUser usr
		INNER JOIN org.Department org On org.ID = usr.OrganID
	WHERE UserName = @UserName
		AND [Password] = @Password
END