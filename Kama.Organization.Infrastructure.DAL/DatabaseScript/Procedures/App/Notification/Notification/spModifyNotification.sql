USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyNotification'))
	DROP PROCEDURE app.spModifyNotification
GO

CREATE PROCEDURE app.spModifyNotification
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ASenderPositionID UNIQUEIDENTIFIER,
	@ATitle NVARCHAR(300),
	@AContent NVARCHAR(MAX),
	@AState TINYINT,
	@APriority TINYINT,
	@ALog NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE   
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@SenderPositionID UNIQUEIDENTIFIER = @ASenderPositionID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Content NVARCHAR(MAX) = @AContent,
		@Title NVARCHAR(MAX) = @ATitle,
		@State TINYINT = COALESCE(@AState, 0),
		@Priority TINYINT = COALESCE(@APriority, 0),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.[Notification]
				(ID, ApplicationID, SenderPositionID, Title, Content, [Priority], [State], CreationDate)
				VALUES
				(@ID, @ApplicationID, @SenderPositionID, @Title, @Content, @Priority, @State, GETDATE())
			END
			ELSE    -- update
			BEGIN
				UPDATE app.[Notification]
				SET ApplicationID = @ApplicationID, SenderPositionID = @SenderPositionID, Title = @Title, Content = @Content, [Priority] = @Priority, [State] = @State
				WHERE ID = @ID
			END
			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END