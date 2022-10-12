USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurveyQuestion'))
	DROP PROCEDURE app.spModifyApplicationSurveyQuestion
GO

CREATE PROCEDURE app.spModifyApplicationSurveyQuestion
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AGroupID UNIQUEIDENTIFIER,
	@AName NVARCHAR(1000),
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
		@GroupID UNIQUEIDENTIFIER = @AGroupID,
		@Name NVARCHAR(50)= LTRIM(RTRIM(@AName)),
		@Type TINYINT = COALESCE(@AType, 0),
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ApplicationSurveyQuestion
				(ID, GroupID, [Name], [Type], RemoverPositionID, RemoveDate)
				VALUES
				(@ID, @GroupID, @Name, @Type, null, null)
			END
			ELSE
			BEGIN -- update
				UPDATE app.ApplicationSurveyQuestion
				SET GroupID = @GroupID,
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