USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyFAQ'))
	DROP PROCEDURE app.spModifyFAQ
GO

CREATE PROCEDURE app.spModifyFAQ
	  @AIsNewRecord BIT
	, @AID UNIQUEIDENTIFIER
	, @AFAQGroupID UNIQUEIDENTIFIER
	, @AQuestion nvarchar(500)
	, @AAnswer nvarchar(500)
	, @AUserID uniqueidentifier
	, @ALog NVARCHAR(MAX)
	, @AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	 DECLARE 
		  @IsNewRecord BIT = @AIsNewRecord 
		, @ID UNIQUEIDENTIFIER = @AID
		, @FAQGroupID UNIQUEIDENTIFIER = @AFAQGroupID
		, @Question nvarchar(500) = @AQuestion
		, @Answer nvarchar(500) = @AAnswer
		, @UserID uniqueidentifier = @AUserID
		, @Log NVARCHAR(MAX) = @ALog
	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
			
				INSERT INTO APP.FAQ
				(ID, FAQGroupID, Answer, Question, CreationDate, CreatorID)
				VALUES
				(@ID, @FAQGroupID, @Answer, @Question, GETDATE(), @UserID)
			END
			ELSE 
			BEGIN -- update
				UPDATE APP.FAQ
				SET FAQGroupID = @FAQGroupID, Answer = @Answer, Question = @Question
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
