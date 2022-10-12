USE [Kama.Sm.Organization]
GO

IF EXISTS( SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spDeleteMessage'))
	DROP PROCEDURE app.spDeleteMessage
GO

CREATE PROCEDURE app.spDeleteMessage
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

			IF @SenderUserID = @CurrentUserID
			BEGIN
				UPDATE app.[Message]
				SET IsRemoved = 1
				WHERE ID = @MessageID
			END
			ELSE
			BEGIN
				UPDATE app.MessageReceivers 
				SET IsRemoved = 1 
				WHERE MessageID = @MessageID 
					AND ReceiverUserID= @CurrentUserID
			END
						
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

END