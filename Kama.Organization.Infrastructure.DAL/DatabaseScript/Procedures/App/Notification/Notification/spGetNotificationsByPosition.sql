USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetNotificationsByPosition'))
	DROP PROCEDURE app.spGetNotificationsByPosition
GO

CREATE PROCEDURE app.spGetNotificationsByPosition
	@AApplicationID UNIQUEIDENTIFIER,
	@ACurrentUserPositionID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@CurrentUserPositionID UNIQUEIDENTIFIER = @ACurrentUserPositionID

	SELECT
		ntf.ID,
		ntf.Content,
		ntf.Title,
		ntf.Priority,
		ntf.CreationDate
	FROM app.NotificationPosition ntfPosition
		INNER JOIN app.[Notification] ntf ON ntf.ID = ntfPosition.NotificationID
	WHERE ntf.ApplicationID = @ApplicationID
		AND ntfPosition.PositionID = @CurrentUserPositionID
		AND COALESCE(ntfPosition.IsRemoved, 0) = 0
		AND ntf.State IN (2, 3)
	ORDER BY ntf.[Priority], ntf.CreationDate

	Update app.NotificationPosition
	SET IsRemoved = 1
	WHERE PositionID = @CurrentUserPositionID

END