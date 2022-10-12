USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetNotificationConditions'))
	DROP PROCEDURE app.spGetNotificationConditions
GO

CREATE PROCEDURE app.spGetNotificationConditions
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
		ntfc.ID,
		ntfc.NotificationID,
		ntfc.DepartmentID,
		dep.[Name] DepartmentName,
		ntfc.ProvinceID,
		plc.[Name] ProvinceName,
		ntfc.PositionType,
		ntfc.PositionID,
		usr.FirstName +' '+ usr.LastName FullName
	FROM app.NotificationCondition ntfc
		LEFT JOIN org.Department dep ON dep.ID = ntfc.DepartmentID
		LEFT JOIN org.Place plc ON plc.ID = ntfc.ProvinceID
		LEFT JOIN org.Position pos ON pos.ID = ntfc.PositionID
		LEFT JOIN org.[User] usr ON usr.ID = Pos.UserID
	WHERE ntfc.NotificationID = @NotificationID
	ORDER BY [LastName]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END