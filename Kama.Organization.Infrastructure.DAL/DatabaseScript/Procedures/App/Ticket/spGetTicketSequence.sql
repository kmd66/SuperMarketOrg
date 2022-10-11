USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSequence'))
	DROP PROCEDURE app.spGetTicketSequence
GO

CREATE PROCEDURE app.spGetTicketSequence
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		tickseq.ID,
		tickseq.TicketID,
		tickseq.UserID,
		tickseq.Content,
		us.FirstName + ' ' + us.LastName TicketSequenceUserName,
		tickseq.CreationDate,
		CONVERT(VARCHAR(20), tickseq.CreationDate, 108) AS TimePart,
		tickseq.ReadDate
	FROM app.TicketSequence tickseq
	LEFT JOIN org.[User] us ON us.ID = tickseq.UserID
	LEFT JOIN app.Ticket tick ON tick.ID = tickseq.TicketID
	WHERE tickseq.ID = @ID
END