USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionHistorys'))
	DROP PROCEDURE org.spGetPositionHistorys
GO

CREATE PROCEDURE org.spGetPositionHistorys
	@APositionID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp VARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@PositionID UNIQUEIDENTIFIER = @APositionID,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@SortExp VARCHAR(MAX) = LTRIM(RTRIM(@ASortExp))


	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	SELECT
		COUNT(*) OVER() Total,
		positionHistory.[ID],
		positionHistory.[PositionID],
		positionHistory.[UserID],
		positionHistory.[LetterNumber],
		positionHistory.[Date],
		positionHistory.[Comment],
		positionHistory.[CreationDate],
		positionHistory.[IsEndUser],
		us.FirstName,
		us.LastName,
		us.NationalCode,
		us.Username,
		us.CellPhone,

		creatorUser.FirstName CreatorUserFirstName,
		creatorUser.LastName CreatorUserLastName,
		creatorUser.NationalCode CreatorUserNationalCode,
		creatorUser.Username CreatorUserUsername,
		creatorUser.CellPhone CreatorUserCellPhone,

		creatorPosition.[Type] CreatorPositionType,
		creatorPosition.DepartmentID CreatorPositionDepartmentID,
		creatorPositionDepartment.[Name] CreatorPositionDepartmentName

	FROM [org].[PositionHistory] positionHistory
	INNER JOIN org.[User] us ON us.ID = positionHistory.UserID
	INNER JOIN org.[User] creatorUser ON creatorUser.ID = positionHistory.CreatorUserID
	INNER JOIN org.[Position] creatorPosition ON creatorPosition.ID = positionHistory.CreatorPositionID
	INNER JOIN org.Department creatorPositionDepartment ON creatorPositionDepartment.ID = creatorPosition.DepartmentID
	WHERE (positionHistory.[PositionID] = @PositionID)
	ORDER BY [CreationDate] DESC
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END
