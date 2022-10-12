USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContact'))
	DROP PROCEDURE app.spGetContact
GO

CREATE PROCEDURE app.spGetContact
	@AID uniqueidentifier
WITH ENCRYPTION
AS
BEGIN
	
	SET NOCOUNT ON;
	DECLARE @ID uniqueidentifier = @AID

	SELECT
		Contact.*
	FROM app.Contact contact
	where contact.ID = @ID
	ORDER BY Contact.Title

	RETURN @@ROWCOUNT
END
