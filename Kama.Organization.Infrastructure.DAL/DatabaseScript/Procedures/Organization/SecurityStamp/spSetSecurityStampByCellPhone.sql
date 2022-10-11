USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spSetSecurityStampByCellPhone'))
	DROP PROCEDURE org.spSetSecurityStampByCellPhone
GO

CREATE PROCEDURE org.spSetSecurityStampByCellPhone
	@ACellPhone VARCHAR(20),
	@AStamp VARCHAR(256)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@CellPhone VARCHAR(20) = LTRIM(RTRIM(@ACellPhone)),
		@Stamp VARCHAR(256) = LTRIM(RTRIM(@AStamp))

	BEGIN TRY
		
		IF NOT EXISTS (SELECT TOP 1 1 FROM org.SecurityStamp WHERE CellPhone = @CellPhone)
		BEGIN
			INSERT INTO org.SecurityStamp
			(ID, CellPhone, Stamp, CreationDate)
			Values
			(NEWID(), @CellPhone, @Stamp, GETDATE())
		END
		ELSE
		BEGIN
			UPDATE org.SecurityStamp
			SET Stamp = @Stamp, CreationDate = GETDATE()
			WHERE CellPhone = @CellPhone
		END

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@RowCount
END
