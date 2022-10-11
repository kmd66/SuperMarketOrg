USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionType'))
	DROP PROCEDURE org.spGetPositionType
GO

CREATE PROCEDURE org.spGetPositionType
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT 
		positionType.ApplicationID,
		[Application].[Name] ApplicationName,
		positionType.PositionType,
		positionType.UserType
	FROM org.PositionType positionType
	inner join org.[Application] [application] on [application].ID = positionType.ApplicationID
	WHERE positionType.ID = @ID

	RETURN @@ROWCOUNT
END