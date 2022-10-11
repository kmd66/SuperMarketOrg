USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTicketSequences'))
	DROP PROCEDURE app.spGetTicketSequences
GO

CREATE PROCEDURE app.spGetTicketSequences
	@ATicketID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@AContent NVARCHAR(4000),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000),
	@ACurrentPositionID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@TicketID UNIQUEIDENTIFIER = @ATicketID,
		@UserID  UNIQUEIDENTIFIER = @AUserID,
		@Content NVARCHAR(4000) = LTRIM(RTRIM(@AContent)),
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		COUNT(*) OVER() Total,
		tickseq.ID,
		tickseq.TicketID,
		tickseq.ReadDate,
		tickseq.UserID,
		tickseq.Content,
		dep.[Name] DepartmentName,
		pos.[Type] PositionType,
		us.FirstName + ' ' + us.LastName TicketSequenceUserName,
		attachment.ID AttachmentID,
		CONVERT(VARCHAR(20), tickseq.CreationDate, 108) AS TimePart,
		tickseq.CreationDate
	FROM app.TicketSequence tickseq
	LEFT JOIN pbl.Attachment attachment ON attachment.ParentID = tickseq.ID
	LEFT JOIN org.[User] us ON us.ID = tickseq.UserID
	LEFT JOIN org.Position pos ON pos.ID = tickseq.PositionID
	LEFT JOIN org.Department dep ON dep.ID = pos.DepartmentID  
	LEFT JOIN app.Ticket tick ON tick.ID = tickseq.TicketID
	WHERE tickseq.TicketID = @TicketID
		
	ORDER BY [CreationDate]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END