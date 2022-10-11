USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spMapDepartmentsToPosition'))
	DROP PROCEDURE org.spMapDepartmentsToPosition
GO

CREATE PROCEDURE org.spMapDepartmentsToPosition
	@AApplicationID UNIQUEIDENTIFIER,
	@APositionType TINYINT,
	@AMappings NVARCHAR(MAX),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@PositionType TINYINT = COALESCE(@APositionType, 0),
		@Mappings NVARCHAR(MAX) = LTRIM(RTRIM(@AMappings)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			DELETE org.PositionDepartmentMapping
			WHERE ApplicationID = @ApplicationID
				AND PositionType = @PositionType

			INSERT INTO org.PositionDepartmentMapping
				(ID, ApplicationID, PositionType, DepartmentType, MaxUsersCount, CreationDate)
			SELECT 
				NEWID() ID, 
				@ApplicationID,
				@PositionType, 
				DepartmentType, 
				MaxUsersCount, 
				GETDATE()
			FROM OPENJSON(@Mappings)
			WITH(
				DepartmentType TINYINT,
				MaxUsersCount INT
			)

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
