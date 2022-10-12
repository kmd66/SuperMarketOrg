USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetDynamicPermissionObjectsByPosition'))
DROP PROCEDURE org.spGetDynamicPermissionObjectsByPosition
GO

CREATE PROCEDURE org.spGetDynamicPermissionObjectsByPosition
	@APositionID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID

	;WITH Position As
	(
		SELECT 
			Position.ID,
			parentDepartment.ID ParentDepartmentID,
			Position.DepartmentID,
			Department.[Type] DepartmentType,
			Department.ProvinceID,
			Position.[Type]
		FROM org.position 
			INNER JOIN org.Department ON Department.ID = position.DepartmentID
			INNER JOIN org.Department parentDepartment On Department.Node.IsDescendantOf(parentDepartment.Node) = 1
		WHERE position.RemoverID IS NULL
			AND Position.ApplicationID = @ApplicationID
			AND Position.ID = @PositionID
	)
	SELECT DISTINCT DynamicPermission.ObjectID
	FROM org.DynamicPermission
		INNER JOIN org.DynamicPermissionDetail detail ON detail.DynamicPermissionID = DynamicPermission.ID
		INNER JOIN Position ON (detail.Type = 1 AND Position.ParentDepartmentID = detail.GuidValue)
							OR (detail.Type = 2 AND Position.DepartmentID = detail.GuidValue)
							OR (detail.Type = 3 AND Position.ProvinceID = detail.GuidValue)
							OR (detail.Type = 4 AND Position.DepartmentType = detail.ByteValue)
							OR (detail.Type = 9 AND Position.[Type] = detail.ByteValue)
							OR (detail.Type = 10 AND Position.ID = detail.GuidValue)
	WHERE DynamicPermission.ApplicationID = @ApplicationID

END
