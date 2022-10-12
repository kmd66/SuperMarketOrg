USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetWebServiceUsers'))
DROP PROCEDURE org.spGetWebServiceUsers
GO

CREATE PROCEDURE org.spGetWebServiceUsers
	@AUserName NVARCHAR(50),
	@AOrganID UNIQUEIDENTIFIER,
	@AEnableState TINYINT,
	@AComment NVARCHAR(1000),
	@ASortExp NVARCHAR(MAX),
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE
		@UserName NVARCHAR(50) = TRIM(@AUserName),
		@OrganID UNIQUEIDENTIFIER = @AOrganID,
		@EnableState TINYINT = COALESCE(@AEnableState, 0),
		@Comment NVARCHAR(1000) = TRIM(@AComment),
		@SortExp NVARCHAR(MAX) = TRIM(@ASortExp),
		@PageSize INT = COALESCE(@APageSize, 0),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH MainSelect AS
	(
		SELECT 
			usr.ID, 
			usr.UserName, 
			--usr.[Password], 
			usr.OrganID, 
			org.[Name] OrganName,
			usr.[Enabled], 
			usr.PasswordExpireDate, 
			usr.Comment,
			usr.CreationDate
		FROM org.WebServiceUser usr
			INNER JOIN org.Department org On org.ID = usr.OrganID
		WHERE
			(@UserName IS NULL OR usr.UserName = @UserName)
			AND (@OrganID IS NULL OR usr.OrganID = @OrganID)
			AND (@EnableState < 1 OR usr.[Enabled] = @EnableState - 1)
			AND (@Comment IS NULL OR usr.Comment = @Comment)
	)
	,Total AS
	(
		SELECT COUNT(*) AS Total FROM MainSelect
	)
	SELECT * FROM MainSelect,Total
	ORDER BY CreationDate
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END
