USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID ('app.spRatingTicket'))
DROP PROCEDURE app.spRatingTicket
GO

CREATE PROCEDURE app.spRatingTicket
	@ATicketID UNIQUEIDENTIFIER,
	@AScore TINYINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 	
		@TicketID UNIQUEIDENTIFIER = @ATicketID,
		@Score TINYINT = @AScore

	BEGIN TRY
		BEGIN TRAN
			
				UPDATE app.Ticket
				SET Score = @Score
				WHERE ID = @TicketID 
						
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END


