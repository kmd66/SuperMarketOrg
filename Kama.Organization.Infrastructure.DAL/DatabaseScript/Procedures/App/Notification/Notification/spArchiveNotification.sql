USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spArchiveNotification'))
	DROP PROCEDURE app.spArchiveNotification
GO

CREATE PROCEDURE app.spArchiveNotification
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
			SET [State] = 3
			WHERE ID = @NotificationID

		EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END						
									
									
		
		
		
			

