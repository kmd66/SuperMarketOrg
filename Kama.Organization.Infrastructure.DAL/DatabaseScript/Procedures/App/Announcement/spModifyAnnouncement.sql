USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spModifyAnnouncement'))
	DROP PROCEDURE app.spModifyAnnouncement
GO

CREATE PROCEDURE app.spModifyAnnouncement
	@AIsNewRecord BIT,
	@AID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@AType TINYINT,
	@ATitle nvarchar(200),
	@AContent NVARCHAR(MAX),
	@AExtendedContent nvarchar(MAX),
	@AEnable BIT,
	@AReleaseDate SMALLDATETIME,
	@ADueDate SMALLDATETIME,
	@AOrder INT,
	@AUserID UNIQUEIDENTIFIER,
	@APinned BIT,
	@APositionTypes NVARCHAR(4000),
	@AAllUsers BIT,
	@AAuthorizedUsers BIT,
	@AUnAuthorizedUsers BIT,
	@AExpanded BIT,
	@AProvinceID UNIQUEIDENTIFIER,
	@APriority TINYINT,
	@ALog NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE   
		@IsNewRecord BIT = @AIsNewRecord,
		@ID UNIQUEIDENTIFIER = @AID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Type TINYINT = COALESCE(@AType, 0),
		@Title NVARCHAR(200) = LTRIM(RTRIM(@ATitle)),
		@Content NVARCHAR(MAX) = LTRIM(RTRIM(@AContent)),
		@ExtendedContent NVARCHAR(MAX) = LTRIM(RTRIM(@AExtendedContent)),
		@Enable BIT = COALESCE(@AEnable, 0),
		@ReleaseDate SMALLDATETIME = @AReleaseDate, 
		@DueDate SMALLDATETIME = @ADueDate,
		@Order INT = COALESCE(@AOrder, 1),
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@Pinned BIT = COALESCE(@APinned, 0),
		@PositionTypes NVARCHAR(4000) = LTRIM(RTRIM(@APositionTypes)),
		@AllUsers BIT = COALESCE(@AAllUsers, 0),
		@AuthorizedUsers BIT = COALESCE(@AAuthorizedUsers, 0),
		@UnAuthorizedUsers BIT = COALESCE(@AUnAuthorizedUsers, 0),
		@Expanded BIT = COALESCE(@AExpanded, 0),
		@ProvinceID UNIQUEIDENTIFIER = @AProvinceID,
		@Priority TINYINT = COALESCE(@APriority, 2),
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Result NVARCHAR(MAX)

	BEGIN TRY
		BEGIN TRAN
			IF @IsNewRecord = 1 -- insert
			BEGIN

				INSERT INTO app.[Announcement]
				(ID, ApplicationID, [Type], Title, [Content], ExtendedContent, [Enable], ReleaseDate, DueDate, [Order], AllUsers, Pinned, VisitCount, CreatorID, AuthorizedUsers, UnAuthorizedUsers, Expanded, ProvinceID, [Priority],  CreationDate)
				VALUES 
				(@ID, @ApplicationID, @Type, @Title, @Content, @ExtendedContent, @Enable, @ReleaseDate, @DueDate, @Order, @AllUsers, @Pinned, 0, @UserID, @AuthorizedUsers, @UnAuthorizedUsers, @Expanded, @ProvinceID , @Priority,GETDATE())
			END
			ELSE
			BEGIN -- update
				UPDATE app.[Announcement]
				SET ApplicationID = @ApplicationID, [Type] = @Type, Title = @Title, Content = @Content, ExtendedContent = @ExtendedContent, [Enable] = @Enable, ReleaseDate = @ReleaseDate, DueDate = @DueDate, [Order] = @Order, AllUsers = @AllUsers, Pinned = @Pinned, AuthorizedUsers= @AuthorizedUsers, UnAuthorizedUsers = @UnAuthorizedUsers, Expanded = @Expanded , ProvinceID = @ProvinceID, [Priority] = @Priority
				WHERE ID = @ID
			END
			
			-- AnnouncementPositionType 
			delete app.AnnouncementPositionType WHERE AnnouncementID = @ID
			
			INSERT INTO app.AnnouncementPositionType
			(ID, AnnouncementID, PositionType)
			SELECT NEWID() ID, 
				@ID AnnouncementID, 
				PositionType
			FROM OPENJSON(@PositionTypes)
			WITH(
				ID UNIQUEIDENTIFIER,
				PositionType TINYINT
			)

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END