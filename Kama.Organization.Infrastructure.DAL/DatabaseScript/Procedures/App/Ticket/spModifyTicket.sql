USE [Kama.Mefa.Organization]

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyTicket'))
	DROP PROCEDURE app.spModifyTicket
GO

CREATE PROCEDURE app.spModifyTicket
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ASubjectID UNIQUEIDENTIFIER,
	@AState TINYINT,
	@ATrackingCode NVARCHAR(50),
	@APriority TINYINT,
	@ATitle NVARCHAR(200),
	@APositionID UNIQUEIDENTIFIER,
	@AOwnerID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 	
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@SubjectID UNIQUEIDENTIFIER = @ASubjectID,
		@State TINYINT = COALESCE(@AState, 0),
		@TrackingCode NVARCHAR(50) = LTRIM(RTRIM(@ATrackingCode)),
		@Priority TINYINT = COALESCE(@APriority, 0),
		@Title NVARCHAR(200) = LTRIM(RTRIM(@ATitle)),
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@OwnerID UNIQUEIDENTIFIER = @AOwnerID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1 -- insert
			BEGIN
			SET  @TrackingCode = (SELECT dbo.fnTicketNumber())
				INSERT INTO app.Ticket 
					(ID, ApplicationID, SubjectID, [State], TrackingCode , [Priority] , [Title] , CreatorPositionID , OwnerID, CreationDate)
				VALUES
					(@ID, @ApplicationID, @SubjectID, 1, @TrackingCode, @Priority, @Title, @PositionID, NULL , GETDATE())
			END
			ELSE
			BEGIN
				UPDATE app.Ticket
				 SET SubjectID= @SubjectID, 
					 [State]= @State, 
					 [Title]= @Title, 
					 OwnerID= @OwnerID
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
