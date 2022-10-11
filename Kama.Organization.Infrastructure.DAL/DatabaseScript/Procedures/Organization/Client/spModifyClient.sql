USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spModifyClient'))
	DROP PROCEDURE org.spModifyClient
GO

CREATE PROCEDURE org.spModifyClient
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AName NVARCHAR(256),
	@ASecret nvarchar(4000),
	@AType TinyINT,
	@AEnabled BIT,
	@ARefreshTokenLifeTime INT,
	@AAllowedOrigin nvarchar(4000),
	@ALog NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	 DECLARE 
		@IsNewRecord BIT = ISNULL(@AIsNewRecord, 0),
	    @ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Name VARCHAR(256) = LTRIM(RTRIM(@AName)),
		@Secret nvarchar(4000) = LTRIM(RTRIM(@ASecret)),
		@Type TinyINT = @Atype,
		@Enabled BIT = ISNULL(@AEnabled, 0),
		@RefreshTokenLifeTime INT = @ARefreshTokenLifeTime,
		@AllowedOrigin varchar(4000) = LTRIM(RTRIM(@AAllowedOrigin)),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog))

	BEGIN TRY
		BEGIN TRAN

			IF @IsNewRecord = 1 -- insert
			BEGIN
				INSERT INTO org.[Client]
				(ID , ApplicationID, [Name], [Enabled], [Type] , [Secret] , AllowedOrigin , RefreshTokenLifeTime)
				VALUES
				(@ID, @ApplicationID, @Name, @Enabled , @Type , @Secret, @AllowedOrigin , @RefreshTokenLifeTime)
			END
			ELSE 
			BEGIN -- update
				UPDATE org.[Client]
				SET  [Name] = @Name, [Enabled] = @Enabled, ApplicationID = @ApplicationID, [Type] = @Type, [Secret] = @Secret, AllowedOrigin = @AllowedOrigin,RefreshTokenLifeTime = @RefreshTokenLifeTime
				WHERE ID = @ID
			END

			EXEC pbl.spAddLog @Log
		COMMIT

	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT

END
