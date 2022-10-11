USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID(N'org.spGetDepartment'))
DROP PROCEDURE org.spGetDepartment
GO

CREATE PROCEDURE org.spGetDepartment
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
		Department.ID,
		Department.[Node].ToString() Node,
		Department.[Node].GetAncestor(1).ToString() ParentNode,
		Department.[Type],
		Department.Code,
		Department.[Name],
		Department.[Enabled],
		Department.ProvinceID,
		province.[Name] ProvinceName,
		Department.Address,
		Department.PostalCode,
		Parent.ID ParentID
	FROM org.Department
		LEFT JOIN org.Place province ON province.ID = Department.ProvinceID
		LEFT JOIN org.Department Parent On Department.Node.GetAncestor(1) = Parent.Node
	WHERE Department.ID = @ID

	RETURN @@ROWCOUNT
END