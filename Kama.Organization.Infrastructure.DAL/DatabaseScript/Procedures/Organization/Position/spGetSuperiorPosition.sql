USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetSuperiorPosition'))
	DROP PROCEDURE org.spGetSuperiorPosition
GO

CREATE PROCEDURE org.spGetSuperiorPosition
	@AMagistrateID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @MagistrateID UNIQUEIDENTIFIER = @AMagistrateID
		  , @MagistrateNode HIERARCHYID
		  , @Node HIERARCHYID
	
	IF @MagistrateID IS NULL
		RETURN -2 -- دادرس مشخص نشده است

	SET @MagistrateNode = (SELECT [Node] FROM org.Positions WHERE ID = @MagistrateID)

	SELECT *
	FROM org._Positions 
	WHERE [Node] = @MagistrateNode.GetAncestor(1).ToString()

	RETURN @@ROWCOUNT
END