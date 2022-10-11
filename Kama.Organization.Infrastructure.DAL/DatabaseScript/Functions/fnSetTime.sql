USE [Kama.Bonyad.Organization]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnSetTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnSetTime]
GO

CREATE FUNCTION [dbo].fnSetTime(@ADate SMALLDATETIME, @AH INT = 0, @AM INT = 0, @AS INT = 0)
RETURNS SMALLDATETIME
WITH ENCRYPTION
AS
BEGIN
	
	SET @ADate = COALESCE(@ADate, GETDATE())
	
	--- Set time to '00:00:00' ------------------
	DECLARE @H INT, @M INT, @S INT
	SET @H = DATEPART(HOUR, @ADate) 
	SET @M = DATEPART(MINUTE, @ADate)
	SET @S = DATEPART(SECOND, @ADate)
	SET @ADate = DATEADD(HOUR, -@H, @ADate)
	SET @ADate = DATEADD(MINUTE, -@M, @ADate)
	SET @ADate = DATEADD(SECOND, -@S, @ADate)

	--- Set custom time to date -----------------
	SET @ADate = DATEADD(HOUR, @AH, @ADate)
	SET @ADate = DATEADD(MINUTE, @AM, @ADate)
	SET @ADate = DATEADD(SECOND, @AS, @ADate)

	RETURN @ADate
END