USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetRoles'))
	DROP PROCEDURE org.spGetRoles
GO

CREATE PROCEDURE org.spGetRoles
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(1000),
	@APositionType TINYINT,
	@APositionID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(1000) = LTRIM(RTRIM(@AName)),
		@PositionType TINYINT = COALESCE(@APositionType, 0),
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS (
	SELECT 
		Count(*) OVER() Total,
		rol.ID,
		rol.ApplicationID,
		rol.[Name]
	FROM org.[Role] rol
		LEFT JOIN org.PositionTypeRole ptRole ON ptRole.RoleID = rol.ID AND ptRole.PositionType = @PositionType
		LEFT JOIN org.PositionRole pRole ON pRole.RoleID = rol.ID  AND @PositionID IS NOT NULL
		LEFT JOIN org.Position pos ON pos.ID = pRole.PositionID AND pos.Id = @PositionID
		LEFT JOIN org.[User] usr ON usr.ID = pos.UserID AND usr.ID = @UserID
	WHERE rol.ApplicationID = @ApplicationID
		AND (@Name IS NULL OR rol.[Name] LIKE CONCAT('%', @Name, '%'))
		AND (@PositionType < 1 OR ptRole.PositionType = @PositionType)
		AND (@PositionID IS NULL OR pos.ID = @PositionID)
		AND (@UserID IS NULL OR usr.ID = @UserID)
	)
	SELECT * FROM MainSelect		 
	ORDER BY [ID]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END