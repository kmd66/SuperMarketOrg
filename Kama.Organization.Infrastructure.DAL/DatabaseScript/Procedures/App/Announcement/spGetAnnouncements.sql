USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetAnnouncements'))
	DROP PROCEDURE app.spGetAnnouncements
GO

CREATE PROCEDURE app.spGetAnnouncements
	@AUserID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ACurrentUserProvinceID UNIQUEIDENTIFIER,
	@ATitle NVARCHAR(200),
	@AEnable TINYINT,
	@AType TINYINT,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @UserID UNIQUEIDENTIFIER = @AUserID,
		@ApplicationID UNIQUEIDENTIFIER  = @AApplicationID,
		@CurrentUserProvinceID UNIQUEIDENTIFIER = @ACurrentUserProvinceID,
		@Title NVARCHAR(200) = @ATitle,
		@Enable TINYINT = COALESCE(@AEnable, 0),
		@Type TINYINT = COALESCE(@AType, 0),
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)
		
	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END


	;WITH MainSelect AS (
		SELECT
			count(*) over() Total,
			ann.ProvinceID,
			ann.ID,
			ann.[Type],
			ann.[Title],
			--ann.Content,
			--ann.ExtendedContent,
			ann.[ReleaseDate],
			ann.[DueDate],
			ann.[Enable],
			ann.[VisitCount],
			ann.[AllUsers],
			ann.[Pinned],
			ann.AuthorizedUsers,
			ann.UnAuthorizedUsers,
			ann.Expanded,
			ann.[Priority]
		FROM 
			app.[Announcement] ann
		WHERE
			ann.ApplicationID = @ApplicationID
			AND (@CurrentUserProvinceID IS NULL OR ann.ProvinceID = @CurrentUserProvinceID)
			AND (@Title IS NULL OR ann.[Title] LIKE '%' + @Title + '%')
			AND (@Enable < 1 OR ann.[Enable] = @Enable - 1)
			AND (@Type < 1 OR ann.[Type] = @Type)
	)
	SELECT * FROM MainSelect		 
	ORDER BY [ReleaseDate] DESC 
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END