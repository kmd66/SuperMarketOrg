USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyCommand'))
	DROP PROCEDURE org.spModifyCommand
GO

CREATE PROCEDURE org.spModifyCommand
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@ANode HIERARCHYID,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName varchar(256),
	@AFullName varchar(1000),
	@ATitle nvarchar(256),
	@AType TINYINT,
	@ALog NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Node HIERARCHYID = @ANode,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name varchar(256) = LTRIM(RTRIM(@AName)),
		@FullName varchar(1000) = LTRIM(RTRIM(@AFullName)),
		@Title nvarchar(256) = LTRIM(RTRIM(@ATitle)),
		@Type TINYINT = COALESCE(@AType, 0),
		@Log NVARCHAR(MAX) = @ALog,
		@ParentNode HIERARCHYID,
		@LastChildNode HIERARCHYID,
		@NewNode HIERARCHYID

	IF EXISTS(SELECT 1 FROM org.Command WHERE ID <> @ID AND ApplicationID = @ApplicationID AND REPLACE([Name], ' ', '') = REPLACE(@Name, ' ', ''))
		THROW 50000, N'نام تکراری است', 1

	IF @Node IS NULL 
		OR @ParentID <> COALESCE((SELECT TOP 1 ID FROM org.Command WHERE @Node.GetAncestor(1) = [Node]), 0x)
	BEGIN
		SET @ParentNode = COALESCE((SELECT [Node] FROM org.Command WHERE ID = @ParentID), HIERARCHYID::GetRoot())
		SET @LastChildNode = (SELECT MAX([Node]) FROM org.Command WHERE [Node].GetAncestor(1) = @ParentNode)
		SET @NewNode = @ParentNode.GetDescendant(@LastChildNode, NULL)
	END

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.Command
				(ID, [Node], ApplicationID, [Name], FullName, Title, [Type], CreationDate)
				VALUES
				(@ID, @NewNode, @ApplicationID, @Name, @FullName, @Title, @Type, GetDate())
			END
			ELSE
			BEGIN -- update
				UPDATE org.Command
				SET [Name] = @Name, Title = @Title, [Type] = @Type, FullName = @FullName
				WHERE ID = @ID

				IF(@Node <> @NewNode)
				BEGIN
					UPDATE org.Command
					SET [Node] = [Node].GetReparentedValue(@Node, @NewNode)
					WHERE [Node].IsDescendantOf(@Node) = 1
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