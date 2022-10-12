USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetFAQGroups'))
	DROP PROCEDURE app.spGetFAQGroups
GO

CREATE PROCEDURE app.spGetFAQGroups
	@AApplicationID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS (
	SELECT 
		Count(*) OVER() Total,
		faqGroup.ID,
		faqGroup.Title,
		faqGroup.ApplicationID,
		faqGroup.CreationDate,
		FAQGroup.CreatorID
	FROM app.FAQGroup faqGroup
	WHERE faqGroup.ApplicationID = @ApplicationID)

	SELECT * FROM MainSelect		 
	ORDER BY [ID]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
