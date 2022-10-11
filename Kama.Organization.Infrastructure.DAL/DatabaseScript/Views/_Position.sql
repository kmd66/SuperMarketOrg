USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.views WHERE [object_id] = OBJECT_ID('org._Position'))
	DROP VIEW org._Position
GO

CREATE VIEW org._Position
WITH ENCRYPTION, SCHEMABINDING
AS
	
	SELECT
		p.ID,
		p.ApplicationID ApplicationID,
		p.DepartmentID,
		d.[Name] DepartmentName,
		d.[Type] DepartmentType,
		d.ProvinceID,
		Province.Name ProvinceName,
		p.UserID,
		p.LastTokenDate,
		u.Username,
		u.FirstName,
		u.LastName,
		u.NationalCode,
		u.Email,
		u.EmailVerified,
		u.CellPhone,
		u.CellPhoneVerified,
		u.[Enabled] UserEnabled,
		u.Foreigner,
		u.PasswordExpireDate,
		p.[Type],
		p.[Default],
		PositionType.UserType
	FROM org.Position p
		LEFT JOIN org.Department d ON p.DepartmentID = d.ID
		LEFT JOIN org.[User] u ON p.UserID = u.ID
		LEFT JOIN org.PositionType On PositionType.PositionType = p.[Type] AND PositionType.ApplicationID = p.ApplicationID
		LEFT JOIN org.Place Province ON d.ProvinceID = Province.ID
	where p.RemoverID IS NULL