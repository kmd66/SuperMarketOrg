USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetFAQGroup'))
	DROP PROCEDURE app.spGetFAQGroup
GO

CREATE PROCEDURE app.spGetFAQGroup
	  @AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	 DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
	faqGroup.*
	FROM app.FAQGroup faqGroup
	WHERE faqGroup.ID = @ID
	ORDER BY faqGroup.CreationDate ASC

END
