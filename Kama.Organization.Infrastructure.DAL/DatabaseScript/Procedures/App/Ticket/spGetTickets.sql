USE [Kama.Mefa.Organization]
GO

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetTickets'))
	DROP PROCEDURE app.spGetTickets
GO

CREATE PROCEDURE app.spGetTickets
	@AApplicationID UNIQUEIDENTIFIER,
	@ASubjectID UNIQUEIDENTIFIER,
	@AState TINYINT,
	@ATrackingCode NVARCHAR(50),
	@APriority TINYINT,
	@ADepartmentID UNIQUEIDENTIFIER,
	@ADepartmentName NVARCHAR(50),
	@ATitle NVARCHAR(200),
	@AReadDate SMALLDATETIME,
	@AScore TINYINT,
	@AUserID UNIQUEIDENTIFIER,
	@APositionID UNIQUEIDENTIFIER,
	@AOwnerID UNIQUEIDENTIFIER,
	@AIsCreated BIT,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000),
	@ACurrentUserID UNIQUEIDENTIFIER,
	@ACurrentUserType TINYINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@SubjectID UNIQUEIDENTIFIER = @ASubjectID,
		@State TINYINT = COALESCE(@AState, 0),
		@TrackingCode NVARCHAR(50) = LTRIM(RTRIM(@ATrackingCode)),
		@DepartmentID UNIQUEIDENTIFIER = @ADepartmentID,
		@DepartmentName NVARCHAR(50) = LTRIM(RTRIM(@ADepartmentName)),
		@Priority TINYINT = COALESCE(@APriority, 0),
		@Title NVARCHAR(200) = LTRIM(RTRIM(@ATitle)),
		@ReadDate SMALLDATETIME = @AReadDate,
		@Score TINYINT = @AScore,
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@OwnerID UNIQUEIDENTIFIER = @AOwnerID,
		@IsCreated BIT=@AIsCreated, 
		@PageSize INT = COALESCE(@APageSize, 20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID,
		@CurrentUserType TINYINT = @ACurrentUserType

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
		tick.Score,
		ticketSubject.[Name] SubjectTitle,
		ownerUser.FirstName + ' ' + ownerUser.LastName OwnerPositionName,
		creatorUser.FirstName + ' ' + creatorUser.LastName CreatorUserName,
		creatorUser.ID CreatorUserID,
		creatorPos.[Type] PositionType,
		creatorPos.ID CreatorPositionID,
		dep.ID DepartmentID,
		dep.[Name] DepartmentName,
		--TicketSequence.ReadDate,
		tick.[Priority],
		tick.TrackingCode,
		tick.[State],
		tick.CreationDate
	FROM app.Ticket tick
		--LEFT JOIN app.TicketSequence ticketSequence ON ticketSequence.TicketID = tick.ID
		LEFT JOIN org.[User] ownerUser ON ownerUser.ID = tick.OwnerID
		LEFT JOIN org.Position creatorPos ON creatorPos.ID = tick.CreatorPositionID
		LEFT JOIN org.[User] creatorUser ON creatorUser.ID = creatorPos.UserID
		LEFT JOIN org.Department dep ON dep.ID = creatorPos.DepartmentID
		LEFT JOIN app.TicketSubject ticketSubject ON ticketSubject.ID = tick.SubjectID
		LEFT JOIN app.TicketSubjectUser ticketSubjectUser ON ticketSubjectUser.TicketSubjectID = tick.SubjectID
	WHERE (tick.ApplicationID = @ApplicationID)
		AND (@IsCreated = 1 -- internal user
			OR (
				((@OwnerID IS NULL AND tick.OwnerID IS NULL) 
					OR (@OwnerID IS NOT NULL AND tick.OwnerID = @OwnerID))
				AND (ticketSubjectUser.UserID = @CurrentUserID)
				AND (@State <> 2 OR tick.[State] = 2)
				AND (@State = 2 OR tick.[State] <> 2)
			)
		)
		AND (@IsCreated = 0 OR tick.CreatorPositionID = @PositionID)
	)

	SELECT COUNT(*) OVER() AS Total,* FROM Ticketlist
	ORDER BY [CreationDate] DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END