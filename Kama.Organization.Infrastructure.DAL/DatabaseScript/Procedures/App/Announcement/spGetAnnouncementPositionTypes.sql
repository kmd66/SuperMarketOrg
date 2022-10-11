USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetAnnouncementPositionTypes'))
	DROP PROCEDURE app.spGetAnnouncementPositionTypes
GO

CREATE PROCEDURE app.spGetAnnouncementPositionTypes
	@AAnnouncementID UNIQUEIDENTIFIER 
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @AnnouncementID UNIQUEIDENTIFIER = @AAnnouncementID

	SELECT
		ID,
		AnnouncementID,
		PositionType
	FROM app.AnnouncementPositionType
	WHERE AnnouncementID = @AnnouncementID

	RETURN @@ROWCOUNT
END