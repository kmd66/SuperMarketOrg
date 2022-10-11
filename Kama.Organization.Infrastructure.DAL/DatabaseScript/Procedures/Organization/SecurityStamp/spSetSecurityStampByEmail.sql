USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spSetSecurityStampByEmail'))
	DROP PROCEDURE org.spSetSecurityStampByEmail
GO

CREATE PROCEDURE org.spSetSecurityStampByEmail
	@AEmail VARCHAR(20),
	@AStamp VARCHAR(256)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@Email VARCHAR(20) = LTRIM(RTRIM(@AEmail)),
		@Stamp VARCHAR(256) = LTRIM(RTRIM(@AStamp))

	BEGIN TRY
		
		IF NOT EXISTS (SELECT TOP 1 1 FROM org.SecurityStamp WHERE Email = @Email)
		BEGIN
			INSERT INTO org.SecurityStamp
			(ID, Email, Stamp, CreationDate)
			Values
			(NEWID(), @Email, @Stamp, GETDATE())
		END
		ELSE
		BEGIN
			UPDATE org.SecurityStamp
			SET Stamp = @Stamp, CreationDate = GETDATE()
			WHERE Email = @Email
		END

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@RowCount
END
