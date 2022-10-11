USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spMapPositionsToDepartment'))
	DROP PROCEDURE org.spMapPositionsToDepartment
GO

CREATE PROCEDURE org.spMapPositionsToDepartment
	@AApplicationID UNIQUEIDENTIFIER,
	@ADepartmentType TINYINT,
	@AMappings NVARCHAR(MAX),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@DepartmentType TINYINT = COALESCE(@ADepartmentType, 0),
		@Mappings NVARCHAR(MAX) = LTRIM(RTRIM(@AMappings)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			DELETE org.PositionDepartmentMapping
			WHERE ApplicationID = @ApplicationID
				AND DepartmentType = @DepartmentType

			INSERT INTO org.PositionDepartmentMapping
				(ID, ApplicationID, PositionType, DepartmentType, MaxUsersCount, CreationDate)
			SELECT 
				NEWID() ID, 
				@ApplicationID,
				PositionType, 
				@DepartmentType, 
				MaxUsersCount, 
				GETDATE()
			FROM OPENJSON(@Mappings)
			WITH(
				PositionType TINYINT,
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
