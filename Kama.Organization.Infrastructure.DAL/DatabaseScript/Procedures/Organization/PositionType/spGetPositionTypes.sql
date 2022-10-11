USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionTypes'))
	DROP PROCEDURE org.spGetPositionTypes
GO

CREATE PROCEDURE org.spGetPositionTypes
	@AApplicationID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID

	SELECT 
		positionType.ApplicationID,
		[Application].[Name] ApplicationName,
		positionType.PositionType,
		positionType.UserType
	FROM org.PositionType positionType
	inner join org.[Application] [application] on [application].ID = positionType.ApplicationID
	WHERE (@ApplicationID IS NULL OR positionType.ApplicationID = @ApplicationID)
	ORDER BY positionType

	RETURN @@ROWCOUNT
END