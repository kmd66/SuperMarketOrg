USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurveyParticipant'))
	DROP PROCEDURE app.spModifyApplicationSurveyParticipant
GO

CREATE PROCEDURE app.spModifyApplicationSurveyParticipant
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@ASurveyID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@SurveyID UNIQUEIDENTIFIER = @ASurveyID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ApplicationSurveyParticipant
				(ID, SurveyID, UserID, [Date])
				VALUES
				(@ID, @SurveyID, @UserID, GETDATE())
			END
			ELSE
			BEGIN -- update
				UPDATE app.ApplicationSurveyParticipant
				SET SurveyID = @SurveyID,
					UserID = @UserID,
					[Date] = GETDATE()
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