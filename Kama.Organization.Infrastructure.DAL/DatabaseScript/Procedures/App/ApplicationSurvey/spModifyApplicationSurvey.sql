USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyApplicationSurvey'))
	DROP PROCEDURE app.spModifyApplicationSurvey
GO

CREATE PROCEDURE app.spModifyApplicationSurvey
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
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
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(50)= LTRIM(RTRIM(@AName)),
		@Enable BIT = @AEnable, 
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ApplicationSurvey
				(ID, ApplicationID, [Name], [Enable], CreationDate, RemoverPositionID, RemoveDate)
				VALUES
				(@ID, @ApplicationID, @Name, @Enable, GETDATE(), null, null)
			END
			ELSE
			BEGIN -- update
				UPDATE app.ApplicationSurvey
				SET [Name] = @Name,
					[Enable] = @Enable
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