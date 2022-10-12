USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spSetPositionTypeRoles'))
	DROP PROCEDURE org.spSetPositionTypeRoles
GO

CREATE PROCEDURE org.spSetPositionTypeRoles
	@AApplicationID UNIQUEIDENTIFIER,
	@APositionType TINYINT,
	@ARoleIDs NVARCHAR(MAX),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@PositionType TINYINT = @APositionType,
		@RoleIDs NVARCHAR(MAX) = LTRIM(RTRIM(@ARoleIDs)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Result INT = 0
	
	BEGIN TRY
		BEGIN TRAN
			
			DELETE FROM org.PositionTypeRole
			WHERE ApplicationID = @ApplicationID 
				AND PositionType = @PositionType
			
			INSERT INTO org.PositionTypeRole(ID, ApplicationID, PositionType, RoleID, CreationDate)
			SELECT NEWID() ID
				, @ApplicationID
				, @PositionType
				, ID RoleID
				, GETDATE()
			FROM OPENJSON(@RoleIDs)
			WITH(
				ID UNIQUEIDENTIFIER
			)

			SET @Result = @@ROWCOUNT

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @Result

END