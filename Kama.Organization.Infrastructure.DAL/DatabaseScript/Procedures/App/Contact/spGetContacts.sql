USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetContacts'))
	DROP PROCEDURE app.spGetContacts
GO

CREATE PROCEDURE app.spGetContacts
	@AApplicationID uniqueidentifier,
	@ATitle NVARCHAR(200),
	@AContent NVARCHAR(200),
	@ACreationDateFrom SMALLDATETIME,
	@ACreationDateTo SMALLDATETIME,
	@AArchivedType TINYINT,
	@ANote NVARCHAR(4000),
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID uniqueidentifier = @AApplicationID,
		@Title NVARCHAR(200) = @ATitle,
		@Content NVARCHAR(200) = @AContent,
		@CreationDateFrom SMALLDATETIME = COALESCE(DATEADD(dd, DATEDIFF(dd, 0, @ACreationDateFrom), 0), DATEADD(YEAR, -96, GETDATE())),
		@CreationDateTo SMALLDATETIME = COALESCE(DATEADD(dd, DATEDIFF(dd, 0, @ACreationDateTo), 0), GETDATE()),
		@ArchivedType TINYINT = COALESCE(@AArchivedType, 0),
		@Note NVARCHAR(MAX) = @ANote,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

		IF @Title = '' SET @Title = NULl ELSE SET @Title = N'%' + @Title + '%'		
		IF @Content = '' SET @Content = NULl ELSE SET @Content = N'%' + @Content + '%'				
		IF @Note = '' SET @Note = NULl ELSE SET @Note = N'%' + @Note + '%'				
		SET @CreationDateFrom = dbo.fnSetTime(@CreationDateFrom, 0, 0, 0)
		SET @CreationDateTo = dbo.fnSetTime(@CreationDateTo, 23, 59, 58)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END


	;WITH MainSelect AS (
	SELECT
		Count(*) OVER() Total,
		contact.ID,
		contact.[Name],
		contact.Email,
		contact.Tel,
		contact.Title,
		contact.CreationDate,
		contact.Archived,
		contact.NationalCode,
		'' Note
	FROM app.Contact contact 
	WHERE contact.ApplicationID = @ApplicationID
		--AND (@Title IS NULL OR contact.Title LIKE @Title)
		--AND(@Content IS NULL OR contact.Title LIKE @Content)
		--AND(@Note IS NULL OR contact.Note LIKE @Note)
		--AND(@ArchivedType < 1 OR contact.Archived = @ArchivedType - 1)
		--AND (DATEADD(dd, DATEDIFF(dd, 0, contact.CreationDate),0) BETWEEN @CreationDateFrom AND @CreationDateTo)
	)

	SELECT * FROM MainSelect		 
	ORDER BY [ID]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END
