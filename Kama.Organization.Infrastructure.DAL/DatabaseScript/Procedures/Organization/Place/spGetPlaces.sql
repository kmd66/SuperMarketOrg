USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPlaces'))
	DROP PROCEDURE org.spGetPlaces
GO

CREATE PROCEDURE org.spGetPlaces
	@AIDs NVARCHAR(MAX),
	@AParentID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@AAncestorLevel INT,
	@AName NVARCHAR(256)

WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE
		@IDs NVARCHAR(MAX) = LTRIM(RTRIM(@AIDs)),
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Type TINYINT = COALESCE(@AType, 0),
		@AncestorLevel INT = COALESCE(@AAncestorLevel, 1),
		@Name NVARCHAR(256) = LTRIM(RTRIM(@AName)),
		@ParentNode HIERARCHYID

	SET @ParentNode = (SELECT Node FROM org.Place WHERE ID = @ParentID)
	IF @AncestorLevel < 1 SET @AncestorLevel = 1

	;WITH SearchedIDs AS
	(
		SELECT Value ID
		FROM OPENJSON(@IDs)
	)
	, MainSelect AS
	(
		SELECT
			Place.ID,
			Place.[Node].ToString() [Node],
			Place.[Node].GetAncestor(1).ToString() ParentNode,
			Place.[Type],
			Place.[Name],
			Place.LatinName,
			Place.Code
		FROM org.Place Place
		LEFT JOIN SearchedIDs ON SearchedIDs.ID = Place.ID
		WHERE (@IDs IS NULL OR SearchedIDs.ID IS NOT NULL)
			AND (@ParentID IS NULL OR [Node].GetAncestor(@AncestorLevel) = @ParentNode) 
			AND (@Type < 1 OR [Type] = @Type)
			AND (@Name IS NULL OR [Name] like CONCAT('%', @Name, '%'))
	)
	SELECT *
	FROM MainSelect
	ORDER BY [Name]

	RETURN @@ROWCOUNT
END
