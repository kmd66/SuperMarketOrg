USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetMessageReceivers'))
DROP PROCEDURE app.spGetMessageReceivers
 GO 
 
 CREATE PROCEDURE  app.spGetMessageReceivers
	@AMessageID UNIQUEIDENTIFIER,
	@AMessageIDs NVARCHAR(MAX) 
WITH ENCRYPTION
AS

BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

DECLARE
	@MessageID UNIQUEIDENTIFIER = @AMessageID,
	@MessageIDs NVARCHAR(MAX) = LTRIM(RTRIM(@AMessageIDs))

	BEGIN TRY
		BEGIN TRAN

			;WITH [Message] AS
			(
				SELECT value ID
				FROM OPENJSON(@MessageIDs)
			)
			SELECT
				r.[ID], 
				r.[ReceiverUserID], 
				r.[MessageID], 
				r.[IsRemoved], 
				r.[Seen],
				r.ReceiverUserID,
				u.FirstName + ' ' + u.LastName  ReceiverUserFullName
			FROM
				app.MessageReceivers r
				INNER JOIN org.[User] u ON u.ID = r.ReceiverUserID
			WHERE
				(@MessageID IS NULL OR MessageID = @MessageID)
				AND (@MessageIDs IS NULL OR MessageID in (select ID from [Message]))

		COMMIT
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END


