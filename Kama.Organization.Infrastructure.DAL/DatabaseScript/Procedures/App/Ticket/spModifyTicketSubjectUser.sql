USE [Kama.Mefa.Organization]

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyTicketSubjectUser'))
	DROP PROCEDURE app.spModifyTicketSubjectUser
GO

CREATE PROCEDURE app.spModifyTicketSubjectUser
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@ATicketSubjectID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 	
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@TicketSubjectID UNIQUEIDENTIFIER = @ATicketSubjectID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.TicketSubjectUser 
					(ID, TicketSubjectID, UserID)
				VALUES
					(@ID, @TicketSubjectID, @UserID)
			END
			ELSE
			BEGIN
				UPDATE app.TicketSubjectUser
				 SET TicketSubjectID= @TicketSubjectID, 
					 UserID= @UserID
			     WHERE [ID]= @ID
			END

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END
