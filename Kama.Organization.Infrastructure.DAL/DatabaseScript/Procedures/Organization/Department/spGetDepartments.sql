USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID(N'org.spGetDepartments'))
DROP PROCEDURE org.spGetDepartments
GO

CREATE PROCEDURE org.spGetDepartments
	@AParentID UNIQUEIDENTIFIER,
	@AProvinceID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@ACode VARCHAR(20),
	@AName NVARCHAR(256),
	@ASearchWithHierarchy bit,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@ProvinceID UNIQUEIDENTIFIER = @AProvinceID,
		@Type TINYINT = ISNULL(@AType, 0),
		@Code VARCHAR(20) = LTRIM(RTRIM(@ACode)), 
		@Name NVARCHAR(256) = LTRIM(RTRIM(@AName)), 
		@SearchWithHierarchy bit = COALESCE(@ASearchWithHierarchy, 0),
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@ParentNode HIERARCHYID
		--, 
		--@ParentName NVARCHAR(MAX)

	IF @ParentID = 0x
		SET @ParentID = NULL
		
	SET @ParentNode = (SELECT [Node] FROM org.Department WHERE ID = @ParentID)

	--Set @ParentName = (SELECT [Name] FROM org.Department WHERE ID = @ParentID)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;With SelectedDepartment AS
	(
		SELECT *
		FROM org.Department
		WHERE Department.RemoverID IS NULL
			AND (@ParentNode IS NULL OR Department.[Node].IsDescendantOf(@ParentNode) = 1)
			AND (@ProvinceID IS NULL OR department.ProvinceID = @ProvinceID)
			AND (@Type < 1 OR Department.[Type] = @Type)
			AND (@Code IS NULL OR Department.Code Like CONCAT('%', @Code, '%'))
			AND (@Name IS NULL OR Department.[Name] Like CONCAT('%', @Name , '%'))
	)
	, ParentDepartment AS
	(
		SELECT DISTINCT *
		FROM org.Department Parent
		WHERE @SearchWithHierarchy = 1 
			AND ID NOT IN (SELECT ID FROM SelectedDepartment) 
			AND EXISTS(SELECT TOP 1 1 FROM SelectedDepartment WHERE SelectedDepartment.Node.IsDescendantOf(Parent.Node) = 1)
	)
	, UnionDepartment AS
	(
		SELECT * FROM SelectedDepartment
		UNION ALL 
		SELECT * FROM ParentDepartment
	)
	, ParentAdded AS
	(
		select *,
		UnionDepartment.[Node].GetAncestor(1).ToString() [ParentNode]
		from UnionDepartment
	)
	SELECT 
		Count(*) OVER() Total,
		ParentAdded.ID,
		ParentAdded.[Node].ToString() [Node],
		--ParentAdded.[Node].GetAncestor(1).ToString() [ParentNode],
		ParentAdded.ParentNode,
		dept.[Name] ParentName,
		ParentAdded.[Type],
		ParentAdded.Code,
		ParentAdded.[Name],
		ParentAdded.[Enabled],
		ParentAdded.ProvinceID,
		province.[Name] ProvinceName,
		ParentAdded.[Address],
		ParentAdded.PostalCode 
	FROM ParentAdded
	LEFT JOIN org.Place province ON province.ID = ParentAdded.ProvinceID
	LEFT JOIN Department AS dept ON dept.Node = ParentAdded.ParentNode
	--,
	--Department dept
	--WHERE dept.Node = ParentAdded.ParentNode
	ORDER BY ParentAdded.[Node], ParentAdded.[Name]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END