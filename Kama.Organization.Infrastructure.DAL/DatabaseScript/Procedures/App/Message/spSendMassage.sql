USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spSendMessage'))
	DROP PROCEDURE app.spSendMessage
GO

CREATE PROCEDURE app.spSendMessage
	@AMessageID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@MessageID UNIQUEIDENTIFIER = @AMessageID
			
	BEGIN TRY
		BEGIN TRAN
				
			Update app.[Message] 
			SET IsSent = 1
			WHERE ID = @MessageID

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END						
									
									
		
		
		
			

