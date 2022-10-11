USE [Kama.Bonyad.Organization]
GO

IF EXISTS(Select 1 From SYS.PROCEDURES WHERE [object_id] = OBJECT_ID ('app.spPermanentDeleteMessage'))
DROP PROCEDURE app.spPermanentDeleteMessage

GO

CREATE PROCEDURE app.spPermanentDeleteMessage

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
				DELETE FROM app.[Message]
				WHERE ID = @MessageID
			END
						
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

END
