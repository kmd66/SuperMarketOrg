USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spDeleteApplicationSurveyQuestion'))
	DROP PROCEDURE app.spDeleteApplicationSurveyQuestion
GO

CREATE PROCEDURE app.spDeleteApplicationSurveyQuestion
	@AID UNIQUEIDENTIFIER,
	@ACurrentPositionID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@ID UNIQUEIDENTIFIER = @AID,
		@CurrentPositionID UNIQUEIDENTIFIER = @ACurrentPositionID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))
	
	BEGIN TRY
		BEGIN TRAN
			
			UPDATE app.ApplicationSurveyQuestion
			SET RemoverPositionID = @CurrentPositionID
				, RemoveDate = GETDATE()
			WHERE ID = @ID

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END