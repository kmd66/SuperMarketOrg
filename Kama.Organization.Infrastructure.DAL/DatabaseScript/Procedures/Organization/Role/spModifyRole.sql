USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyRole'))
	DROP PROCEDURE org.spModifyRole
GO

CREATE PROCEDURE org.spModifyRole
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(50),
	@APermissions NVARCHAR(MAX),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(50)= LTRIM(RTRIM(@AName)),
		@Permissions NVARCHAR(MAX) = LTRIM(RTRIM(@APermissions)),
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				--SET @ID = COALESCE((SELECT MAX(ID) FROM org.[User]), 0) + 1

				INSERT INTO org.[Role]
				(ID, ApplicationID, [Name])
				VALUES
				(@ID, @ApplicationID, @Name)
			END
			ELSE
			BEGIN -- update
				UPDATE org.[Role]
				SET [Name] = @Name
				WHERE ID = @ID
			END

			-- set permissions
			DELETE FROM org.RolePermission
			WHERE RoleID = @ID
			
			INSERT INTO org.RolePermission
			SELECT NEWID() ID,
				@ID RoleId,
				CommandID ID
			FROM OPENJSON(@Permissions)
			WITH(
				CommandID UNIQUEIDENTIFIER
			)

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END