USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContactDetail'))
	DROP PROCEDURE app.spGetContactDetail
GO

CREATE PROCEDURE app.spGetContactDetail
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
		ContactDetail.ID,
		ContactDetail.ContactInfoID,
		ContactDetail.Type,
		ContactDetail.Name,
		ContactDetail.Value
	FROM app.ContactDetail
	WHERE ID = @ID
END
