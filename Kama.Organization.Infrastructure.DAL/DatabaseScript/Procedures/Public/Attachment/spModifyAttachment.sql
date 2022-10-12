USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spModifyAttachment'))
	DROP PROCEDURE pbl.spModifyAttachment
GO

CREATE PROCEDURE pbl.spModifyAttachment
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@AFileName NVARCHAR(256),
	@AComment NVARCHAR(256),
	@AData VARBINARY(MAX),
	@AIsUnique BIT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Type TINYINT = COALESCE(@AType, 0),
		@FileName NVARCHAR(256) = LTRIM(RTRIM(@AFileName)),
		@Comment NVARCHAR(256) = LTRIM(RTRIM(@AComment)),
		@Data VARBINARY(MAX) = @AData,
		@IsUnique BIT = COALESCE(@AIsUnique, 1),
		@Log NVARCHAR(MAX)

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN

				IF @IsUnique = 1
				BEGIN
					DELETE pbl.Attachment
					WHERE ParentID = @ParentID
						AND [Type] = @Type
				END

				INSERT INTO pbl.Attachment
				(ID, ParentID, [Type], [FileName], [Data])
				VALUES
				(@ID, @ParentID, @Type, @FileName, @Data)
			END
			ELSE
			BEGIN
				UPDATE pbl.Attachment
				SET [FileName] = @FileName, [Data] = @Data
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