USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spSetDefaultPosition'))
	DROP PROCEDURE org.spSetDefaultPosition
GO

CREATE PROCEDURE org.spSetDefaultPosition
	@APositionID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@UserID UNIQUEIDENTIFIER,
		@ApplicationID UNIQUEIDENTIFIER,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	SELECT @UserID = UserID,
		@ApplicationID = ApplicationID
	FROM org.Position
	WHERE ID = @PositionID

	BEGIN TRY
		BEGIN TRAN

			UPDATE org.Position
			SET [Default] = 0
			WHERE UserID = @UserID
				AND ApplicationID = @ApplicationID

			UPDATE org.Position
			SET [Default] = 1,
				LastTokenDate = GETDATE()
			WHERE ID = @PositionID

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END