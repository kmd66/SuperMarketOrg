USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPositionsWithRoles'))
	DROP PROCEDURE org.spGetPositionsWithRoles
GO

CREATE PROCEDURE org.spGetPositionsWithRoles
	@AIDs NVARCHAR(MAX),
	@AApplicationID UNIQUEIDENTIFIER,
	@ADepartmentID UNIQUEIDENTIFIER,
	@ADepartmentName NVARCHAR(50),
	@AType TINYINT,
	@ATypes NVARCHAR(MAX),
	@AUserType TINYINT,
	@AUserID UNIQUEIDENTIFIER,
	@ANationalCode NVARCHAR(10),
	@AName NVARCHAR(1000),
	@AFirstName NVARCHAR(1000),
	@ALastName NVARCHAR(1000),
	@AEmail NVARCHAR(1000),
	@ACellphone NVARCHAR(1000),
	@AEnableState TINYINT,
	@ARoleID UNIQUEIDENTIFIER,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@IDs NVARCHAR(MAX) = LTRIM(RTRIM(@AIDs)),
		@ApplicationID UNIQUEIDENTIFIER = @AApplicationID,
		@DepartmentID UNIQUEIDENTIFIER = @ADepartmentID,
		@DepartmentName NVARCHAR(50) = LTRIM(RTRIM(@ADepartmentName)),
		@Type TINYINT = ISNULL(@AType, 0),
		@Types NVARCHAR(MAX) = LTRIM(RTRIM(@ATypes)),
		@UserType TINYINT = ISNULL(@AUserType, 0),
		@UserID UNIQUEIDENTIFIER = @AUserID,
		@NationalCode NVARCHAR(10) = LTRIM(RTRIM(@ANationalCode)),
		@Name NVARCHAR(1000) = LTRIM(RTRIM(@AName)),
		@FirstName NVARCHAR(1000) = LTRIM(RTRIM(@AFirstName)),
		@LastName NVARCHAR(1000) = LTRIM(RTRIM(@ALastName)),
		@Email NVARCHAR(1000) = LTRIM(RTRIM(@AEmail)),
		@Cellphone NVARCHAR(1000) = LTRIM(RTRIM(@ACellphone)),
		@EnableState TINYINT = COALESCE(@AEnableState, 0),
		@RoleID UNIQUEIDENTIFIER = @ARoleID,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0),
		@CurrentDate SMALLDATETIME = GETDATE()

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	;WITH PositionIDs AS
	(
		SELECT ID 
		FROM OPENJSON(@IDs)
		WITH (ID UNIQUEIDENTIFIER)
	)
	, PositionTypes AS
	(
		SELECT Type
		FROM OPENJSON(@Types)
		WITH (Type TINYINT)
	)
	, MainSelect AS
	(	
		SELECT TOP 100 PERCENT
			Count(*) OVER() Total,
			p.ID,
			p.ApplicationID ApplicationID,
			p.DepartmentID,
			d.[Name] DepartmentName,
			d.[Type] DepartmentType,
			d.ProvinceID,
			Province.Name ProvinceName,
			p.UserID,
			u.Username,
			u.FirstName,
			u.LastName,
			u.NationalCode,
			--u.Email,
			u.EmailVerified,
			--u.CellPhone,
			u.CellPhoneVerified,
			u.[Enabled] UserEnabled,
			CAST(CASE WHEN @CurrentDate > u.PasswordExpireDate THEN 1 ELSE 0 END AS BIT) PasswordExpired,
			p.[Type],
			p.[Default],
			--p.[Node].ToString() [Node],
			--p.[Enabled],
			PositionType.UserType,
			[Role].Name RoleName
		FROM org.Position p
			LEFT JOIN org.Department d ON p.DepartmentID = d.ID
			LEFT JOIN org.[User] u ON p.UserID = u.ID
			LEFT JOIN org.PositionType On PositionType.PositionType = p.[Type] AND PositionType.ApplicationID = p.ApplicationID
			LEFT JOIN org.Place Province ON d.ProvinceID = Province.ID
			LEFT JOIN PositionIDs ON PositionIDs.ID = p.ID
			LEFT JOIN PositionTypes ON PositionTypes.Type = p.Type
			LEFT JOIN org.PositionRole ON PositionRole.PositionID = p.ID
			LEFT JOIN org.[Role] ON [Role].ID = PositionRole.RoleID
		where (p.RemoverID IS NULL ) --AND parent.RemoverID IS NULL)
			AND (@IDs IS NULL OR PositionIDs.ID IS NOT NULL)
			AND (@ApplicationID IS NULL OR p.ApplicationID = @ApplicationID)
			AND (@DepartmentID IS NULL OR p.DepartmentID = @DepartmentID)
			AND (@DepartmentName IS NULL OR d.Name LIKE CONCAT('%', @DepartmentID, '%'))
			AND (@Type < 1 OR p.[Type] = @Type)
			AND (@Types IS NULL OR PositionTypes.Type IS NOT NULL)
			AND (@UserType < 1 OR PositionType.[UserType] = @UserType)
			AND (@UserID IS NULL OR COALESCE(p.UserID, 0x) = @UserID)
			AND (@NationalCode IS NULL OR u.NationalCode = @NationalCode)
			AND (@FirstName IS NULL OR u.FirstName LIKE CONCAT('%', @FirstName, '%'))
			AND (@LastName IS NULL OR u.LastName LIKE CONCAT('%', @LastName, '%'))
			AND (@Name IS NULL OR u.FirstName LIKE CONCAT('%', @Name, '%') OR u.LastName LIKE CONCAT('%', @Name, '%'))
			AND (@Email IS NULL OR u.Email LIKE @Email)
			AND (@Cellphone IS NULL OR u.Cellphone LIKE @Cellphone)
			--AND (@EnableState < 1 OR p.[Enabled] = @EnableState - 1)
			AND (@RoleID IS NULL OR RoleID = @RoleID)
		ORDER BY u.LastName
	)
	SELECT * FROM MainSelect
	ORDER BY LastName
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END
