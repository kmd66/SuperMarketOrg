USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spDeleteTicketSequence'))
	DROP PROCEDURE app.spDeleteTicketSequence
GO

CREATE PROCEDURE app.spDeleteTicketSequence
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
			DELETE FROM app.TicketSequence 
			WHERE ID = @ID
		END	
		 TRY
	BEGIN CATCH
		;THROW
	END CATCH
	RETURN @@ROWCOUNT
END