USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetFAQs'))
	DROP PROCEDURE app.spGetFAQs
GO

CREATE PROCEDURE app.spGetFAQs
	@AApplicationID UNIQUEIDENTIFIER,
	@AFAQGroupID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@FAQGroupID UNIQUEIDENTIFIER = @AFAQGroupID,
		@PageSize INT = COALESCE(@APageSize,10),
		@PageIndex INT = COALESCE(@APageIndex, 0)
	
	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS (
	SELECT 
		Count(*) OVER() Total,
		faq.ID,
		faqGroup.Title,
		faqGroup.ApplicationID,
		faq.FAQGroupID,
		faq.Question,
		faq.Answer,
		faq.CreationDate,
		faq.CreatorID
	FROM app.FAQ faq
	INNER JOIN app.FAQGroup faqGroup on faqGroup.ID = faq.FAQGroupID
	WHERE faqGroup.ApplicationID = @ApplicationID
			AND (@FAQGroupID is null or faq.FAQGroupID = @FAQGroupID))

	SELECT * FROM MainSelect		 
	ORDER BY [ID]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
