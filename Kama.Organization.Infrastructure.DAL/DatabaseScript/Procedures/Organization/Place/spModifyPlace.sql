USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyPlace'))
	DROP PROCEDURE org.spModifyPlace
GO

CREATE PROCEDURE org.spModifyPlace
    @AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@ANode HIERARCHYID,
	@AType TINYINT,
	@AName NVARCHAR(256),
	@ACode VARCHAR(3),
	@ALatinName NVARCHAR(256),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Node HIERARCHYID = @ANode,
		@Type TINYINT = @AType,
		@Name NVARCHAR(256) = LTRIM(RTRIM(@AName)),
		@Code VARCHAR(3) = LTRIM(RTRIM(@ACode)),
		@LatinName NVARCHAR(256) = LTRIM(RTRIM(@ALatinName)),
		@Log NVARCHAR(MAX) = @ALog,
		@ParentNode HIERARCHYID,
		@LastChildNode HIERARCHYID,
		@NewNode HIERARCHYID

	IF @Node IS NULL 
		OR @ParentID <> COALESCE((SELECT TOP 1 ID FROM org.Place WHERE @Node.GetAncestor(1) = [Node]), 0x)
	BEGIN
		SET @ParentNode = COALESCE((SELECT [Node] FROM org.Place WHERE ID = @ParentID), HIERARCHYID::GetRoot())
		SET @LastChildNode = (SELECT MAX([Node]) FROM org.Place WHERE [Node].GetAncestor(1) = @ParentNode)
		SET @NewNode = @ParentNode.GetDescendant(@LastChildNode, NULL)
	END

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert 
			BEGIN
				INSERT INTO org.Place
					(ID, [Node], [Type], [Name], Code, LatinName)
				VALUES
					(@ID, @NewNode, @Type, @Name, @Code, @LatinName)
			END
			ELSE -- update
			BEGIN
				UPDATE org.Place
				SET [Type] = @Type, [Name] = @Name, Code = @Code, [LatinName] = @LatinName
				WHERE ID = @ID

				IF @Node <> @NewNode
				BEGIN
					Update org.Place
					SET Node = Node.GetReparentedValue(@Node, @NewNode)
					WHERE Node.IsDescendantOf(@Node) = 1
				END
			END
			
			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT

END
