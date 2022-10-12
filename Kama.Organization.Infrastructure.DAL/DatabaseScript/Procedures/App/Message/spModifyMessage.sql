USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyMessage'))
	DROP PROCEDURE app.spModifyMessage
GO

CREATE PROCEDURE app.spModifyMessage
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ASenderUserID UNIQUEIDENTIFIER,
	@AContent NVARCHAR(MAX),
	@ATitle NVARCHAR(300),
	@AParentID UNIQUEIDENTIFIER,
	@AReceiverUserIDs NVARCHAR(MAX),
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
		@SenderUserID UNIQUEIDENTIFIER = @ASenderUserID,
		@Content NVARCHAR(MAX) = @AContent,
		@Title NVARCHAR(300) = LTRIM(RTRIM(@ATitle)),
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@IsRemoved BIT = 0,
		@IsSent BIT = 0,
		@ReceiverUserIDs NVARCHAR(MAX) = @AReceiverUserIDs,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.[Message] 
					(ID, ApplicationID, SenderUserID, [Content], [Title], ParentID, IsRemoved, IsSent, creationDate)
				VALUES
					(@ID, @ApplicationID, @SenderUserID, @Content, @Title, @ParentID, @IsRemoved, @IsSent, GETDATE())
			END
			ELSE
			BEGIN
				UPDATE app.[Message]
				 SET ApplicationID= @ApplicationID, 
					 [SenderUserID]= @SenderUserID, 
					 [Content]= @Content, 
					 [Title]= @Title,
					 ParentID= @ParentID, 
					 IsRemoved= @IsRemoved, 
					 IsSent= @IsSent, 
					 creationDate= GETDATE()

			     WHERE [ID]= @ID
			END

			DELETE FROM app.MessageReceivers
			WHERE MessageID = @ID

			INSERT INTO app.MessageReceivers
				([ID] , [MessageID], ReceiverUserID, [IsRemoved], [Seen])
			SELECT NEWID() ID,
				@ID MessageID,
				VALUE ReceiverUserID,
				0 IsRemoved,
				0 Seen
			FROM OPENJSON(@ReceiverUserIDs)

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END