﻿USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spDeleteTicket'))
	DROP PROCEDURE app.spDeleteTicket
GO

CREATE PROCEDURE app.spDeleteTicket
	@AID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ID UNIQUEIDENTIFIER = @AID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF EXISTS (SELECT TOP 1 1 FROM  app.Ticket WHERE ID = @ID AND OwnerID IS NOT NULL)
				THROW 50000, N'این تیکت پاسخ داده شده است بنابراین امکان حذف تیکت وجود ندارد.', 1

			DELETE FROM app.TicketSequence
			WHERE TicketID = @ID

			DELETE FROM app.Ticket 
			WHERE ID = @ID
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	RETURN @@ROWCOUNT
END