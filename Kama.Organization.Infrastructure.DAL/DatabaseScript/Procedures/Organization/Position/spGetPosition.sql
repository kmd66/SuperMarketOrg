USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('org.spGetPosition'))
	DROP PROCEDURE org.spGetPosition
GO

CREATE PROCEDURE org.spGetPosition
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE  @ID UNIQUEIDENTIFIER = @AID,
		@CurrentDate SMALLDATETIME = GETDATE()
	
	SELECT p.ID
		, p.ApplicationID
		, p.DepartmentID
		, d.[Name] DepartmentName
		, d.[Type] DepartmentType
		, d.ProvinceID
		, Province.Name ProvinceName
		, p.UserID
		, u.Username
		, u.FirstName
		, u.LastName
		, u.NationalCode
		, u.Email
		, u.EmailVerified
		, u.CellPhone
		, u.CellPhoneVerified
		, u.[Enabled] UserEnabled
		, u.Foreigner
		, CAST(CASE WHEN @CurrentDate > u.PasswordExpireDate THEN 1 ELSE 0 END AS BIT) PasswordExpired
		, p.[Type]
		, p.[Default]
		--, p.[Enabled]
		--, p.[Node].ToString() [Node]
		--, parent.ID ParentID
		--, parent.[Node].ToString() [ParentNode]
		, PositionType.UserType
	FROM org.Position p
		LEFT JOIN org.Department d ON p.DepartmentID = d.id
		LEFT JOIN org.[User] u ON p.UserID = u.ID
		--LEFT JOIN org.Position parent ON p.Node.GetAncestor(1) = parent.Node AND parent.ApplicationID = p.ApplicationID
		LEFT JOIN org.Place Province ON d.ProvinceID = Province.ID
		LEFT JOIN org.PositionType On PositionType.PositionType = p.[Type] AND PositionType.ApplicationID = p.ApplicationID
	where (p.RemoverID IS NULL) -- AND parent.RemoverID IS NULL
		AND p.ID = @ID

	RETURN @@ROWCOUNT
END