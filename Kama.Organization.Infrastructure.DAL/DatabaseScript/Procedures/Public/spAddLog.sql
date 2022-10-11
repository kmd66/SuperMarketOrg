USE [Kama.Bonyad.Organization]
GO

--ALTER DATABASE [Kama.Organization] SET COMPATIBILITY_LEVEL = 130;
--SELECT compatibility_level  FROM sys.databases WHERE name = 'Kama.Organization';

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spAddLog'))
	DROP PROCEDURE pbl.spAddLog
GO

CREATE PROCEDURE pbl.spAddLog
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))
		  , @Now DATETIME = GETDATE();
	
	--INSERT INTO pbl.[Log]
	--SELECT Id, UserId, PositionId, CommandId, @Now, Station, [Description]
	--FROM OPENJSON(@Log) 
	--WITH(Id UNIQUEIDENTIFIER,
	--	 UserId UNIQUEIDENTIFIER,
	--	 PositionId UNIQUEIDENTIFIER,
	--	 CommandId UNIQUEIDENTIFIER,
	--	 Station VARCHAR(50),
	--	 [Description] NVARCHAR(1000))

	RETURN @@ROWCOUNT
END