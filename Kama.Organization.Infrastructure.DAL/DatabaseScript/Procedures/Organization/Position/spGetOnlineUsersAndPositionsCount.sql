USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetOnlineUsersAndPositionsCount'))
	DROP PROCEDURE org.spGetOnlineUsersAndPositionsCount
GO

CREATE PROCEDURE org.spGetOnlineUsersAndPositionsCount
	@AApplicationID UNIQUEIDENTIFIER,
	@AAccessTokenExpireTimeSpan INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@AccessTokenExpireTimeSpan INT = COALESCE(@AAccessTokenExpireTimeSpan, 0),
		@Date DATETIME

	SET @Date = DATEADD(MINUTE, -1 * @AccessTokenExpireTimeSpan, GetDate())

	;WITH UserCount AS
	(
		SELECT Count(DISTINCT UserID) UserCount
		FROM org._Position p
		where p.ApplicationID = @ApplicationID
		AND LastTokenDate >= @Date
	)
	, PositionCount AS
	(
		SELECT Count(*) PositionCount
		FROM org._Position p
		where p.ApplicationID = @ApplicationID
			AND LastTokenDate >= @Date
	)
	SELECT *
	FROM UserCount, PositionCount

END
