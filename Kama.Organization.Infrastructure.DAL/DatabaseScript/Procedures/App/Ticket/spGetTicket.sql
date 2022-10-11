USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicket'))
	DROP PROCEDURE app.spGetTicket
GO

CREATE PROCEDURE app.spGetTicket
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		tick.ID,
		tick.SubjectID,
		tick.ApplicationID,
		tick.OwnerID,
		tick.Title,
		tick.Score,
		ticketSubject.[Name] SubjectTitle,
		ownerUser.FirstName + ' ' + ownerUser.LastName OwnerPositionName,
		creatorUser.FirstName + ' ' + creatorUser.LastName CreatorUserName,
		creatorUser.ID CreatorUserID,
		creatorPos.[Type] PositionType,
		creatorPos.ID CreatorPositionID,
		dep.[Name] DepartmentName,
		tick.[Priority],
		tick.TrackingCode,
		tick.[State],
		tick.CreationDate
	FROM app.Ticket tick
		LEFT JOIN org.[User] ownerUser ON ownerUser.ID = tick.OwnerID
		LEFT JOIN org.Position creatorPos ON creatorPos.ID = tick.CreatorPositionID
		LEFT JOIN org.[User] creatorUser ON creatorUser.ID = creatorPos.UserID
		LEFT JOIN org.Department dep ON dep.ID = creatorPos.DepartmentID
		LEFT JOIN app.TicketSubject ticketSubject ON ticketSubject.ID = tick.SubjectID
		LEFT JOIN app.TicketSubjectUser ticketSubjectUser ON ticketSubjectUser.TicketSubjectID = tick.SubjectID
	WHERE tick.ID = @ID
END