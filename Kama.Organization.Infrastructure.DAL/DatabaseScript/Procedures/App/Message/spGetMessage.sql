USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetMessage'))
	DROP PROCEDURE app.spGetMessage
GO

CREATE PROCEDURE app.spGetMessage
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT
			msg.ID,
			msg.ApplicationID, 
			msg.SenderUserID, 
			msg.[Title], 
			msg.[Content], 
			msg.[CreationDate], 
			msg.[IsRemoved], 
			msg.[ParentID], 
			msg.IsSent

	FROM app.[Message] msg
	WHERE (msg.ID = @ID)

	RETURN @@ROWCOUNT
END