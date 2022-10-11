USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyNotificationCondition'))
	DROP PROCEDURE app.spModifyNotificationCondition
GO

CREATE PROCEDURE app.spModifyNotificationCondition
	@AID UNIQUEIDENTIFIER,
	@AIsNewRecord BIT,
	@ANotificationID UNIQUEIDENTIFIER,
	@ADepartmentID UNIQUEIDENTIFIER,
	@AProvinceID UNIQUEIDENTIFIER,
	@APositionType TINYINT,
	@APositionID UNIQUEIDENTIFIER,
	@ALog NVARCHAR
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = @AIsNewRecord,
		@ID UNIQUEIDENTIFIER = @AID,
		@NotificationID UNIQUEIDENTIFIER = @ANotificationID,
		@DepartmentID UNIQUEIDENTIFIER = @ADepartmentID,
		@ProvinceID UNIQUEIDENTIFIER = @AProvinceID,
		@PositionType TINYINT = COALESCE(@APositionType, 0),
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.NotificationCondition
				(ID, NotificationID, DepartmentID, ProvinceID, PositionType, PositionID)
				VALUES
				(@ID, @NotificationID, @DepartmentID, @ProvinceID, @PositionType, @PositionID)
			END
			ELSE    -- update
			BEGIN
				UPDATE app.NotificationCondition
				SET  NotificationID = @NotificationID, DepartmentID = @DepartmentID, ProvinceID = @ProvinceID, PositionType = @PositionType, PositionID = @PositionID
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