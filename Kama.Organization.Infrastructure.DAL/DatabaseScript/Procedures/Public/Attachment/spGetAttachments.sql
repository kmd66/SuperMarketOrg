USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spGetAttachments'))
	DROP PROCEDURE pbl.spGetAttachments
GO

CREATE PROCEDURE pbl.spGetAttachments
	@AParentID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ParentID UNIQUEIDENTIFIER = @AParentID
	
	SELECT ID
		, ParentID  
		, [Type]
		, [FileName]
		, Comment
	FROM pbl.Attachment
	WHERE ParentID = @ParentID

	RETURN @@ROWCOUNT
END