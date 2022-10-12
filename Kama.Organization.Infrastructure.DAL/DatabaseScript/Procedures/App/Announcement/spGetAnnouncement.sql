USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetAnnouncement'))
	DROP PROCEDURE app.spGetAnnouncement
GO

CREATE PROCEDURE app.spGetAnnouncement
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
			count(*) over() Total,
			ann.ProvinceID,
			ann.ID,
			ann.[Type],
			ann.[Title],
			ann.Content,
			ann.ExtendedContent,
			ann.[ReleaseDate],
			ann.[DueDate],
			ann.[Enable],
			ann.[VisitCount],
			ann.[AllUsers],
			ann.[Pinned],
			ann.AuthorizedUsers,
			ann.UnAuthorizedUsers,
			ann.Expanded,
			ann.[Priority]
	FROM app.Announcement ann
	where ann.ID = @ID

	RETURN @@ROWCOUNT
END