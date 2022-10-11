USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContactDetails'))
DROP PROCEDURE app.spGetContactDetails
GO

CREATE PROCEDURE app.spGetContactDetails
	@AContactInfoIDs NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ContactInfoIDs NVARCHAR(MAX) = @AContactInfoIDs

	;WITH ContactInfoIDs AS
	(
		SELECT jsonResult.[value] ID
		FROM OPENJSON(@ContactInfoIDs) AS jsonResult
	)
	, MainSelect AS
	(
		SELECT
			ContactDetail.ID,
			ContactDetail.ContactInfoID,
			ContactDetail.Type,
			ContactDetail.Name,
			ContactDetail.Value
		FROM app.ContactDetail
		INNER JOIN ContactInfoIDs ON ContactInfoIDs.ID = ContactDetail.ContactInfoID
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY ID
END
