USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('pbl.spExecPasswordBlackList'))
	DROP PROCEDURE pbl.spExecPasswordBlackList
GO

CREATE PROCEDURE pbl.spExecPasswordBlackList
	@ARepeatCount INT,
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE
		@RepeatCount INT = @ARepeatCount,
		@Log NVARCHAR(MAX) = @ALog

	BEGIN TRY
		BEGIN TRAN
			
			DECLARE @RepeatedPassword TABLE ([Password] nvarchar(1000), [RepeatCount] INT);

			insert into @RepeatedPassword ([Password], [RepeatCount])
			SELECT 
			[Password],
			COUNT(ID) RepeatCount 
			FROM org.[User]
			GROUP BY [Password]
			HAVING COUNT(ID) > @RepeatCount

			merge into pbl.PasswordBlackList with(holdlock) as passBlackList
			using (select [password], [RepeatCount] from @RepeatedPassword) existingPassBlackList
			on existingPassBlackList.[password] = passBlackList.[Password]
			when not matched by target then
			insert 
				(ID , [password], [RepeatCount], [CreationDate])
			values 
				(NewID(), existingPassBlackList.[Password], existingPassBlackList.[RepeatCount], GetDate());

			--UPDATE  users
			--SET PasswordExpireDate = GETDATE()
			--FROM  org.[User] users
			--INNER JOIN @RepeatedPassword repeatedPass ON repeatedPass.[Password] = users.[Password]

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH

	RETURN @@ROWCOUNT
END
