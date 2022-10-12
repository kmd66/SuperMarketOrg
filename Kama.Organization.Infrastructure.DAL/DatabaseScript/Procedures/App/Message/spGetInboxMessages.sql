USE [Kama.Sm.Organization]
GO

IF EXISTS( SELECT 1 FROM SYS.PROCEDURES WHERE [object_id] = OBJECT_ID('app.spGetInboxMessages'))
	DROP PROCEDURE app.spGetInboxMessages
GO

CREATE PROCEDURE app.spGetInboxMessages
	@ACurrentUserID UNIQUEIDENTIFIER,
	@AApplicationID UNIQUEIDENTIFIER,
	@ATitle NVARCHAR(300),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS

BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE 
		@CurrentUserID UNIQUEIDENTIFIER = @ACurrentUserID,
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@Title NVARCHAR(300) = @ATitle,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	BEGIN TRY
		BEGIN TRAN
			
			;WITH Receiver As (
				SELECT DISTINCT MessageID, ReceiverUserID , Seen , IsRemoved
				FROM app.MessageReceivers
				WHERE ReceiverUserID = @CurrentUserID
					AND IsRemoved = 0 
			)
			, MainSelect AS(
			SELECT  
					count(*) over() Total,  
					msg.ID,
					msg.ApplicationID, 
					msg.SenderUserID, 
					msg.[Title], 
					msg.[Content], 
					msg.[CreationDate], 
					msg.[IsRemoved], 
					msg.[ParentID], 
					msg.IsSent,
					rcv.Seen,
					u.FirstName + ' ' + u.LastName  SenderUserFullName
			FROM app.[Message] msg
				 INNER JOIN org.[User] u ON u.ID = msg.SenderUserID
				 INNER JOIN Receiver rcv ON rcv.MessageID = msg.ID
			WHERE IsSent = 1
				AND rcv.IsRemoved = 0
				AND rcv.ReceiverUserID = @CurrentUserID
				AND (@Title is NULL OR msg.Title = @Title)
				)
		SELECT * FROM MainSelect
		ORDER BY [ID]
		OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
				
			COMMIT
		END TRY
	BEGIN CATCH
	;THROW
	END CATCH
	RETURN @@ROWCOUNT
END