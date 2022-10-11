USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spSetTicketSequenceReadDate'))
	DROP PROCEDURE app.spSetTicketSequenceReadDate
GO

CREATE PROCEDURE app.spSetTicketSequenceReadDate
	@AID UNIQUEIDENTIFIER,
	@ACurrentUserPositionID UNIQUEIDENTIFIER,
	@AReadDate SMALLDATETIME,
    @ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ID UNIQUEIDENTIFIER = @AID,
		@CurrentUserPositionID UNIQUEIDENTIFIER = @ACurrentUserPositionID,
		@ReadDate SMALLDATETIME = @AReadDate,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

		;WITH LastTicketSequence AS (
			SELECT
				TicketID,
				UserID,
				PositionID,
				ReadDate,[Content],
				Max(CreationDate) AS maxDate
			FROM app.TicketSequence
			GROUP BY TicketID ,UserID , PositionID , ReadDate , [Content]
		) 

		UPDATE TicketSequence
		SET ReadDate = GETDATE()
		FROM app.TicketSequence TicketSequence
			INNER JOIN LastTicketSequence ON LastTicketSequence.TicketID = TicketSequence.TicketID
		WHERE TicketSequence.TicketID = @ID
			AND LastTicketSequence.PositionID <> @CurrentUserPositionID 
			
			EXEC pbl.spAddLog @Log

		COMMIT

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

END