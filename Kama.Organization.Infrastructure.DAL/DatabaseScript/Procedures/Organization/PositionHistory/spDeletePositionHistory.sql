﻿USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spDeletePositionHistory'))
DROP PROCEDURE org.spDeletePositionHistory
GO

CREATE PROCEDURE org.spDeletePositionHistory
	@AID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		  @ID UNIQUEIDENTIFIER = @AID,
		  @Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			DELETE FROM [org].[PositionHistory]
			WHERE ID = @ID

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
