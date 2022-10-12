USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionPermissions'))
	DROP PROCEDURE org.spGetPositionPermissions
GO

CREATE PROCEDURE org.spGetPositionPermissions
	@APositionID UNIQUEIDENTIFIER,
	@ACommandID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@CommandID UNIQUEIDENTIFIER = @ACommandID 
	
	SELECT 
		c.FullName,
		c.Type,
		c.Node.ToString() Node
	FROM org.PositionRole u
		INNER JOIN org.[Role] r ON r.ID = u.RoleID
		INNER JOIN org.RolePermission p ON u.RoleID = p.RoleID
		INNER JOIN org.Command c ON c.ID = p.CommandID
	WHERE u.PositionID = @PositionID 
		AND (@CommandID IS NULL OR c.ID = @CommandID)

	RETURN @@ROWCOUNT
END