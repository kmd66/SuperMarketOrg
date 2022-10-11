USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spTicketReport'))
	DROP PROCEDURE app.spTicketReport
GO

CREATE PROCEDURE app.spTicketReport
	@AApplicationID UNIQUEIDENTIFIER,
	@ASubjectID UNIQUEIDENTIFIER,
	@AState TINYINT,
	@AScore TINYINT,
	@ATrackingCode NVARCHAR(50),
	@APriority TINYINT,
	@ADepartmentID UNIQUEIDENTIFIER,
	@ATitle NVARCHAR(200),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000),
	@ACurrentUserID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@SubjectID UNIQUEIDENTIFIER = @ASubjectID,
		@State TINYINT = COALESCE(@AState, 0),
		@Score TINYINT = COALESCE(@AScore, 0),
		@TrackingCode NVARCHAR(50) = LTRIM(RTRIM(@ATrackingCode)),
		@Priority TINYINT = COALESCE(@APriority, 0),
		@DepartmentID UNIQUEIDENTIFIER = @ADepartmentID,
		@Title NVARCHAR(200) = LTRIM(RTRIM(@ATitle)),
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END


	;WITH Ticketlist AS
	 (SELECT DISTINCT
		
		tick.ID,
		tick.SubjectID,
		tick.ApplicationID,
		tick.OwnerID,
		tick.Title,
		ticketSubject.[Name] SubjectTitle,
		ownerUser.FirstName + ' ' + ownerUser.LastName OwnerPositionName,
		creatorUser.FirstName + ' ' + creatorUser.LastName CreatorUserName,
		creatorUser.ID CreatorUserID,
		creatorPos.[Type] PositionType,
		creatorPos.ID CreatorPositionID,
		dep.[Name] DepartmentName,
		dep.ID DepatmentID,
		tick.[Priority],
		tick.TrackingCode,
		tick.Score,
		tick.[State],
		tick.CreationDate
	FROM app.Ticket tick
		LEFT JOIN org.[User] ownerUser ON ownerUser.ID = tick.OwnerID
		LEFT JOIN org.Position creatorPos ON creatorPos.ID = tick.CreatorPositionID
		LEFT JOIN org.[User] creatorUser ON creatorUser.ID = creatorPos.UserID
		LEFT JOIN org.Department dep ON dep.ID = creatorPos.DepartmentID
		LEFT JOIN app.TicketSubject ticketSubject ON ticketSubject.ID = tick.SubjectID
		LEFT JOIN app.TicketSubjectUser ticketSubjectUser ON ticketSubjectUser.TicketSubjectID = tick.SubjectID
	WHERE (tick.ApplicationID = @ApplicationID)
		AND (@TrackingCode IS NULL OR tick.TrackingCode = @TrackingCode)
		AND (@Title IS NULL OR tick.Title LIKE CONCAT('%' , @Title , '%'))
		AND (@DepartmentID IS NULL OR dep.ID =  @DepartmentID)
		AND (@Priority < 1 OR tick.[Priority] =  @Priority)
		AND (@SubjectID IS NULL OR tick.SubjectID =  @SubjectID)
		AND (@State <1 OR tick.[State] = @State)
		AND (@Score <1 OR tick.Score = @Score)
		)

	SELECT COUNT(*) OVER() AS Total,* FROM Ticketlist
	ORDER BY [CreationDate] DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END