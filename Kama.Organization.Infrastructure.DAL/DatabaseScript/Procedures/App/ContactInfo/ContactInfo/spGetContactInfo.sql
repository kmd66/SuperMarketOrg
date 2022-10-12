USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContactInfo'))
	DROP PROCEDURE app.spGetContactInfo
GO

CREATE PROCEDURE app.spGetContactInfo
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		ContactInfo.ID,
		ContactInfo.ParentID,
		ContactInfo.Name,
		ContactInfo.[Order]
	FROM app.ContactInfo
	WHERE ID = @ID
END
