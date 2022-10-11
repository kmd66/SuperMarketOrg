USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSubjectUser'))
	DROP PROCEDURE app.spGetTicketSubjectUser
GO

CREATE PROCEDURE app.spGetTicketSubjectUser
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		ticksubusr.ID,
		us.FirstName + ' ' + us.LastName UserName,
		ticksub.[Name] SubjectName,
		Type
	FROM app.TicketSubjectUser ticksubusr
	LEFT JOIN org.[User] us ON us.ID = ticksubusr.UserID
	LEFT JOIN app.TicketSubject ticksub ON ticksub.ID = ticksubusr.TicketSubjectID
	WHERE ticksubusr.ID = @ID
END