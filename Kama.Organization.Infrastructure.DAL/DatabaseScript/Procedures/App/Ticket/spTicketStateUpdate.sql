USE [Kama.Mefa.Organization]
Go

IF EXISTS(SELECT 1 FROM sys.procedures where [object_id]= OBJECT_ID('app.spTicketStateUpdate'))
DROP PROCEDURE app.spTicketStateUpdate
GO

CREATE PROCEDURE app.spTicketStateUpdate  

WITH ENCRYPTION
AS

BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	BEGIN TRY
		BEGIN TRAN
			;WITH lastSequence AS (
				SELECT 
					TicketID,
					Max(CreationDate) AS maxDate
				FROM
					app.ticketsequence
				GROUP BY
					TicketID
				HAVING
					COUNT(*) > 1
			)

			UPDATE
				app.Ticket
			SET
				Ticket.[State] = 2
			FROM
				app.Ticket
				INNER JOIN app.TicketSequence ticketSequence
					ON ticket.ID = ticketSequence.TicketID
						AND ticketSequence.UserID = ticket.OwnerID
				INNER JOIN lastSequence
					ON lastSequence.TicketID = Ticket.ID
						AND TicketSequence.CreationDate = lastSequence.maxDate
			WHERE
				Ticket.[State] = 3
				AND ((SELECT DATEDIFF(DAY, ticketSequence.CreationDate , GETDATE()) AS DateDiff) > 5)
			COMMIT
		END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END

