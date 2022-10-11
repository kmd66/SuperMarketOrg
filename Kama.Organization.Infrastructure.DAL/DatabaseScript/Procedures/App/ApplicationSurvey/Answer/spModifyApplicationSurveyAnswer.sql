USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurveyAnswer'))
	DROP PROCEDURE app.spModifyApplicationSurveyAnswer
GO

CREATE PROCEDURE app.spModifyApplicationSurveyAnswer
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AQuestionID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@QuestionID UNIQUEIDENTIFIER = @AQuestionID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Type TINYINT = @AType,
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.[ApplicationSurveyAnswer]
				(ID, QuestionID, UserID, [Date], [Type])
				VALUES
				(@ID, @QuestionID, @UserID, GETDATE(), @Type)
			END
			ELSE
			BEGIN 
				UPDATE app.[ApplicationSurveyAnswer]
				SET [Type] = @Type
				WHERE ID = @ID
			END

			--EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END