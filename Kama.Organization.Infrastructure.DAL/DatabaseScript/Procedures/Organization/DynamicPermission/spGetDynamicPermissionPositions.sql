USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetDynamicPermissionPositions'))
DROP PROCEDURE org.spGetDynamicPermissionPositions
GO

CREATE PROCEDURE org.spGetDynamicPermissionPositions
	@AObjectID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ASortExp NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ObjectID UNIQUEIDENTIFIER = @AObjectID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@SortExp NVARCHAR(MAX) = LTRIM(RTRIM(@ASortExp)),
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH PermissionDetail AS
	(
		SELECT 
			detail.[Type],
			detail.GuidValue,
			detail.ByteValue
		FROM org.DynamicPermission
			INNER JOIN org.DynamicPermissionDetail detail ON detail.DynamicPermissionID = DynamicPermission.ID
		WHERE
			DynamicPermission.ObjectID = @ObjectID
			AND DynamicPermission.ApplicationID = @ApplicationID
			
	)
	, MainSelect As
	(
		SELECT DISTINCT position.*
		FROM org._position position
			INNER JOIN org.Department ON Department.ID = position.DepartmentID
			INNER JOIN org.Department parentDepartment On Department.Node.IsDescendantOf(parentDepartment.Node) = 1
			INNER JOIN PermissionDetail ON (PermissionDetail.[Type] = 1 AND parentDepartment.ID = PermissionDetail.GuidValue)
										OR (PermissionDetail.[Type] = 2 AND Department.ID = PermissionDetail.GuidValue)
										OR (PermissionDetail.[Type] = 3 AND Department.ProvinceID = PermissionDetail.GuidValue)
										OR (PermissionDetail.[Type] = 4 AND Department.Type = PermissionDetail.ByteValue)
										OR (PermissionDetail.[Type] = 9 AND Position.Type = PermissionDetail.ByteValue)
										OR (PermissionDetail.[Type] = 10 AND position.ID = PermissionDetail.GuidValue)
		WHERE Position.ApplicationID = @ApplicationID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY ID
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
