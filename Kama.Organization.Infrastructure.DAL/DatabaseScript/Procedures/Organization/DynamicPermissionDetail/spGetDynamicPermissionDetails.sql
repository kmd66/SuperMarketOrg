USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetDynamicPermissionDetails'))
DROP PROCEDURE org.spGetDynamicPermissionDetails
GO

CREATE PROCEDURE org.spGetDynamicPermissionDetails
	@ADynamicPermissionIDs NVARCHAR(MAX),
	@ADynamicPermissionID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@DynamicPermissionIDs NVARCHAR(MAX) = @ADynamicPermissionIDs,
		@DynamicPermissionID UNIQUEIDENTIFIER = @ADynamicPermissionID

	SELECT
		dpt.ID,
		dpt.DynamicPermissionID,
		dpt.[Type],
		dpt.GuidValue,
		dpt.ByteValue,
		Department.Name DepartmentName, 
		Province.Name ProvinceName,
		Position.FirstName,
		Position.LastName
	FROM org.DynamicPermissionDetail dpt
		LEFT JOIN org.Department ON Department.ID = GuidValue
		LEFT JOIN org.Place Province ON Province.ID = GuidValue
		LEFT JOIN org._Position Position ON Position.ID = GuidValue
		LEFT JOIN OPENJSON(@DynamicPermissionIDs) DynamicPermissionIDs ON DynamicPermissionIDs.value = dpt.DynamicPermissionID
	WHERE
		(@DynamicPermissionID IS NULL OR dpt.DynamicPermissionID = @DynamicPermissionID)
		AND (@DynamicPermissionIDs IS NULL OR DynamicPermissionIDs.value = dpt.DynamicPermissionID)
END
