USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSubjects'))
	DROP PROCEDURE app.spGetTicketSubjects
GO

CREATE PROCEDURE app.spGetTicketSubjects
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@AEnable TINYINT,
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
		@Enable TINYINT = COALESCE(@AEnable, 0),
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		COUNT(*) OVER() Total,
		ticksub.ID,
		ticksub.[Name],
		ticksub.[Enable],
		ticksub.Type

	FROM app.TicketSubject ticksub
	WHERE ticksub.ApplicationID = @ApplicationID
	AND (@Enable < 1 OR ticksub.[Enable] = @Enable - 1)
	ORDER BY [Name]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END