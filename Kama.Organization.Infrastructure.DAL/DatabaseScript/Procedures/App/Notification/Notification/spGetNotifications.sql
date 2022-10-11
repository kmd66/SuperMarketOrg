USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetNotifications'))
	DROP PROCEDURE app.spGetNotifications
GO

CREATE PROCEDURE app.spGetNotifications
	@AApplicationID UNIQUEIDENTIFIER,
	@ASenderType TINYINT,
	@ATitle NVARCHAR(200),
	@AContent NVARCHAR(200),
	@APriority TINYINT,
	@AState TINYINT,
	@ACreationDateFrom Date,
	@ACreationDateTo Date,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE  
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@SenderType TINYINT = COALESCE(@ASenderType, 0),
		@Title NVARCHAR(200) = LTRIM(RTRIM(@ATitle)),
		@Content NVARCHAR(200) = LTRIM(RTRIM(@AContent)),
		@Priority TINYINT = COALESCE(@APriority, 0),
		@State TINYINT = COALESCE(@AState, 0),
		@CreationDateFrom Date = @ACreationDateFrom,
		@CreationDateTo Date = DATEADD(DAY, 1, @ACreationDateTo),
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		count(*) over() Total,
		ntf.ID,
		ntf.SenderPositionID,
		usr.FirstName + ' ' + usr.LastName SenderName,
		ntf.Title,
		ntf.[State],
		ntf.Content,
		ntf.[Priority],
		ntf.CreationDate
	FROM app.[Notification] ntf
		LEFT JOIN org.Position pos On pos.ID = ntf.SenderPositionID
		LEFT JOIN org.[User] usr ON usr.Id = pos.UserID
	WHERE ntf.ApplicationID = @ApplicationID
		AND (@SenderType < 1 
			OR (@SenderType = 1 AND ntf.SenderPositionID IS NULL) 
			OR (@SenderType = 2 AND ntf.SenderPositionID IS NOT NULL)
			)
		AND (@Title IS NULL OR ntf.Title LIKE CONCAT('%', @Title, '%'))
		AND (@Content IS NULL OR ntf.Content LIKE CONCAT('%', @Content, '%')) 
		AND (@Priority < 1 OR ntf.[Priority] = @Priority)
		AND (@State < 1 OR ntf.[State] = @State)
		AND (@CreationDateFrom IS NULL OR ntf.CreationDate >= @CreationDateFrom)
		AND (@CreationDateTo IS NULL OR ntf.CreationDate < @CreationDateTo)
	ORDER BY [CreationDate]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END