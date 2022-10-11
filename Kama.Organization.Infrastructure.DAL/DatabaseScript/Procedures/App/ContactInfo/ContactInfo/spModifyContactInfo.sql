USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyContactInfo'))
	DROP PROCEDURE app.spModifyContactInfo
GO

CREATE PROCEDURE app.spModifyContactInfo
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@AOrder INT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@Order INT = COALESCE(@AOrder, 1),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.ContactInfo
				(ID, ParentID, [Name], [Order], CreationDate)
				VALUES
				(@ID, @ParentID, @Name, @Order, GETDATE())
			END
			ELSE    -- update
			BEGIN
				UPDATE app.ContactInfo
				SET ParentID = @ParentID, [Name] = @Name, [Order] = @Order
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
