USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetNotificationCondition'))
DROP PROCEDURE app.spGetNotificationCondition
GO

CREATE PROCEDURE app.spGetNotificationCondition
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

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
	WHERE ntfc.ID = @ID
END