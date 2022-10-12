USE [Kama.Sm.Organization]
GO

IF OBJECT_ID('pbl.GetContentValue') IS NOT NULL
    DROP FUNCTION pbl.GetContentValue
GO

CREATE FUNCTION pbl.GetContentValue(@AKey VARCHAR(256))
RETURNS NVARCHAR(2000)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @Culture VARCHAR(5) = pbl.GetContextData('LANG') --LTRIM(RTRIM(@ACulture))
		  , @Key VARCHAR(256) = LTRIM(RTRIM(@AKey)) 
		  , @Value NVARCHAR(2000)

		  IF @Culture IS NULL OR @Culture = ''
			SEt @Culture = 'EN'

		  SET @Value = (SELECT TOP(1) v.[Value]
						FROM cnt.ContentValue v
						INNER JOIN cnt.[Language] l ON v.LanguageID = l.ID AND l.Culture = @Culture
						INNER JOIN cnt.Content c ON v.ContentID = c.ID AND c.[Key] = @Key)
		
	RETURN @Value
END