USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetUsers'))
	DROP PROCEDURE org.spGetUsers
GO

CREATE PROCEDURE org.spGetUsers
	@AApplicationID UNIQUEIDENTIFIER,
	@ANationalCode NVARCHAR(10),
	@AName NVARCHAR(1000),
	@AEmail NVARCHAR(1000),
	@ACellphone NVARCHAR(1000),
	@AEnablOrDisable TINYINT,
	@APageSize INT,
	@APageIndex INT,
	@ASortExp NVARCHAR(1000)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@NationalCode NVARCHAR(10) = LTRIM(RTRIM(@ANationalCode)),
		@Name NVARCHAR(1000) = LTRIM(RTRIM(@AName)),
		@Email NVARCHAR(1000) = LTRIM(RTRIM(@AEmail)),
		@Cellphone NVARCHAR(1000) = LTRIM(RTRIM(@ACellphone)),
		@EnablOrDisable TINYINT = COALESCE(@AEnablOrDisable, 0),
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@SortExp NVARCHAR(1000) = LTRIM(RTRIM(@ASortExp))
		
	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH UserPosition
	AS
	(
		SELECT DISTINCT 
			UserID,
			ApplicationID
		FROM org.Position 
		WHERE ApplicationID = @ApplicationID 
		AND RemoverID IS NULL 
	)
	, MainSelect AS 
	(
		SELECT 
			COUNT(*) OVER() Total,
			usr.ID,
			usr.[Enabled],
			usr.Username,
			usr.FirstName,
			usr.LastName,
			usr.NationalCode,
			--usr.Email,
			usr.EmailVerified,
			--usr.CellPhone,
			usr.CellPhoneVerified,
			Foreigner
		FROM org.[User] usr
		LEFT JOIN UserPosition on UserPosition.UserID = usr.ID
		WHERE  
			(@ApplicationID is null or UserPosition.ApplicationID = @ApplicationID)
			AND (@NationalCode IS NULL OR usr.NationalCode = @NationalCode)
			AND (@Name IS NULL OR usr.FirstName LIKE @Name OR usr.LastName LIKE @Name )
			AND (@Email IS NULL OR usr.Email LIKE @Email)
			AND (@Cellphone IS NULL OR usr.Cellphone LIKE @Cellphone)
			AND (@EnablOrDisable < 1 OR usr.[Enabled] = @EnablOrDisable - 1)
	)
	SELECT * FROM MainSelect		 
	ORDER BY [ID]
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

	RETURN @@ROWCOUNT
END