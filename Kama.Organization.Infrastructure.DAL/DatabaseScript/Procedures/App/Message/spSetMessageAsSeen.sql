USE [Kama.Bonyad.Organization]
GO

IF EXISTS( SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spSetMessageAsSeen'))
	DROP PROCEDURE app.spSetMessageAsSeen
GO

CREATE PROCEDURE app.spSetMessageAsSeen
	@ACurrentUserID UNIQUEIDENTIFIER,
	@AMessageID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS

BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID,
		@MessageID UNIQUEIDENTIFIER = @AMessageID,
		@SenderUserID UNIQUEIDENTIFIER

	SET @SenderUserID = (SELECT SenderUserID FROM app.[Message] WHERE ID = @MessageID)

	BEGIN TRY
		BEGIN TRAN
			
				UPDATE app.MessageReceivers 
				SET Seen = 1 
				WHERE MessageID = @MessageID 
					AND ReceiverUserID= @CurrentUserID
						
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

END