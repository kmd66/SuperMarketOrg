USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSubjectUsers'))
	DROP PROCEDURE app.spGetTicketSubjectUsers
GO

CREATE PROCEDURE app.spGetTicketSubjectUsers
	@ATicketSubjectID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@TicketSubjectID UNIQUEIDENTIFIER = @ATicketSubjectID,
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		COUNT(*) OVER() Total,
		ticksubusr.ID,
		us.ID UserID,
		us.FirstName + ' ' + us.LastName UserName,
		ticksubusr.TicketSubjectID,
		ticksub.[Name] SubjectName
	FROM 
		app.TicketSubjectUser ticksubusr
		LEFT JOIN org.[User] us ON us.ID = ticksubusr.UserID
		LEFT JOIN app.TicketSubject ticksub ON ticksub.ID = ticksubusr.TicketSubjectID
	WHERE 
		ticksubusr.TicketSubjectID = @TicketSubjectID
	ORDER BY 
		[Name]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END