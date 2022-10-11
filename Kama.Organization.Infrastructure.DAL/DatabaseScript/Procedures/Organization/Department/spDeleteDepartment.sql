USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spDeleteDepartment'))
	DROP PROCEDURE org.spDeleteDepartment
GO

CREATE PROCEDURE org.spDeleteDepartment
	@AID UNIQUEIDENTIFIER,
	@ACurrentUserID UNIQUEIDENTIFIER,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE  
		@ID UNIQUEIDENTIFIER = @AID,
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Node HIERARCHYID 
	
	SET @Node = (SELECT [Node] FROM org.Department WHERE ID = @ID)  

	IF @Node = HIERARCHYID::GetRoot()
		THROW 50000, N'رکورد ریشه قابل حذف نیست', 1

	BEGIN TRY
		BEGIN TRAN
			UPDATE org.Department
			SET RemoverID = @CurrentUserID,
				RemoverDate = GETDATE()
			WHERE [Node].IsDescendantOf(@Node) = 1

			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END