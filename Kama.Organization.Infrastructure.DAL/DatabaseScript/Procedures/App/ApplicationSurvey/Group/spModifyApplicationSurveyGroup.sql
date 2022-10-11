USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurveyGroup'))
	DROP PROCEDURE app.spModifyApplicationSurveyGroup
GO

CREATE PROCEDURE app.spModifyApplicationSurveyGroup
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationSurveyID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationSurveyID UNIQUEIDENTIFIER = @AApplicationSurveyID,
		@Name NVARCHAR(50)= LTRIM(RTRIM(@AName)),
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ApplicationSurveyGroup
				(ID, ApplicationSurveyID, [Name])
				VALUES
				(@ID, @ApplicationSurveyID, @Name)
			END
			ELSE
			BEGIN -- update
				UPDATE app.ApplicationSurveyGroup
				SET [Name] = @Name
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