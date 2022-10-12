USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetUserSetting'))
	DROP PROCEDURE org.spGetUserSetting
GO

CREATE PROCEDURE org.spGetUserSetting
	@AUserID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @UserID UNIQUEIDENTIFIER = @AUserID
	
	SELECT ID
		 , @UserID
		 , Setting
	FROM org.UserSetting
	WHERE UserID = @UserID 

	RETURN @@ROWCOUNT
END