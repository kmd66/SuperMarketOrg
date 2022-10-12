USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyFAQGroup'))
	DROP PROCEDURE app.spModifyFAQGroup
GO

CREATE PROCEDURE app.spModifyFAQGroup
	  @AIsNewRecord BIT
	, @AID UNIQUEIDENTIFIER
	, @AApplicationID UNIQUEIDENTIFIER
	, @ATitle NVARCHAR(500)
	, @AUserID UNIQUEIDENTIFIER
	, @ALog NVARCHAR(MAX)
	, @AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	 DECLARE @IsNewRecord BIT = ISNULL(@AIsNewRecord, 0)
	    , @ID UNIQUEIDENTIFIER = @AID
		, @ApplicationID UNIQUEIDENTIFIER = @AApplicationID
		, @UserID UNIQUEIDENTIFIER = @AUserID
		, @Title NVARCHAR(500) = @ATitle 
		, @Log NVARCHAR(MAX) = @ALog
	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
			
				INSERT INTO APP.FAQGroup
				(ID, Title, ApplicationID, CreationDate, CreatorID)
				VALUES
				(@ID, @Title, @ApplicationID, GETDATE(), @UserID)
			END
			ELSE 
			BEGIN -- update
				UPDATE APP.FAQGroup
				SET Title = @Title, ApplicationID = @ApplicationID
				WHERE ID = @ID
			END

			SET @AResult = @@ROWCOUNT

			EXEC pbl.spAddLog @Log
		COMMIT

		RETURN @@ROWCOUNT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
