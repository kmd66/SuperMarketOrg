USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyApplication'))
	DROP PROCEDURE org.spModifyApplication
GO

CREATE PROCEDURE org.spModifyApplication
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@ACode VARCHAR(20),
	@AName NVARCHAR(256),
	@AEnabled BIT,
	@AComment NVARCHAR(256),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	 DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
	    @ID UNIQUEIDENTIFIER = @AID,
		@Code VARCHAR(20) = LTRIM(RTRIM(@ACode)),
		@Name NVARCHAR(256) = LTRIM(RTRIM(@AName)),
		@Enabled BIT = ISNULL(@AEnabled, 0),
		@Comment NVARCHAR(256) = LTRIM(RTRIM(@AComment)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.[Application]
				(ID, Code, [Name], [Enabled], Comment)
				VALUES
				(@ID, @Code, @Name, @Enabled, @Comment)
			END
			ELSE 
			BEGIN -- update
				UPDATE org.[Application]
				SET Code = @Code, [Name] = @Name, [Enabled] = @Enabled, Comment = @Comment
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
