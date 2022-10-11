USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetWebServiceUser'))
	DROP PROCEDURE org.spGetWebServiceUser
GO

CREATE PROCEDURE org.spGetWebServiceUser
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT 
		usr.ID, 
		usr.UserName, 
		--usr.[Password], 
		usr.OrganID, 
		org.[Name] OrganName,
		usr.[Enabled], 
		usr.PasswordExpireDate, 
		usr.Comment
	FROM org.WebServiceUser usr
		INNER JOIN org.Department org On org.ID = usr.OrganID
	WHERE usr.ID = @ID
END
