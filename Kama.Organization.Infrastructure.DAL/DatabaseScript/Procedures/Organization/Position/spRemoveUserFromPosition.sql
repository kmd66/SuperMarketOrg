USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spRemoveUserFromPosition'))
	DROP PROCEDURE org.spRemoveUserFromPosition
GO

CREATE PROCEDURE org.spRemoveUserFromPosition
	@APositionID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @PositionID UNIQUEIDENTIFIER = @APositionID
		, @Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			UPDATE org.Position
			SET UserID = NULL
			WHERE ID = @PositionID

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END