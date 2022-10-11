USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyDepartment'))
	DROP PROCEDURE org.spModifyDepartment
GO

CREATE PROCEDURE org.spModifyDepartment
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@ANode HIERARCHYID,
	@AType TINYINT, 
	@ACode VARCHAR(20),
	@AName NVARCHAR(256),
	@AEnabled BIT,
	@AProvinceID UNIQUEIDENTIFIER,
	@AAddress NVARCHAR(1000),
	@APostalCode CHAR(10),
	@ALog NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ParentID UNIQUEIDENTIFIER = @AParentID,
		@Node HIERARCHYID = @ANode,
		@Type TINYINT = ISNULL(@AType, 0),
		@Code VARCHAR(20) = LTRIM(RTRIM(@ACode)),
		@Name NVARCHAR(256) = LTRIM(RTRIM(@AName)),
		@Enabled BIT = ISNULL(@AEnabled, 0),
		@ProvinceID UNIQUEIDENTIFIER = @AProvinceID,
		@Address NVARCHAR(1000) = LTRIM(RTRIM(@AAddress)),
		@PostalCode CHAR(10) = LTRIM(RTRIM(@APostalCode)),
		@Log NVARCHAR(MAX) = @ALog,
		@ParentNode HIERARCHYID,
		@LastChildNode HIERARCHYID,
		@NewNode HIERARCHYID

	IF EXISTS(SELECT 1 FROM org.Department WHERE ID <> @ID AND REPLACE([Name], ' ', '') = REPLACE(@Name, ' ', ''))
		THROW 50000, N'نام دستگاه تکراری است', 1

	IF EXISTS(SELECT 1 FROM org.Department WHERE ID <> @ID AND REPLACE(Code, ' ', '') = REPLACE(@Code, ' ', ''))
		THROW 50000, N'کد دستگاه تکراری است', 2

	IF @Node IS NULL 
		OR @ParentID <> COALESCE((SELECT TOP 1 ID FROM org.Department WHERE @Node.GetAncestor(1) = [Node]), 0x)
	BEGIN
		SET @ParentNode = COALESCE((SELECT [Node] FROM org.Department WHERE ID = @ParentID), HIERARCHYID::GetRoot())
		SET @LastChildNode = (SELECT MAX([Node]) FROM org.Department WHERE [Node].GetAncestor(1) = @ParentNode)
		SET @NewNode = @ParentNode.GetDescendant(@LastChildNode, NULL)
	END

	BEGIN TRY
		BEGIN TRAN
			 
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.Department
				(ID, [Node], [Type], Code, [Name], [Enabled], ProvinceID, Address, PostalCode)
				VALUES
				(@ID, @NewNode, @Type, @Code, @Name, @Enabled, @ProvinceID, @Address, @PostalCode)
			END
			ELSE
			BEGIN -- update
				UPDATE org.Department
				SET Node = @Node, [Type] = @Type, Code = @Code, [Name] = @Name, [Enabled] = @Enabled, ProvinceID = @ProvinceID, Address = @Address, PostalCode = @PostalCode
				WHERE ID = @ID

				IF @Node <> @NewNode
				BEGIN
					Update org.Department
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