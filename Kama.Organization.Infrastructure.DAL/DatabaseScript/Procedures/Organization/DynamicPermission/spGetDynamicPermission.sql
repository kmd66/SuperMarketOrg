USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetDynamicPermission'))
	DROP PROCEDURE org.spGetDynamicPermission
GO

CREATE PROCEDURE org.spGetDynamicPermission
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		DynamicPermission.ID,
		DynamicPermission.ObjectID,
		DynamicPermission.CreationDate,
		DynamicPermission.[Order]
	FROM org.DynamicPermission
	WHERE ID = @ID
END
