USE [Kama.Mefa.Organization]
GO 

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyTicketSequence'))
	DROP PROCEDURE app.spModifyTicketSequence
GO

CREATE PROCEDURE app.spModifyTicketSequence
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@APositionID UNIQUEIDENTIFIER,
	@ATicketID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@AContent NVARCHAR(4000),
	@ALog NVARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 	
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@TicketID UNIQUEIDENTIFIER = @ATicketID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Content NVARCHAR(4000) = LTRIM(RTRIM(@AContent)),
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.TicketSequence 
					(ID, TicketID, UserID, Content, PositionID, CreationDate , ReadDate)
				VALUES
					(@ID, @TicketID, @UserID, @Content, @PositionID, GETDATE(), Null)
			END
			ELSE
			BEGIN
				UPDATE app.TicketSequence
				 SET TicketID= @TicketID, 
					 UserID = @UserID,
					 PositionID = @PositionID,
					 Content =  @Content
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
