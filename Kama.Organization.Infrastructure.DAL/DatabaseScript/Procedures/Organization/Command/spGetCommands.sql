USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetCommands'))
	DROP PROCEDURE org.spGetCommands
GO

CREATE PROCEDURE org.spGetCommands
	@AApplicationID UNIQUEIDENTIFIER,
	@ARoleID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@AName VARCHAR(256),
	@ATitle NVARCHAR(256),
	@AType TINYINT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@RoleID UNIQUEIDENTIFIER = @ARoleID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Name VARCHAR(256) = LTRIM(RTRIM(@AName)),
		@Title NVARCHAR(256) = LTRIM(RTRIM(@ATitle)),
		@Type TINYINT = COALESCE(@AType, 0),
		@ParentNode HIERARCHYID 

	SET @ParentNode = (SELECT [Node] FROM org.Command WHERE ID = @ParentID)

	SELECT Command.ID,
		Command.ApplicationID,
		Command.[Node].ToString() Node,
		Command.[Node].GetAncestor(1).ToString() ParentNode,
		Command.[Name],
		Command.FullName,
		Command.Title,
		Command.[Type]
	FROM org.Command
		LEFT JOIN org.RolePermission ON RolePermission.CommandID = Command.ID AND RolePermission.RoleID = @RoleID
	WHERE ApplicationID = @ApplicationID
		AND (@RoleID IS NULL OR RolePermission.RoleID = @RoleID)
		AND (@ParentNode IS NULL OR Command.[Node].IsDescendantOf(@ParentNode) = 1 AND Command.ApplicationID = @ApplicationID)
		AND (@Name IS NULL OR [Name] LIKE CONCAT('%', @Name, '%'))
		AND (@Title IS NULL OR Title LIKE CONCAT('%', @Title, '%'))
		AND (@Type < 1 OR [Type] = @Type)
	ORDER BY Title

	RETURN @@ROWCOUNT
END