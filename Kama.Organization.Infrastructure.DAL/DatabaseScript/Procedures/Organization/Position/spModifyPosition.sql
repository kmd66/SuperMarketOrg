USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyPosition'))
	DROP PROCEDURE org.spModifyPosition
GO

CREATE PROCEDURE org.spModifyPosition
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AParentID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ADepartmentID UNIQUEIDENTIFIER,
	@AUserID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@ARoleIDs NVARCHAR(MAX),
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
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@DepartmentID UNIQUEIDENTIFIER = @ADepartmentID,
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Type TINYINT = ISNULL(@AType, 0),
		@RoleIDs NVARCHAR(MAX) = LTRIM(RTRIM(@ARoleIDs)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@RoleId UNIQUEIDENTIFIER = NULL
		--@ParentNode HIERARCHYID,
		--@LastChildNode HIERARCHYID,
		--@Node HIERARCHYID

	BEGIN TRY
		BEGIN TRAN

			--SET @Node = (SELECT [Node] FROM org.Position WHERE ID = @ID)
				
			--IF @Node IS NULL OR @ParentID <> (SELECT TOP 1 ID FROM org.Position where @Node.GetAncestor(1) = [Node])
			--BEGIN
			--	IF @ParentID = 0x
			--		SET @ParentNode = HIERARCHYID::GetRoot()  
			--	ELSE
			--		SET @ParentNode = (SELECT [Node] FROM org.Position WHERE ID = @ParentID)
			--	SET @LastChildNode = (SELECT MAX([Node]) FROM org.Position WHERE [Node].GetAncestor(1) = @ParentNode AND RemoverID IS NULL)
			--	SET @Node = @ParentNode.GetDescendant(@LastChildNode, NULL)
			--END 

			IF @IsNewRecord = 1 -- insert
			BEGIN
			
				INSERT INTO org.Position
					(ID, ApplicationID, DepartmentID, UserID, [Type], [Default])
				VALUES
					(@ID, @ApplicationID, @DepartmentID, @UserID, @Type, 0)

			END
			ELSE
			BEGIN -- update
				UPDATE org.Position
				SET UserID = @UserID
				WHERE ID = @ID
			END

			IF(@Type in (21, 20))
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM org.PositionRole WHERE PositionID = @ID)
					INSERT INTO org.PositionRole
						(ID, PositionID, RoleID)
					VALUES
						(NEWID(), @ID, 'BA25C517-4B7E-46FE-97CF-A72B0876F69A')
			END
			ELSE
			BEGIN
				DELETE FROM org.PositionRole where PositionID = @ID

				IF @RoleIDs IS NOT NULL
				BEGIN

					INSERT INTO org.PositionRole(ID, PositionID, RoleID)
					SELECT 
						NEWID() ID,
						@ID PositionID,
						ID RoleID
					FROM OPENJSON (@RoleIDs)
					WITH(
						ID UNIQUEIDENTIFIER
					)
				END
			END

			

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END