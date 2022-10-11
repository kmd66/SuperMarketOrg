USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSubject'))
	DROP PROCEDURE app.spGetTicketSubject
GO

CREATE PROCEDURE app.spGetTicketSubject
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		ID,
		[Name],
		[Enable],
		Type
	FROM app.TicketSubject
	WHERE ID = @ID
END