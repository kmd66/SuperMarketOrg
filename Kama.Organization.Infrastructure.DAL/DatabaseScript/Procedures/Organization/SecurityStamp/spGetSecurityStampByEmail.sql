USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetSecurityStampByEmail'))
	DROP PROCEDURE org.spGetSecurityStampByEmail
GO

CREATE PROCEDURE org.spGetSecurityStampByEmail
	@AEmail NVARCHAR(200)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@Email NVARCHAR(200) = @AEmail

	SELECT 
		ID,
		CellPhone,
		Email,
		Stamp,
		CreationDate
	FROM org.SecurityStamp
	WHERE Email = @Email

END