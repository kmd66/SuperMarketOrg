USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyPositionType'))
	DROP PROCEDURE org.spModifyPositionType
GO

CREATE PROCEDURE org.spModifyPositionType
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@APositionType TINYINT,
	@AUserType TINYINT,
	@AApplicationID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@PositionType TINYINT = COALESCE(@APositionType, 0),
		@UserType TINYINT = COALESCE(@AUserType, 0),
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@ParentNode HIERARCHYID,
		@Node HIERARCHYID,
		@LastChildNode HIERARCHYID

	SET @parentNode = (SELECT Node FROM org.PositionType WHERE ID = @ParentID)
	IF @ParentNode IS NULL
		SET @ParentNode = HIERARCHYID::GetRoot()
	SET @LastChildNode = (SELECT MAX([Node]) FROM org.PositionType WHERE [Node].GetAncestor(1) = @ParentNode)
	SET @Node = @ParentNode.GetDescendant(@LastChildNode, NULL)

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.PositionType
				(ID, Node, PositionType, UserType, ApplicationID)
				VALUES
				(@ID, @Node, @PositionType, @UserType, @ApplicationID)
			END
			ELSE    -- update
			BEGIN
				UPDATE org.PositionType
				SET Node = @Node, PositionType = @PositionType, UserType = @UserType, ApplicationID = @ApplicationID
				WHERE ID = @ID
			END
			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
