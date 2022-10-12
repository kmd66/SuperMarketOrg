USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyPositionHistory'))
	DROP PROCEDURE org.spModifyPositionHistory
GO

CREATE PROCEDURE org.spModifyPositionHistory
    @AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@APositionID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER, 
	@ALetterNumber NVARCHAR(250), 
	@ADate SMALLDATETIME,
	@AComment NVARCHAR(4000),
	@ACreatorUserID UNIQUEIDENTIFIER,
	@ACreatorPositionID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@UserID UNIQUEIDENTIFIER = @AUserID, 
		@LetterNumber NVARCHAR(250) = LTRIM(RTRIM(@ALetterNumber)), 
		@Date SMALLDATETIME = @ADate,
		@Comment NVARCHAR(4000) = LTRIM(RTRIM(@AComment)),
		@CreatorUserID UNIQUEIDENTIFIER = @ACreatorUserID,
		@CreatorPositionID UNIQUEIDENTIFIER = @ACreatorPositionID,
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert 
			BEGIN

				UPDATE [org].[PositionHistory]
				SET [IsEndUser] = 0
				WHERE [PositionID] = @PositionID

				INSERT INTO [org].[PositionHistory]
					([ID], [PositionID], [UserID], [LetterNumber], [Date], [Comment], [CreationDate], [IsEndUser], [CreatorUserID], [CreatorPositionID])
				VALUES
					(@ID, @PositionID, @UserID, @LetterNumber, @Date, @Comment, GETDATE(), 1, @CreatorUserID, @CreatorPositionID)
			END
			ELSE -- update
			BEGIN
				UPDATE [org].[PositionHistory]
				SET
					[LetterNumber] = @LetterNumber,
					[Date] = @Date, 
					[Comment] = @Comment
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
