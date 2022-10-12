USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurveyQuestionChoice'))
	DROP PROCEDURE app.spModifyApplicationSurveyQuestionChoice
GO

CREATE PROCEDURE app.spModifyApplicationSurveyQuestionChoice
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AQuestionID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@AEnable BIT,
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
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@Enable BIT = @AEnable, 
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ApplicationSurveyQuestionChoice
				(ID, QuestionID, [Name])
				VALUES
				(@ID, @QuestionID, @Name)
			END
			ELSE
			BEGIN -- update
				UPDATE app.ApplicationSurveyQuestionChoice
				SET QuestionID = @QuestionID,
					[Name] = @Name
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