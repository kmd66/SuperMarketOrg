USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionDepartmentMappings'))
DROP PROCEDURE org.spGetPositionDepartmentMappings
GO

CREATE PROCEDURE org.spGetPositionDepartmentMappings
	@AApplicationID UNIQUEIDENTIFIER,
	@APositionType TINYINT,
	@ADepartmentType TINYINT,
	@ASortExp NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@PositionType TINYINT = COALESCE(@APositionType, 0),
		@DepartmentType TINYINT = COALESCE(@ADepartmentType, 0),
		@SortExp NVARCHAR(MAX) = LTRIM(RTRIM(@ASortExp)),
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS
	(
		SELECT
			pdm.ID,
			pdm.PositionType,
			pdm.DepartmentType,
			pdm.MaxUsersCount,
			pdm.CreationDate
		FROM org.PositionDepartmentMapping pdm
		WHERE ApplicationID = @ApplicationID
			AND (@PositionType < 1 OR pdm.PositionType = @PositionType)
			AND (@DepartmentType < 1 OR pdm.DepartmentType = @DepartmentType)
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY ID
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
