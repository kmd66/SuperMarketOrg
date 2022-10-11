USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spSetNotificationPositionFromCondition'))
	DROP PROCEDURE app.spSetNotificationPositionFromCondition
GO

CREATE PROCEDURE app.spSetNotificationPositionFromCondition
	@AApplicationID UNIQUEIDENTIFIER,
	@AConditionID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@ConditionID UNIQUEIDENTIFIER = @AConditionID,
		@NotificationID UNIQUEIDENTIFIER,
		@DepartmentID UNIQUEIDENTIFIER,
		@PositionType TINYINT,
		@ProvinceID UNIQUEIDENTIFIER

	SELECT 
		@NotificationID = NotificationID,
		@DepartmentID = DepartmentID,
		@PositionType = PositionType,
		@ProvinceID = ProvinceID
	FROM app.NotificationCondition
	WHERE ID = @ConditionID
			
	BEGIN TRY
		BEGIN TRAN
				
			INSERT INTO app.NotificationPosition
			(ID, NotificationID, PositionID)
			SELECT Distinct
				NEWID() ID, 
				@NotificationID,
				position.ID PositionID
			FROM Org.Position
				INNER JOIN org.Department ON Department.ID = Position.DepartmentID
			WHERE ApplicationID = @ApplicationID
				AND (@DepartmentID IS NULL OR Position.DepartmentID = @DepartmentID)
				AND (@PositionType < 1 OR Position.Type = @PositionType)
				AND (@ProvinceID IS NULL OR Department.ProvinceID = @ProvinceID)
				AND NOT EXISTS (SELECT TOP 1 1 FROM app.NotificationPosition WHERE PositionID = Position.ID)
			 
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END						
									
									
		
		
		
			

