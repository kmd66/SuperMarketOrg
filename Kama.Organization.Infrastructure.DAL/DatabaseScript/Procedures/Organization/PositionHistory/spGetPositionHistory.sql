USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionHistory'))
	DROP PROCEDURE org.spGetPositionHistory
GO

CREATE PROCEDURE org.spGetPositionHistory
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID UNIQUEIDENTIFIER = @AID

	SELECT
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
	WHERE positionHistory.ID = @ID

	RETURN @@ROWCOUNT
END
