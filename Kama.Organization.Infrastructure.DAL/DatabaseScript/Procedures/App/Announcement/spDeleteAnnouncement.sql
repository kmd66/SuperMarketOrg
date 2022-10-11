USE [Kama.Bonyad.Organization]
GO

IF OBJECT_ID('app.spDeleteAnnouncement') IS NOT NULL
	DROP PROCEDURE app.spDeleteAnnouncement
GO

CREATE PROCEDURE app.spDeleteAnnouncement
    @AID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
		, @Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))
		, @Result INT = 0

	BEGIN TRY
		BEGIN TRAN
			
			DELETE FROM pbl.Attachment
			WHERE ParentID = @ID

			DELETE FROM app.AnnouncementPositionType
			WHERE AnnouncementID = @ID

			DELETE FROM app.Announcement
			WHERE ID = @ID

			EXEC pbl.spAddLog @Log

			SET @Result = @@ROWCOUNT
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @Result

END