USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spSendNotification'))
	DROP PROCEDURE app.spSendNotification
GO

CREATE PROCEDURE app.spSendNotification
	@ANotificationID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@NotificationID UNIQUEIDENTIFIER = @ANotificationID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))
			
	BEGIN TRY
		BEGIN TRAN
				
			UPDATE app.[Notification] 
			SET [State] = 2
			WHERE ID = @NotificationID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END						
									
									
		
		
		
			

