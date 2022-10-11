USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyContactDetail'))
	DROP PROCEDURE app.spModifyContactDetail
GO

CREATE PROCEDURE app.spModifyContactDetail
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AContactInfoID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@AName NVARCHAR(200),
	@AValue NVARCHAR(1000),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ContactInfoID UNIQUEIDENTIFIER = @AContactInfoID,
		@Type TINYINT = COALESCE(@AType, 0),
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@Value NVARCHAR(1000) = LTRIM(RTRIM(@AValue)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ContactDetail
				(ID, ContactInfoID, Type, Name, [Value], CreationDate)
				VALUES
				(@ID, @ContactInfoID, @Type, @Name, @Value, GETDATE())
			END
			ELSE    -- update
			BEGIN
				UPDATE app.ContactDetail
				SET ContactInfoID = @ContactInfoID, Type = @Type, Name = @Name, Value = @Value
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
