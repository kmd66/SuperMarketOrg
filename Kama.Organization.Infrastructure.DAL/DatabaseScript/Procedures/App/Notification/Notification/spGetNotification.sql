USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetNotification'))
DROP PROCEDURE app.spGetNotification
GO

CREATE PROCEDURE app.spGetNotification
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		ntf.ID,
		ntf.SenderPositionID,
		usr.FirstName + ' ' + usr.LastName SenderName,
		ntf.Title,
		ntf.Content,
		ntf.[Priority],
		ntf.[State],
		ntf.CreationDate
	FROM app.[Notification] ntf
		LEFT JOIN org.Position pos On pos.ID = ntf.SenderPositionID
		LEFT JOIN org.[User] usr ON usr.Id = pos.UserID
	WHERE ntf.ID = @ID

END