USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetNotificationPositions'))
	DROP PROCEDURE app.spGetNotificationPositions
GO

CREATE PROCEDURE app.spGetNotificationPositions
	@ANotificationID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@NotificationID UNIQUEIDENTIFIER = @ANotificationID,
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		count(*) over() Total,
		usr.ID,
		usr.FirstName +' '+ usr.LastName FullName,
		dep.[Name] DepartmentName,
		pos.[Type] PositionType
	FROM app.NotificationPosition ntfPosition
		LEFT JOIN org.[Position] pos ON pos.ID = ntfPosition.PositionID
		LEFT JOIN org.Department dep ON dep.ID = pos.DepartmentID
		LEFT JOIN org.[User] usr ON usr.ID = pos.UserID
	WHERE ntfPosition.NotificationID = @NotificationID
	ORDER BY [LastName]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END