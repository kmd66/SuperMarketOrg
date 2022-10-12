USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetAnnouncementsForBulletin'))
	DROP PROCEDURE app.spGetAnnouncementsForBulletin
GO

CREATE PROCEDURE app.spGetAnnouncementsForBulletin
	@APositionID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ACurrentUserProvinceID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@CurrentUserProvinceID UNIQUEIDENTIFIER = @ACurrentUserProvinceID,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@PositionType TINYINT,
		@CurrentDate SMALLDATETIME = GETDATE(),
		@PositionProvinceID UNIQUEIDENTIFIER

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SET @PositionType = (SELECT [Type] FROM org.Position WHERE ID = @PositionID)
	SET @PositionProvinceID = (
		SELECT
			d.ProvinceID
		FROM
			org.Position p
			INNER JOIN org.Department d ON d.ID = p.DepartmentID
		WHERE
			p.ID = @PositionID
	)

	SELECT
		count(*) over() Total,
		ann.ID,
		ann.ProvinceID,
		ann.[Type],
		ann.[Title],
		ann.[Content],
		CAST(CASE WHEN ann.ExtendedContent IS NULL THEN 0 ELSE 1 END AS BIT) HasExtendedContent,
		ann.[Enable],
		ann.[ReleaseDate],
		ann.[DueDate],
		ann.[Enable],
		ann.[VisitCount],
		ann.[AllUsers],
		ann.[Pinned],
		attachment.[Data],
		attachment.[FileName],
		CAST(COALESCE((SELECT Top 1 ID FROM pbl.Attachment WHERE ParentID = ann.ID AND [Type] = 1) ,NULL) AS UNIQUEIDENTIFIER) AttachmentID,
		ann.Expanded,
		ann.[Priority]
	FROM app.[Announcement] ann
	LEFT JOIN pbl.Attachment attachment on attachment.ParentID = ann.ID and attachment.[Type] = 2
	WHERE [Enable] = 1
		AND ann.ApplicationID = @ApplicationID
		AND (ann.ProvinceID IS NULL OR ann.ProvinceID = @PositionProvinceID)
		AND (ReleaseDate IS NULL OR @CurrentDate >= CAST(ReleaseDate AS DATE))
		AND (DueDate IS NULL OR @CurrentDate < DATEADD(DAY, 1, CAST(DueDate AS DATE)))
		AND (@PositionID IS NULL OR ann.AllUsers = 1 OR EXISTS (SELECT 1 FROM app.AnnouncementPositionType WHERE PositionType = @PositionType AND AnnouncementID = ann.ID))
		AND (@PositionID IS NOT NULL OR UnAuthorizedUsers = 1)
		AND (@CurrentUserProvinceID IS NULL OR ann.ProvinceID IS NULL OR ann.ProvinceID = @CurrentUserProvinceID)
	ORDER BY  ann.[ReleaseDate] DESC  
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END