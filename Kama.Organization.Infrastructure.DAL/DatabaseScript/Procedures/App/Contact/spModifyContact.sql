USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyContact'))
	DROP PROCEDURE app.spModifyContact
GO

CREATE PROCEDURE app.spModifyContact
    @AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName nvarchar(100),
	@AEmail nvarchar(200),
	@ATel nvarchar(200),
	@ATitle nvarchar(200),
	@ANationalCode nvarchar(200),
	@AContent nvarchar(4000),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID,
			@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
			@Name nvarchar(100) = @AName,
			@Email nvarchar(200) = @AEmail,
			@Tel nvarchar(200) = @ATel,
			@Title nvarchar(200) = @ATitle,
			@NationalCode nvarchar(200) = @ANationalCode,
			@Content nvarchar(max) = @AContent,
			@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN

			INSERT INTO app.Contact
				(ID, ApplicationID, [Name], Email, Tel, Title, Content, Archived, CreationDate, NationalCode)
			VALUES
				(@ID, @ApplicationID, @Name, @Email, @Tel, @Title, @Content, 1, GetDate(), @NationalCode)
			
			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT

END
