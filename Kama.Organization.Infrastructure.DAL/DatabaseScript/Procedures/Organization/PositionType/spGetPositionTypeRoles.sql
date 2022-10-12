USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionTypeRoles'))
	DROP PROCEDURE org.spGetPositionTypeRoles
GO

CREATE PROCEDURE org.spGetPositionTypeRoles
	@AApplicationID UNIQUEIDENTIFIER,
	@APositionType TINYINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@PositionType TINYINT = @APositionType

	SELECT r.ID,
		r.[Name]
	FROM org.PositionTypeRole ptr
		INNER JOIN org.[Role] r ON r.ID = ptr.RoleID
	WHERE ptr.ApplicationID = @ApplicationID
		AND ptr.PositionType = @PositionType

	RETURN @@ROWCOUNT
END