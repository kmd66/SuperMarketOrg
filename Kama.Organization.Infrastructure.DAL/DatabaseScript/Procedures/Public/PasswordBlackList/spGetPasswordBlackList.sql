USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetPasswordBlackList'))
	DROP PROCEDURE pbl.spGetPasswordBlackList
GO

CREATE PROCEDURE pbl.spGetPasswordBlackList
	@APassword varchar(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @Password varchar(1000) = @APassword
		
	SELECT ID
		, passBlackList.[Password]
		, passBlackList.[RepeatCount]
		, passBlackList.CreationDate
	FROM pbl.PasswordBlackList passBlackList
	WHERE passBlackList.[Password] = @Password

	RETURN @@ROWCOUNT
END