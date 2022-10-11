USE [Kama.Mefa.Organization]

IF EXISTS(SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spModifyTicketSubject'))
	DROP PROCEDURE app.spModifyTicketSubject
GO

CREATE PROCEDURE app.spModifyTicketSubject
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(200),
	@AEnable BIT,
	@AType TINYINT,
	@ALog NVARCHAR(MAX)

WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 	
		@IsNewRecord BIT = COALESCE(@AIsNewRecord, 0),
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name NVARCHAR(200) = LTRIM(RTRIM(@AName)),
		@Enable BIT = COALESCE(@AEnable, 0),
		@Type TINYINT = @AType,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN
			
			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO app.TicketSubject 
					(ID, ApplicationID, [Name], [Enable], Type)
				VALUES
					(@ID, @ApplicationID, @Name , @AEnable, @Type)
			END
			ELSE
			BEGIN
				UPDATE app.TicketSubject
				 SET [Name]= @Name,
				 [Enable] = @Enable,
				 Type = @Type
			     WHERE [ID]= @ID
			END
			EXEC pbl.spAddLog @Log
		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END
