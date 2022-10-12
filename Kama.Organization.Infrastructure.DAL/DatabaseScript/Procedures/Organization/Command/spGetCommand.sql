USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetCommand'))
	DROP PROCEDURE org.spGetCommand
GO

CREATE PROCEDURE org.spGetCommand
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID

	SELECT ID,
		ApplicationID,
		Node.ToString() Node,
		Node.GetAncestor(1).ToString() ParentNode,
		[Name],
		FullName,
		Title,
		[Type]
	FROM org.Command
	WHERE (ID = @ID)

	RETURN @@ROWCOUNT
END