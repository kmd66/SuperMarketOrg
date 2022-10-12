USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveys'))
	DROP PROCEDURE app.spGetApplicationSurveys
GO

CREATE PROCEDURE app.spGetApplicationSurveys
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
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
			survey.ID,
			survey.ApplicationID,
			survey.[Name],
			survey.[Enable],
			survey.CreationDate
		FROM app.ApplicationSurvey as survey
		WHERE survey.ApplicationID = @ApplicationID
			AND survey.RemoverPositionID is null
			AND (@Name IS NULL OR survey.[Name] LIKE CONCAT('%', @Name, '%'))
	)

	SELECT * FROM MainSelect		 
	ORDER BY [CreationDate] desc
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END