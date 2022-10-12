USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPlace'))
	DROP PROCEDURE org.spGetPlace
GO

CREATE PROCEDURE org.spGetPlace
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@ID UNIQUEIDENTIFIER = @AID

	SELECT
		Place.ID,
		Place.[Node].ToString() [Node],
		Place.[Node].GetAncestor(1).ToString() ParentNode,
		Place.[Type],
		Place.[Name],
		Place.LatinName,
		Place.Code
	FROM org.Place Place
	WHERE ID = @ID

	RETURN @@ROWCOUNT
END
