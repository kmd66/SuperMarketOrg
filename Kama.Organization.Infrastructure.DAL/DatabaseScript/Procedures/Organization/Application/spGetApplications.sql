USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetApplications'))
	DROP PROCEDURE org.spGetApplications
GO

CREATE PROCEDURE org.spGetApplications
	  @AName NVARCHAR(100)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Name NVARCHAR(100) = LTRIM(RTRIM(@AName))
	
	SELECT
		ID,
		[Name],
		[Enabled],
		Comment
	FROM org.[Application]
	WHERE (@Name IS NULL OR Name Like CONCAT('%', @Name, '%'))
	
END
