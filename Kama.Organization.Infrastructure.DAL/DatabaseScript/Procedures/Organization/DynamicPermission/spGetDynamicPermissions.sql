USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetDynamicPermissions'))
DROP PROCEDURE org.spGetDynamicPermissions
GO

CREATE PROCEDURE org.spGetDynamicPermissions
	@AObjectID UNIQUEIDENTIFIER,
	@ASortExp NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ObjectID UNIQUEIDENTIFIER = @AObjectID,
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
			DynamicPermission.ID,
			DynamicPermission.ObjectID,
			DynamicPermission.CreationDate,
			DynamicPermission.[Order]
		FROM org.DynamicPermission
		WHERE
			DynamicPermission.ObjectID = @ObjectID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY ID
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
