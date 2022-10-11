USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spDeleteNotification'))
	DROP PROCEDURE app.spDeleteNotification
GO

CREATE PROCEDURE app.spDeleteNotification
	@AID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ID UNIQUEIDENTIFIER = @AID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@State TINYINT

	SET @State = (SELECT [State] FROM app.[Notification] WHERE ID = @ID)

	BEGIN TRY
		BEGIN TRAN
		
		IF @State = 1 -- ارسال نشده
		BEGIN
			DELETE FROM app.[Notification] 
			WHERE ID = @ID

			DELETE app.NotificationPosition
			WHERE NotificationID = @ID
		END	
		ELSE    --ارسال شده
		BEGIN
			UPDATE app.[Notification] 
			SET [State] = 4
			WHERE ID = @ID
		END

		EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	RETURN @@ROWCOUNT
END