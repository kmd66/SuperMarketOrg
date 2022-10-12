USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyDynamicPermission'))
	DROP PROCEDURE org.spModifyDynamicPermission
GO

CREATE PROCEDURE org.spModifyDynamicPermission
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AObjectID UNIQUEIDENTIFIER,
	@AOrder INT,
	@ADetails NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@ObjectID UNIQUEIDENTIFIER = @AObjectID,
		@Order INT = @AOrder,
		@Details NVARCHAR(MAX) = @ADetails 

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.DynamicPermission
				(ID, ApplicationID, ObjectID, [Order], CreationDate)
				VALUES
				(@ID, @ApplicationID, @ObjectID, @Order, GETDATE())
			END
			ELSE    -- update
			BEGIN
				UPDATE org.DynamicPermission
				SET ObjectID = @ObjectID, [Order] = @Order
				WHERE ID = @ID
			END

			---------------------------------------------------------- Details
			DELETE org.DynamicPermissionDetail WHERE DynamicPermissionID = @ID

			INSERT INTO org.DynamicPermissionDetail 
			SELECT 
				NEWID() ID,
				@ID DynamicPermissionID,
				[Type],
				GuidValue,
				ByteValue
			FROM OPENJSON(@Details)
			WITH
			(
				[Type] TINYINT,
				GuidValue UNIQUEIDENTIFIER,
				ByteValue TINYINT
			)

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
