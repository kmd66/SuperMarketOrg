USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetSecurityStampByCellPhone'))
	DROP PROCEDURE org.spGetSecurityStampByCellPhone
GO

CREATE PROCEDURE org.spGetSecurityStampByCellPhone
	@ACellPhone VARCHAR(20)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@CellPhone VARCHAR(20) = @ACellPhone

	SELECT 
		ID,
		CellPhone,
		Email,
		Stamp,
		CreationDate
	FROM org.SecurityStamp
	WHERE CellPhone = @CellPhone

END