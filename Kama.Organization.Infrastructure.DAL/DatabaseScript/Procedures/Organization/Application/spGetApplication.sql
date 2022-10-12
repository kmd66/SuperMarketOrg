USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetApplication'))
	DROP PROCEDURE org.spGetApplication
GO

CREATE PROCEDURE org.spGetApplication
	  @AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT
		ID,
		[Name],
		[Enabled],
		Comment,
		[Code]
	FROM org.[Application]
	WHERE  ID = @ID
	
END
