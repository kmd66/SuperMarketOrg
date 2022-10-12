USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContactInfos'))
DROP PROCEDURE app.spGetContactInfos
GO

CREATE PROCEDURE app.spGetContactInfos
	@AParentID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ParentID UNIQUEIDENTIFIER = @AParentID

	;WITH MainSelect AS
	(
		SELECT
			ContactInfo.ID,
			ContactInfo.ParentID,
			ContactInfo.Name,
			ContactInfo.[Order]
		FROM app.ContactInfo
		WHERE ContactInfo.ParentID = @ParentID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY ID
END
