using System;
using Kama.DatabaseModel;
using System.Threading.Tasks;
 using System.Collections.Generic;

namespace Kama.Organization.Infrastructure.DAL
{
class ORG: Database
{
#region Constructors
public ORG(string connectionString)
	:base(connectionString){}

public ORG(string connectionString, IModelValueBinder modelValueBinder)
	:base(connectionString, modelValueBinder){}
#endregion

#region SetPositionTypeRoles

public System.Data.SqlClient.SqlCommand GetCommand_SetPositionTypeRoles(Guid? _applicationID, byte? _positionType, string _roleIDs, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spSetPositionTypeRoles", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@ARoleIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_roleIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_roleIDs) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetPositionTypeRolesAsync(Guid? _applicationID, byte? _positionType, string _roleIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetPositionTypeRoles(_applicationID, _positionType, _roleIDs, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetPositionTypeRolesDapperAsync<T>(Guid? _applicationID, byte? _positionType, string _roleIDs, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spSetPositionTypeRoles",new {AApplicationID=_applicationID,APositionType=_positionType,ARoleIDs=string.IsNullOrWhiteSpace(_roleIDs) ? _roleIDs : ReplaceArabicWithPersianChars(_roleIDs),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetPositionTypeRoles(Guid? _applicationID, byte? _positionType, string _roleIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetPositionTypeRoles(_applicationID, _positionType, _roleIDs, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetSecurityStampByCellPhone

public System.Data.SqlClient.SqlCommand GetCommand_SetSecurityStampByCellPhone(string _cellPhone, string _stamp, int? timeout = null)
{
var cmd = base.CreateCommand("org.spSetSecurityStampByCellPhone", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACellPhone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellPhone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellPhone) }, 
					new Parameter { Name = "@AStamp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_stamp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_stamp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetSecurityStampByCellPhoneAsync(string _cellPhone, string _stamp, int? timeout = null)
{
	using(var cmd = GetCommand_SetSecurityStampByCellPhone(_cellPhone, _stamp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetSecurityStampByCellPhoneDapperAsync<T>(string _cellPhone, string _stamp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spSetSecurityStampByCellPhone",new {ACellPhone=string.IsNullOrWhiteSpace(_cellPhone) ? _cellPhone : ReplaceArabicWithPersianChars(_cellPhone),AStamp=string.IsNullOrWhiteSpace(_stamp) ? _stamp : ReplaceArabicWithPersianChars(_stamp)} , timeout );
}

public ResultSet SetSecurityStampByCellPhone(string _cellPhone, string _stamp, int? timeout = null)
{
	using(var cmd = GetCommand_SetSecurityStampByCellPhone(_cellPhone, _stamp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetSecurityStampByEmail

public System.Data.SqlClient.SqlCommand GetCommand_SetSecurityStampByEmail(string _email, string _stamp, int? timeout = null)
{
var cmd = base.CreateCommand("org.spSetSecurityStampByEmail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@AStamp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_stamp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_stamp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetSecurityStampByEmailAsync(string _email, string _stamp, int? timeout = null)
{
	using(var cmd = GetCommand_SetSecurityStampByEmail(_email, _stamp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetSecurityStampByEmailDapperAsync<T>(string _email, string _stamp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spSetSecurityStampByEmail",new {AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),AStamp=string.IsNullOrWhiteSpace(_stamp) ? _stamp : ReplaceArabicWithPersianChars(_stamp)} , timeout );
}

public ResultSet SetSecurityStampByEmail(string _email, string _stamp, int? timeout = null)
{
	using(var cmd = GetCommand_SetSecurityStampByEmail(_email, _stamp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetUserPassword

public System.Data.SqlClient.SqlCommand GetCommand_SetUserPassword(Guid? _id, string _password, DateTime? _passwordExpireDate, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spSetUserPassword", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
					new Parameter { Name = "@APasswordExpireDate", IsOutput = false, Value = _passwordExpireDate == null ? DBNull.Value : (object)_passwordExpireDate }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetUserPasswordAsync(Guid? _id, string _password, DateTime? _passwordExpireDate, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetUserPassword(_id, _password, _passwordExpireDate, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetUserPasswordDapperAsync<T>(Guid? _id, string _password, DateTime? _passwordExpireDate, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spSetUserPassword",new {AID=_id,APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password),APasswordExpireDate=_passwordExpireDate,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetUserPassword(Guid? _id, string _password, DateTime? _passwordExpireDate, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetUserPassword(_id, _password, _passwordExpireDate, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region VerifyUserCellPhone

public System.Data.SqlClient.SqlCommand GetCommand_VerifyUserCellPhone(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spVerifyUserCellPhone", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AIsVerified", IsOutput = false, Value = _isVerified == null ? DBNull.Value : (object)_isVerified }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> VerifyUserCellPhoneAsync(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_VerifyUserCellPhone(_userID, _isVerified, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> VerifyUserCellPhoneDapperAsync<T>(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spVerifyUserCellPhone",new {AUserID=_userID,AIsVerified=_isVerified,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet VerifyUserCellPhone(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_VerifyUserCellPhone(_userID, _isVerified, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeletePlace

public System.Data.SqlClient.SqlCommand GetCommand_DeletePlace(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeletePlace", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeletePlaceAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePlace(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeletePlaceDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeletePlace",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeletePlace(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePlace(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region VerifyUserEmail

public System.Data.SqlClient.SqlCommand GetCommand_VerifyUserEmail(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spVerifyUserEmail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AIsVerified", IsOutput = false, Value = _isVerified == null ? DBNull.Value : (object)_isVerified }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> VerifyUserEmailAsync(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_VerifyUserEmail(_userID, _isVerified, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> VerifyUserEmailDapperAsync<T>(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spVerifyUserEmail",new {AUserID=_userID,AIsVerified=_isVerified,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet VerifyUserEmail(Guid? _userID, bool? _isVerified, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_VerifyUserEmail(_userID, _isVerified, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeletePosition

public System.Data.SqlClient.SqlCommand GetCommand_DeletePosition(Guid? _id, Guid? _removerID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeletePosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ARemoverID", IsOutput = false, Value = _removerID == null ? DBNull.Value : (object)_removerID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeletePositionAsync(Guid? _id, Guid? _removerID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePosition(_id, _removerID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeletePositionDapperAsync<T>(Guid? _id, Guid? _removerID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeletePosition",new {AID=_id,ARemoverID=_removerID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeletePosition(Guid? _id, Guid? _removerID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePosition(_id, _removerID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeletePositionHistory

public System.Data.SqlClient.SqlCommand GetCommand_DeletePositionHistory(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeletePositionHistory", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeletePositionHistoryAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePositionHistory(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeletePositionHistoryDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeletePositionHistory",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeletePositionHistory(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeletePositionHistory(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteRefreshToken

public System.Data.SqlClient.SqlCommand GetCommand_DeleteRefreshToken(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteRefreshToken", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteRefreshTokenAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteRefreshToken(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteRefreshTokenDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteRefreshToken",new {AID=_id} , timeout );
}

public ResultSet DeleteRefreshToken(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteRefreshToken(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteRole

public System.Data.SqlClient.SqlCommand GetCommand_DeleteRole(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteRole", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteRoleAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteRole(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteRoleDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteRole",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteRole(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteRole(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteUser

public System.Data.SqlClient.SqlCommand GetCommand_DeleteUser(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteUserAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteUser(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteUserDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteUser",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteUser(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteUser(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteWebServiceUser

public System.Data.SqlClient.SqlCommand GetCommand_DeleteWebServiceUser(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteWebServiceUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteWebServiceUserAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteWebServiceUser(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteWebServiceUserDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteWebServiceUser",new {AID=_id} , timeout );
}

public ResultSet DeleteWebServiceUser(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteWebServiceUser(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplication

public System.Data.SqlClient.SqlCommand GetCommand_GetApplication(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetApplication", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplication(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetApplication",new {AID=_id} , timeout );
}

public ResultSet GetApplication(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplication(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplications

public System.Data.SqlClient.SqlCommand GetCommand_GetApplications(string _name, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetApplications", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationsAsync(string _name, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplications(_name, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationsDapperAsync<T>(string _name, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetApplications",new {AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name)} , timeout );
}

public ResultSet GetApplications(string _name, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplications(_name, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetClient

public System.Data.SqlClient.SqlCommand GetCommand_GetClient(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetClient", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetClientAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetClient(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetClientDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetClient",new {AID=_id} , timeout );
}

public ResultSet GetClient(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetClient(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetClients

public System.Data.SqlClient.SqlCommand GetCommand_GetClients(Guid? _applicationID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetClients", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetClientsAsync(Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClients(_applicationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetClientsDapperAsync<T>(Guid? _applicationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetClients",new {AApplicationID=_applicationID} , timeout );
}

public ResultSet GetClients(Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetClients(_applicationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetCommand

public System.Data.SqlClient.SqlCommand GetCommand_GetCommand(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetCommand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetCommandAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetCommand(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetCommandDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetCommand",new {AID=_id} , timeout );
}

public ResultSet GetCommand(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetCommand(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetCommands

public System.Data.SqlClient.SqlCommand GetCommand_GetCommands(Guid? _applicationID, Guid? _roleID, Guid? _parentID, string _name, string _title, byte? _type, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetCommands", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ARoleID", IsOutput = false, Value = _roleID == null ? DBNull.Value : (object)_roleID }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetCommandsAsync(Guid? _applicationID, Guid? _roleID, Guid? _parentID, string _name, string _title, byte? _type, int? timeout = null)
{
	using(var cmd = GetCommand_GetCommands(_applicationID, _roleID, _parentID, _name, _title, _type, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetCommandsDapperAsync<T>(Guid? _applicationID, Guid? _roleID, Guid? _parentID, string _name, string _title, byte? _type, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetCommands",new {AApplicationID=_applicationID,ARoleID=_roleID,AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AType=_type} , timeout );
}

public ResultSet GetCommands(Guid? _applicationID, Guid? _roleID, Guid? _parentID, string _name, string _title, byte? _type, int? timeout = null)
{
	using(var cmd = GetCommand_GetCommands(_applicationID, _roleID, _parentID, _name, _title, _type, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDepartment

public System.Data.SqlClient.SqlCommand GetCommand_GetDepartment(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDepartment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDepartmentAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepartment(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDepartmentDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDepartment",new {AID=_id} , timeout );
}

public ResultSet GetDepartment(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepartment(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDepartments

public System.Data.SqlClient.SqlCommand GetCommand_GetDepartments(Guid? _parentID, Guid? _provinceID, byte? _type, string _code, string _name, bool? _searchWithHierarchy, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDepartments", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AProvinceID", IsOutput = false, Value = _provinceID == null ? DBNull.Value : (object)_provinceID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ACode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_code) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_code) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@ASearchWithHierarchy", IsOutput = false, Value = _searchWithHierarchy == null ? DBNull.Value : (object)_searchWithHierarchy }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDepartmentsAsync(Guid? _parentID, Guid? _provinceID, byte? _type, string _code, string _name, bool? _searchWithHierarchy, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepartments(_parentID, _provinceID, _type, _code, _name, _searchWithHierarchy, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDepartmentsDapperAsync<T>(Guid? _parentID, Guid? _provinceID, byte? _type, string _code, string _name, bool? _searchWithHierarchy, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDepartments",new {AParentID=_parentID,AProvinceID=_provinceID,AType=_type,ACode=string.IsNullOrWhiteSpace(_code) ? _code : ReplaceArabicWithPersianChars(_code),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),ASearchWithHierarchy=_searchWithHierarchy,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetDepartments(Guid? _parentID, Guid? _provinceID, byte? _type, string _code, string _name, bool? _searchWithHierarchy, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDepartments(_parentID, _provinceID, _type, _code, _name, _searchWithHierarchy, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDynamicPermission

public System.Data.SqlClient.SqlCommand GetCommand_GetDynamicPermission(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDynamicPermission", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDynamicPermissionAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermission(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDynamicPermissionDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDynamicPermission",new {AID=_id} , timeout );
}

public ResultSet GetDynamicPermission(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermission(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDynamicPermissionDetails

public System.Data.SqlClient.SqlCommand GetCommand_GetDynamicPermissionDetails(string _dynamicPermissionIDs, Guid? _dynamicPermissionID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDynamicPermissionDetails", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ADynamicPermissionIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_dynamicPermissionIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_dynamicPermissionIDs) }, 
					new Parameter { Name = "@ADynamicPermissionID", IsOutput = false, Value = _dynamicPermissionID == null ? DBNull.Value : (object)_dynamicPermissionID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDynamicPermissionDetailsAsync(string _dynamicPermissionIDs, Guid? _dynamicPermissionID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionDetails(_dynamicPermissionIDs, _dynamicPermissionID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDynamicPermissionDetailsDapperAsync<T>(string _dynamicPermissionIDs, Guid? _dynamicPermissionID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDynamicPermissionDetails",new {ADynamicPermissionIDs=string.IsNullOrWhiteSpace(_dynamicPermissionIDs) ? _dynamicPermissionIDs : ReplaceArabicWithPersianChars(_dynamicPermissionIDs),ADynamicPermissionID=_dynamicPermissionID} , timeout );
}

public ResultSet GetDynamicPermissionDetails(string _dynamicPermissionIDs, Guid? _dynamicPermissionID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionDetails(_dynamicPermissionIDs, _dynamicPermissionID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDynamicPermissionObjectsByPosition

public System.Data.SqlClient.SqlCommand GetCommand_GetDynamicPermissionObjectsByPosition(Guid? _positionID, Guid? _applicationID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDynamicPermissionObjectsByPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDynamicPermissionObjectsByPositionAsync(Guid? _positionID, Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionObjectsByPosition(_positionID, _applicationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDynamicPermissionObjectsByPositionDapperAsync<T>(Guid? _positionID, Guid? _applicationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDynamicPermissionObjectsByPosition",new {APositionID=_positionID,AApplicationID=_applicationID} , timeout );
}

public ResultSet GetDynamicPermissionObjectsByPosition(Guid? _positionID, Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionObjectsByPosition(_positionID, _applicationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDynamicPermissionPositions

public System.Data.SqlClient.SqlCommand GetCommand_GetDynamicPermissionPositions(Guid? _objectID, Guid? _applicationID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDynamicPermissionPositions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AObjectID", IsOutput = false, Value = _objectID == null ? DBNull.Value : (object)_objectID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDynamicPermissionPositionsAsync(Guid? _objectID, Guid? _applicationID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionPositions(_objectID, _applicationID, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDynamicPermissionPositionsDapperAsync<T>(Guid? _objectID, Guid? _applicationID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDynamicPermissionPositions",new {AObjectID=_objectID,AApplicationID=_applicationID,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetDynamicPermissionPositions(Guid? _objectID, Guid? _applicationID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissionPositions(_objectID, _applicationID, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDynamicPermissions

public System.Data.SqlClient.SqlCommand GetCommand_GetDynamicPermissions(Guid? _objectID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetDynamicPermissions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AObjectID", IsOutput = false, Value = _objectID == null ? DBNull.Value : (object)_objectID }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDynamicPermissionsAsync(Guid? _objectID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissions(_objectID, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDynamicPermissionsDapperAsync<T>(Guid? _objectID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetDynamicPermissions",new {AObjectID=_objectID,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetDynamicPermissions(Guid? _objectID, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetDynamicPermissions(_objectID, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetModifyUserValidation

public System.Data.SqlClient.SqlCommand GetCommand_GetModifyUserValidation(Guid? _id, string _nationalCode, string _username, string _cellPhone, string _email, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetModifyUserValidation", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AUsername", IsOutput = false, Value = string.IsNullOrWhiteSpace(_username) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_username) }, 
					new Parameter { Name = "@ACellPhone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellPhone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellPhone) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetModifyUserValidationAsync(Guid? _id, string _nationalCode, string _username, string _cellPhone, string _email, int? timeout = null)
{
	using(var cmd = GetCommand_GetModifyUserValidation(_id, _nationalCode, _username, _cellPhone, _email, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetModifyUserValidationDapperAsync<T>(Guid? _id, string _nationalCode, string _username, string _cellPhone, string _email, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetModifyUserValidation",new {AID=_id,ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AUsername=string.IsNullOrWhiteSpace(_username) ? _username : ReplaceArabicWithPersianChars(_username),ACellPhone=string.IsNullOrWhiteSpace(_cellPhone) ? _cellPhone : ReplaceArabicWithPersianChars(_cellPhone),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email)} , timeout );
}

public ResultSet GetModifyUserValidation(Guid? _id, string _nationalCode, string _username, string _cellPhone, string _email, int? timeout = null)
{
	using(var cmd = GetCommand_GetModifyUserValidation(_id, _nationalCode, _username, _cellPhone, _email, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetOnlineUsersAndPositionsCount

public System.Data.SqlClient.SqlCommand GetCommand_GetOnlineUsersAndPositionsCount(Guid? _applicationID, int? _accessTokenExpireTimeSpan, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetOnlineUsersAndPositionsCount", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AAccessTokenExpireTimeSpan", IsOutput = false, Value = _accessTokenExpireTimeSpan == null ? DBNull.Value : (object)_accessTokenExpireTimeSpan }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetOnlineUsersAndPositionsCountAsync(Guid? _applicationID, int? _accessTokenExpireTimeSpan, int? timeout = null)
{
	using(var cmd = GetCommand_GetOnlineUsersAndPositionsCount(_applicationID, _accessTokenExpireTimeSpan, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetOnlineUsersAndPositionsCountDapperAsync<T>(Guid? _applicationID, int? _accessTokenExpireTimeSpan, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetOnlineUsersAndPositionsCount",new {AApplicationID=_applicationID,AAccessTokenExpireTimeSpan=_accessTokenExpireTimeSpan} , timeout );
}

public ResultSet GetOnlineUsersAndPositionsCount(Guid? _applicationID, int? _accessTokenExpireTimeSpan, int? timeout = null)
{
	using(var cmd = GetCommand_GetOnlineUsersAndPositionsCount(_applicationID, _accessTokenExpireTimeSpan, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPlace

public System.Data.SqlClient.SqlCommand GetCommand_GetPlace(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPlace", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPlaceAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPlace(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPlaceDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPlace",new {AID=_id} , timeout );
}

public ResultSet GetPlace(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPlace(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPlaces

public System.Data.SqlClient.SqlCommand GetCommand_GetPlaces(string _iDs, Guid? _parentID, byte? _type, int? _ancestorLevel, string _name, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPlaces", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_iDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_iDs) }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AAncestorLevel", IsOutput = false, Value = _ancestorLevel == null ? DBNull.Value : (object)_ancestorLevel }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPlacesAsync(string _iDs, Guid? _parentID, byte? _type, int? _ancestorLevel, string _name, int? timeout = null)
{
	using(var cmd = GetCommand_GetPlaces(_iDs, _parentID, _type, _ancestorLevel, _name, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPlacesDapperAsync<T>(string _iDs, Guid? _parentID, byte? _type, int? _ancestorLevel, string _name, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPlaces",new {AIDs=string.IsNullOrWhiteSpace(_iDs) ? _iDs : ReplaceArabicWithPersianChars(_iDs),AParentID=_parentID,AType=_type,AAncestorLevel=_ancestorLevel,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name)} , timeout );
}

public ResultSet GetPlaces(string _iDs, Guid? _parentID, byte? _type, int? _ancestorLevel, string _name, int? timeout = null)
{
	using(var cmd = GetCommand_GetPlaces(_iDs, _parentID, _type, _ancestorLevel, _name, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPosition

public System.Data.SqlClient.SqlCommand GetCommand_GetPosition(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPosition(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPosition",new {AID=_id} , timeout );
}

public ResultSet GetPosition(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPosition(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionDepartmentMappings

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionDepartmentMappings(Guid? _applicationID, byte? _positionType, byte? _departmentType, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionDepartmentMappings", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@ADepartmentType", IsOutput = false, Value = _departmentType == null ? DBNull.Value : (object)_departmentType }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionDepartmentMappingsAsync(Guid? _applicationID, byte? _positionType, byte? _departmentType, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionDepartmentMappings(_applicationID, _positionType, _departmentType, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionDepartmentMappingsDapperAsync<T>(Guid? _applicationID, byte? _positionType, byte? _departmentType, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionDepartmentMappings",new {AApplicationID=_applicationID,APositionType=_positionType,ADepartmentType=_departmentType,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetPositionDepartmentMappings(Guid? _applicationID, byte? _positionType, byte? _departmentType, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionDepartmentMappings(_applicationID, _positionType, _departmentType, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionHistory

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionHistory(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionHistory", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionHistoryAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionHistory(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionHistoryDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionHistory",new {AID=_id} , timeout );
}

public ResultSet GetPositionHistory(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionHistory(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionPermissions

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionPermissions(Guid? _positionID, Guid? _commandID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionPermissions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@ACommandID", IsOutput = false, Value = _commandID == null ? DBNull.Value : (object)_commandID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionPermissionsAsync(Guid? _positionID, Guid? _commandID, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionPermissions(_positionID, _commandID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionPermissionsDapperAsync<T>(Guid? _positionID, Guid? _commandID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionPermissions",new {APositionID=_positionID,ACommandID=_commandID} , timeout );
}

public ResultSet GetPositionPermissions(Guid? _positionID, Guid? _commandID, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionPermissions(_positionID, _commandID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositions

public System.Data.SqlClient.SqlCommand GetCommand_GetPositions(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_iDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_iDs) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ADepartmentID", IsOutput = false, Value = _departmentID == null ? DBNull.Value : (object)_departmentID }, 
					new Parameter { Name = "@ADepartmentName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_departmentName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_departmentName) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ATypes", IsOutput = false, Value = string.IsNullOrWhiteSpace(_types) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_types) }, 
					new Parameter { Name = "@AUserType", IsOutput = false, Value = _userType == null ? DBNull.Value : (object)_userType }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AFirstName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_firstName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_firstName) }, 
					new Parameter { Name = "@ALastName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_lastName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_lastName) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@ACellphone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellphone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellphone) }, 
					new Parameter { Name = "@AEnableState", IsOutput = false, Value = _enableState == null ? DBNull.Value : (object)_enableState }, 
					new Parameter { Name = "@ARoleID", IsOutput = false, Value = _roleID == null ? DBNull.Value : (object)_roleID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionsAsync(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositions(_iDs, _applicationID, _departmentID, _departmentName, _type, _types, _userType, _userID, _nationalCode, _name, _firstName, _lastName, _email, _cellphone, _enableState, _roleID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionsDapperAsync<T>(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositions",new {AIDs=string.IsNullOrWhiteSpace(_iDs) ? _iDs : ReplaceArabicWithPersianChars(_iDs),AApplicationID=_applicationID,ADepartmentID=_departmentID,ADepartmentName=string.IsNullOrWhiteSpace(_departmentName) ? _departmentName : ReplaceArabicWithPersianChars(_departmentName),AType=_type,ATypes=string.IsNullOrWhiteSpace(_types) ? _types : ReplaceArabicWithPersianChars(_types),AUserType=_userType,AUserID=_userID,ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AFirstName=string.IsNullOrWhiteSpace(_firstName) ? _firstName : ReplaceArabicWithPersianChars(_firstName),ALastName=string.IsNullOrWhiteSpace(_lastName) ? _lastName : ReplaceArabicWithPersianChars(_lastName),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),ACellphone=string.IsNullOrWhiteSpace(_cellphone) ? _cellphone : ReplaceArabicWithPersianChars(_cellphone),AEnableState=_enableState,ARoleID=_roleID,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetPositions(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositions(_iDs, _applicationID, _departmentID, _departmentName, _type, _types, _userType, _userID, _nationalCode, _name, _firstName, _lastName, _email, _cellphone, _enableState, _roleID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionsWithRoles

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionsWithRoles(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionsWithRoles", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_iDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_iDs) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ADepartmentID", IsOutput = false, Value = _departmentID == null ? DBNull.Value : (object)_departmentID }, 
					new Parameter { Name = "@ADepartmentName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_departmentName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_departmentName) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ATypes", IsOutput = false, Value = string.IsNullOrWhiteSpace(_types) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_types) }, 
					new Parameter { Name = "@AUserType", IsOutput = false, Value = _userType == null ? DBNull.Value : (object)_userType }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AFirstName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_firstName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_firstName) }, 
					new Parameter { Name = "@ALastName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_lastName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_lastName) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@ACellphone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellphone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellphone) }, 
					new Parameter { Name = "@AEnableState", IsOutput = false, Value = _enableState == null ? DBNull.Value : (object)_enableState }, 
					new Parameter { Name = "@ARoleID", IsOutput = false, Value = _roleID == null ? DBNull.Value : (object)_roleID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionsWithRolesAsync(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionsWithRoles(_iDs, _applicationID, _departmentID, _departmentName, _type, _types, _userType, _userID, _nationalCode, _name, _firstName, _lastName, _email, _cellphone, _enableState, _roleID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionsWithRolesDapperAsync<T>(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionsWithRoles",new {AIDs=string.IsNullOrWhiteSpace(_iDs) ? _iDs : ReplaceArabicWithPersianChars(_iDs),AApplicationID=_applicationID,ADepartmentID=_departmentID,ADepartmentName=string.IsNullOrWhiteSpace(_departmentName) ? _departmentName : ReplaceArabicWithPersianChars(_departmentName),AType=_type,ATypes=string.IsNullOrWhiteSpace(_types) ? _types : ReplaceArabicWithPersianChars(_types),AUserType=_userType,AUserID=_userID,ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AFirstName=string.IsNullOrWhiteSpace(_firstName) ? _firstName : ReplaceArabicWithPersianChars(_firstName),ALastName=string.IsNullOrWhiteSpace(_lastName) ? _lastName : ReplaceArabicWithPersianChars(_lastName),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),ACellphone=string.IsNullOrWhiteSpace(_cellphone) ? _cellphone : ReplaceArabicWithPersianChars(_cellphone),AEnableState=_enableState,ARoleID=_roleID,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetPositionsWithRoles(string _iDs, Guid? _applicationID, Guid? _departmentID, string _departmentName, byte? _type, string _types, byte? _userType, Guid? _userID, string _nationalCode, string _name, string _firstName, string _lastName, string _email, string _cellphone, byte? _enableState, Guid? _roleID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionsWithRoles(_iDs, _applicationID, _departmentID, _departmentName, _type, _types, _userType, _userID, _nationalCode, _name, _firstName, _lastName, _email, _cellphone, _enableState, _roleID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionType

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionType(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionType", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionTypeAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionType(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionTypeDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionType",new {AID=_id} , timeout );
}

public ResultSet GetPositionType(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionType(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionTypeRoles

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionTypeRoles(Guid? _applicationID, byte? _positionType, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionTypeRoles", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionTypeRolesAsync(Guid? _applicationID, byte? _positionType, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionTypeRoles(_applicationID, _positionType, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionTypeRolesDapperAsync<T>(Guid? _applicationID, byte? _positionType, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionTypeRoles",new {AApplicationID=_applicationID,APositionType=_positionType} , timeout );
}

public ResultSet GetPositionTypeRoles(Guid? _applicationID, byte? _positionType, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionTypeRoles(_applicationID, _positionType, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPositionTypes

public System.Data.SqlClient.SqlCommand GetCommand_GetPositionTypes(Guid? _applicationID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetPositionTypes", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPositionTypesAsync(Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionTypes(_applicationID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPositionTypesDapperAsync<T>(Guid? _applicationID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetPositionTypes",new {AApplicationID=_applicationID} , timeout );
}

public ResultSet GetPositionTypes(Guid? _applicationID, int? timeout = null)
{
	using(var cmd = GetCommand_GetPositionTypes(_applicationID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetRefreshToken

public System.Data.SqlClient.SqlCommand GetCommand_GetRefreshToken(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetRefreshToken", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetRefreshTokenAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetRefreshToken(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetRefreshTokenDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetRefreshToken",new {AID=_id} , timeout );
}

public ResultSet GetRefreshToken(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetRefreshToken(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetRole

public System.Data.SqlClient.SqlCommand GetCommand_GetRole(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetRole", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetRoleAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetRole(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetRoleDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetRole",new {AID=_id} , timeout );
}

public ResultSet GetRole(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetRole(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetRoles

public System.Data.SqlClient.SqlCommand GetCommand_GetRoles(Guid? _applicationID, string _name, byte? _positionType, Guid? _positionID, Guid? _userID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetRoles", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetRolesAsync(Guid? _applicationID, string _name, byte? _positionType, Guid? _positionID, Guid? _userID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetRoles(_applicationID, _name, _positionType, _positionID, _userID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetRolesDapperAsync<T>(Guid? _applicationID, string _name, byte? _positionType, Guid? _positionID, Guid? _userID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetRoles",new {AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),APositionType=_positionType,APositionID=_positionID,AUserID=_userID,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetRoles(Guid? _applicationID, string _name, byte? _positionType, Guid? _positionID, Guid? _userID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetRoles(_applicationID, _name, _positionType, _positionID, _userID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetSecurityStampByCellPhone

public System.Data.SqlClient.SqlCommand GetCommand_GetSecurityStampByCellPhone(string _cellPhone, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetSecurityStampByCellPhone", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACellPhone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellPhone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellPhone) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetSecurityStampByCellPhoneAsync(string _cellPhone, int? timeout = null)
{
	using(var cmd = GetCommand_GetSecurityStampByCellPhone(_cellPhone, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetSecurityStampByCellPhoneDapperAsync<T>(string _cellPhone, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetSecurityStampByCellPhone",new {ACellPhone=string.IsNullOrWhiteSpace(_cellPhone) ? _cellPhone : ReplaceArabicWithPersianChars(_cellPhone)} , timeout );
}

public ResultSet GetSecurityStampByCellPhone(string _cellPhone, int? timeout = null)
{
	using(var cmd = GetCommand_GetSecurityStampByCellPhone(_cellPhone, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetSecurityStampByEmail

public System.Data.SqlClient.SqlCommand GetCommand_GetSecurityStampByEmail(string _email, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetSecurityStampByEmail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetSecurityStampByEmailAsync(string _email, int? timeout = null)
{
	using(var cmd = GetCommand_GetSecurityStampByEmail(_email, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetSecurityStampByEmailDapperAsync<T>(string _email, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetSecurityStampByEmail",new {AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email)} , timeout );
}

public ResultSet GetSecurityStampByEmail(string _email, int? timeout = null)
{
	using(var cmd = GetCommand_GetSecurityStampByEmail(_email, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetSuperiorPosition

public System.Data.SqlClient.SqlCommand GetCommand_GetSuperiorPosition(Guid? _magistrateID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetSuperiorPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AMagistrateID", IsOutput = false, Value = _magistrateID == null ? DBNull.Value : (object)_magistrateID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetSuperiorPositionAsync(Guid? _magistrateID, int? timeout = null)
{
	using(var cmd = GetCommand_GetSuperiorPosition(_magistrateID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetSuperiorPositionDapperAsync<T>(Guid? _magistrateID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetSuperiorPosition",new {AMagistrateID=_magistrateID} , timeout );
}

public ResultSet GetSuperiorPosition(Guid? _magistrateID, int? timeout = null)
{
	using(var cmd = GetCommand_GetSuperiorPosition(_magistrateID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetUser

public System.Data.SqlClient.SqlCommand GetCommand_GetUser(Guid? _id, string _userName, string _nationalCode, string _email, string _password, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AUserName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_userName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_userName) }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetUserAsync(Guid? _id, string _userName, string _nationalCode, string _email, string _password, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUser(_id, _userName, _nationalCode, _email, _password, _applicationID, _currentUserID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetUserDapperAsync<T>(Guid? _id, string _userName, string _nationalCode, string _email, string _password, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetUser",new {AID=_id,AUserName=string.IsNullOrWhiteSpace(_userName) ? _userName : ReplaceArabicWithPersianChars(_userName),ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password),AApplicationID=_applicationID,ACurrentUserID=_currentUserID} , timeout );
}

public ResultSet GetUser(Guid? _id, string _userName, string _nationalCode, string _email, string _password, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUser(_id, _userName, _nationalCode, _email, _password, _applicationID, _currentUserID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetUserByUserNameOrEmail

public System.Data.SqlClient.SqlCommand GetCommand_GetUserByUserNameOrEmail(string _username, string _email, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetUserByUserNameOrEmail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUsername", IsOutput = false, Value = string.IsNullOrWhiteSpace(_username) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_username) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetUserByUserNameOrEmailAsync(string _username, string _email, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUserByUserNameOrEmail(_username, _email, _applicationID, _currentUserID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetUserByUserNameOrEmailDapperAsync<T>(string _username, string _email, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetUserByUserNameOrEmail",new {AUsername=string.IsNullOrWhiteSpace(_username) ? _username : ReplaceArabicWithPersianChars(_username),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),AApplicationID=_applicationID,ACurrentUserID=_currentUserID} , timeout );
}

public ResultSet GetUserByUserNameOrEmail(string _username, string _email, Guid? _applicationID, Guid? _currentUserID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUserByUserNameOrEmail(_username, _email, _applicationID, _currentUserID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetUsers

public System.Data.SqlClient.SqlCommand GetCommand_GetUsers(Guid? _applicationID, string _nationalCode, string _name, string _email, string _cellphone, byte? _enablOrDisable, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetUsers", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@ACellphone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellphone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellphone) }, 
					new Parameter { Name = "@AEnablOrDisable", IsOutput = false, Value = _enablOrDisable == null ? DBNull.Value : (object)_enablOrDisable }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetUsersAsync(Guid? _applicationID, string _nationalCode, string _name, string _email, string _cellphone, byte? _enablOrDisable, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetUsers(_applicationID, _nationalCode, _name, _email, _cellphone, _enablOrDisable, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetUsersDapperAsync<T>(Guid? _applicationID, string _nationalCode, string _name, string _email, string _cellphone, byte? _enablOrDisable, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetUsers",new {AApplicationID=_applicationID,ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),ACellphone=string.IsNullOrWhiteSpace(_cellphone) ? _cellphone : ReplaceArabicWithPersianChars(_cellphone),AEnablOrDisable=_enablOrDisable,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetUsers(Guid? _applicationID, string _nationalCode, string _name, string _email, string _cellphone, byte? _enablOrDisable, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetUsers(_applicationID, _nationalCode, _name, _email, _cellphone, _enablOrDisable, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetUserSetting

public System.Data.SqlClient.SqlCommand GetCommand_GetUserSetting(Guid? _userID, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetUserSetting", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetUserSettingAsync(Guid? _userID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUserSetting(_userID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetUserSettingDapperAsync<T>(Guid? _userID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetUserSetting",new {AUserID=_userID} , timeout );
}

public ResultSet GetUserSetting(Guid? _userID, int? timeout = null)
{
	using(var cmd = GetCommand_GetUserSetting(_userID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetWebServiceUser

public System.Data.SqlClient.SqlCommand GetCommand_GetWebServiceUser(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetWebServiceUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetWebServiceUserAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUser(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetWebServiceUserDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetWebServiceUser",new {AID=_id} , timeout );
}

public ResultSet GetWebServiceUser(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUser(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetWebServiceUserByUserPass

public System.Data.SqlClient.SqlCommand GetCommand_GetWebServiceUserByUserPass(string _userName, string _password, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetWebServiceUserByUserPass", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_userName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_userName) }, 
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetWebServiceUserByUserPassAsync(string _userName, string _password, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUserByUserPass(_userName, _password, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetWebServiceUserByUserPassDapperAsync<T>(string _userName, string _password, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetWebServiceUserByUserPass",new {AUserName=string.IsNullOrWhiteSpace(_userName) ? _userName : ReplaceArabicWithPersianChars(_userName),APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password)} , timeout );
}

public ResultSet GetWebServiceUserByUserPass(string _userName, string _password, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUserByUserPass(_userName, _password, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetWebServiceUsers

public System.Data.SqlClient.SqlCommand GetCommand_GetWebServiceUsers(string _userName, Guid? _organID, byte? _enableState, string _comment, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("org.spGetWebServiceUsers", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_userName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_userName) }, 
					new Parameter { Name = "@AOrganID", IsOutput = false, Value = _organID == null ? DBNull.Value : (object)_organID }, 
					new Parameter { Name = "@AEnableState", IsOutput = false, Value = _enableState == null ? DBNull.Value : (object)_enableState }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetWebServiceUsersAsync(string _userName, Guid? _organID, byte? _enableState, string _comment, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUsers(_userName, _organID, _enableState, _comment, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetWebServiceUsersDapperAsync<T>(string _userName, Guid? _organID, byte? _enableState, string _comment, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spGetWebServiceUsers",new {AUserName=string.IsNullOrWhiteSpace(_userName) ? _userName : ReplaceArabicWithPersianChars(_userName),AOrganID=_organID,AEnableState=_enableState,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp),APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetWebServiceUsers(string _userName, Guid? _organID, byte? _enableState, string _comment, string _sortExp, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetWebServiceUsers(_userName, _organID, _enableState, _comment, _sortExp, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region MapDepartmentsToPosition

public System.Data.SqlClient.SqlCommand GetCommand_MapDepartmentsToPosition(Guid? _applicationID, byte? _positionType, string _mappings, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spMapDepartmentsToPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@AMappings", IsOutput = false, Value = string.IsNullOrWhiteSpace(_mappings) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_mappings) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> MapDepartmentsToPositionAsync(Guid? _applicationID, byte? _positionType, string _mappings, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_MapDepartmentsToPosition(_applicationID, _positionType, _mappings, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> MapDepartmentsToPositionDapperAsync<T>(Guid? _applicationID, byte? _positionType, string _mappings, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spMapDepartmentsToPosition",new {AApplicationID=_applicationID,APositionType=_positionType,AMappings=string.IsNullOrWhiteSpace(_mappings) ? _mappings : ReplaceArabicWithPersianChars(_mappings),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet MapDepartmentsToPosition(Guid? _applicationID, byte? _positionType, string _mappings, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_MapDepartmentsToPosition(_applicationID, _positionType, _mappings, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region MapPositionsToDepartment

public System.Data.SqlClient.SqlCommand GetCommand_MapPositionsToDepartment(Guid? _applicationID, byte? _departmentType, string _mappings, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spMapPositionsToDepartment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ADepartmentType", IsOutput = false, Value = _departmentType == null ? DBNull.Value : (object)_departmentType }, 
					new Parameter { Name = "@AMappings", IsOutput = false, Value = string.IsNullOrWhiteSpace(_mappings) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_mappings) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> MapPositionsToDepartmentAsync(Guid? _applicationID, byte? _departmentType, string _mappings, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_MapPositionsToDepartment(_applicationID, _departmentType, _mappings, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> MapPositionsToDepartmentDapperAsync<T>(Guid? _applicationID, byte? _departmentType, string _mappings, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spMapPositionsToDepartment",new {AApplicationID=_applicationID,ADepartmentType=_departmentType,AMappings=string.IsNullOrWhiteSpace(_mappings) ? _mappings : ReplaceArabicWithPersianChars(_mappings),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet MapPositionsToDepartment(Guid? _applicationID, byte? _departmentType, string _mappings, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_MapPositionsToDepartment(_applicationID, _departmentType, _mappings, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplication

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplication(bool? _isNewRecord, Guid? _id, string _code, string _name, bool? _enabled, string _comment, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyApplication", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_code) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_code) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEnabled", IsOutput = false, Value = _enabled == null ? DBNull.Value : (object)_enabled }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationAsync(bool? _isNewRecord, Guid? _id, string _code, string _name, bool? _enabled, string _comment, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplication(_isNewRecord, _id, _code, _name, _enabled, _comment, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationDapperAsync<T>(bool? _isNewRecord, Guid? _id, string _code, string _name, bool? _enabled, string _comment, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyApplication",new {AIsNewRecord=_isNewRecord,AID=_id,ACode=string.IsNullOrWhiteSpace(_code) ? _code : ReplaceArabicWithPersianChars(_code),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEnabled=_enabled,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplication(bool? _isNewRecord, Guid? _id, string _code, string _name, bool? _enabled, string _comment, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplication(_isNewRecord, _id, _code, _name, _enabled, _comment, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyClient

public System.Data.SqlClient.SqlCommand GetCommand_ModifyClient(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _secret, byte? _type, bool? _enabled, int? _refreshTokenLifeTime, string _allowedOrigin, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyClient", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@ASecret", IsOutput = false, Value = string.IsNullOrWhiteSpace(_secret) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_secret) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AEnabled", IsOutput = false, Value = _enabled == null ? DBNull.Value : (object)_enabled }, 
					new Parameter { Name = "@ARefreshTokenLifeTime", IsOutput = false, Value = _refreshTokenLifeTime == null ? DBNull.Value : (object)_refreshTokenLifeTime }, 
					new Parameter { Name = "@AAllowedOrigin", IsOutput = false, Value = string.IsNullOrWhiteSpace(_allowedOrigin) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_allowedOrigin) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyClientAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _secret, byte? _type, bool? _enabled, int? _refreshTokenLifeTime, string _allowedOrigin, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyClient(_isNewRecord, _id, _applicationID, _name, _secret, _type, _enabled, _refreshTokenLifeTime, _allowedOrigin, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyClientDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _secret, byte? _type, bool? _enabled, int? _refreshTokenLifeTime, string _allowedOrigin, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyClient",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),ASecret=string.IsNullOrWhiteSpace(_secret) ? _secret : ReplaceArabicWithPersianChars(_secret),AType=_type,AEnabled=_enabled,ARefreshTokenLifeTime=_refreshTokenLifeTime,AAllowedOrigin=string.IsNullOrWhiteSpace(_allowedOrigin) ? _allowedOrigin : ReplaceArabicWithPersianChars(_allowedOrigin),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyClient(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _secret, byte? _type, bool? _enabled, int? _refreshTokenLifeTime, string _allowedOrigin, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyClient(_isNewRecord, _id, _applicationID, _name, _secret, _type, _enabled, _refreshTokenLifeTime, _allowedOrigin, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyCommand

public System.Data.SqlClient.SqlCommand GetCommand_ModifyCommand(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, Guid? _applicationID, string _name, string _fullName, string _title, byte? _type, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyCommand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@ANode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_node) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_node) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AFullName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_fullName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_fullName) }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyCommandAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, Guid? _applicationID, string _name, string _fullName, string _title, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyCommand(_isNewRecord, _id, _parentID, _node, _applicationID, _name, _fullName, _title, _type, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyCommandDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, Guid? _applicationID, string _name, string _fullName, string _title, byte? _type, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyCommand",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,ANode=string.IsNullOrWhiteSpace(_node) ? _node : ReplaceArabicWithPersianChars(_node),AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AFullName=string.IsNullOrWhiteSpace(_fullName) ? _fullName : ReplaceArabicWithPersianChars(_fullName),ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AType=_type,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyCommand(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, Guid? _applicationID, string _name, string _fullName, string _title, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyCommand(_isNewRecord, _id, _parentID, _node, _applicationID, _name, _fullName, _title, _type, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyDepartment

public System.Data.SqlClient.SqlCommand GetCommand_ModifyDepartment(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _code, string _name, bool? _enabled, Guid? _provinceID, string _address, string _postalCode, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyDepartment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@ANode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_node) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_node) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ACode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_code) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_code) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEnabled", IsOutput = false, Value = _enabled == null ? DBNull.Value : (object)_enabled }, 
					new Parameter { Name = "@AProvinceID", IsOutput = false, Value = _provinceID == null ? DBNull.Value : (object)_provinceID }, 
					new Parameter { Name = "@AAddress", IsOutput = false, Value = string.IsNullOrWhiteSpace(_address) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_address) }, 
					new Parameter { Name = "@APostalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_postalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_postalCode) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyDepartmentAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _code, string _name, bool? _enabled, Guid? _provinceID, string _address, string _postalCode, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyDepartment(_isNewRecord, _id, _parentID, _node, _type, _code, _name, _enabled, _provinceID, _address, _postalCode, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyDepartmentDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _code, string _name, bool? _enabled, Guid? _provinceID, string _address, string _postalCode, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyDepartment",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,ANode=string.IsNullOrWhiteSpace(_node) ? _node : ReplaceArabicWithPersianChars(_node),AType=_type,ACode=string.IsNullOrWhiteSpace(_code) ? _code : ReplaceArabicWithPersianChars(_code),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEnabled=_enabled,AProvinceID=_provinceID,AAddress=string.IsNullOrWhiteSpace(_address) ? _address : ReplaceArabicWithPersianChars(_address),APostalCode=string.IsNullOrWhiteSpace(_postalCode) ? _postalCode : ReplaceArabicWithPersianChars(_postalCode),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyDepartment(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _code, string _name, bool? _enabled, Guid? _provinceID, string _address, string _postalCode, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyDepartment(_isNewRecord, _id, _parentID, _node, _type, _code, _name, _enabled, _provinceID, _address, _postalCode, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyDynamicPermission

public System.Data.SqlClient.SqlCommand GetCommand_ModifyDynamicPermission(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _objectID, int? _order, string _details, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyDynamicPermission", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AObjectID", IsOutput = false, Value = _objectID == null ? DBNull.Value : (object)_objectID }, 
					new Parameter { Name = "@AOrder", IsOutput = false, Value = _order == null ? DBNull.Value : (object)_order }, 
					new Parameter { Name = "@ADetails", IsOutput = false, Value = string.IsNullOrWhiteSpace(_details) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_details) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyDynamicPermissionAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _objectID, int? _order, string _details, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyDynamicPermission(_isNewRecord, _id, _applicationID, _objectID, _order, _details, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyDynamicPermissionDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _objectID, int? _order, string _details, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyDynamicPermission",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,AObjectID=_objectID,AOrder=_order,ADetails=string.IsNullOrWhiteSpace(_details) ? _details : ReplaceArabicWithPersianChars(_details)} , timeout );
}

public ResultSet ModifyDynamicPermission(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _objectID, int? _order, string _details, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyDynamicPermission(_isNewRecord, _id, _applicationID, _objectID, _order, _details, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyPlace

public System.Data.SqlClient.SqlCommand GetCommand_ModifyPlace(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _name, string _code, string _latinName, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyPlace", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@ANode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_node) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_node) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@ACode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_code) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_code) }, 
					new Parameter { Name = "@ALatinName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_latinName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_latinName) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyPlaceAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _name, string _code, string _latinName, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPlace(_isNewRecord, _id, _parentID, _node, _type, _name, _code, _latinName, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyPlaceDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _name, string _code, string _latinName, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyPlace",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,ANode=string.IsNullOrWhiteSpace(_node) ? _node : ReplaceArabicWithPersianChars(_node),AType=_type,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),ACode=string.IsNullOrWhiteSpace(_code) ? _code : ReplaceArabicWithPersianChars(_code),ALatinName=string.IsNullOrWhiteSpace(_latinName) ? _latinName : ReplaceArabicWithPersianChars(_latinName),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyPlace(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _node, byte? _type, string _name, string _code, string _latinName, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPlace(_isNewRecord, _id, _parentID, _node, _type, _name, _code, _latinName, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyPosition

public System.Data.SqlClient.SqlCommand GetCommand_ModifyPosition(bool? _isNewRecord, Guid? _id, Guid? _parentID, Guid? _applicationID, Guid? _departmentID, Guid? _userID, byte? _type, string _roleIDs, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ADepartmentID", IsOutput = false, Value = _departmentID == null ? DBNull.Value : (object)_departmentID }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ARoleIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_roleIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_roleIDs) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyPositionAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, Guid? _applicationID, Guid? _departmentID, Guid? _userID, byte? _type, string _roleIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPosition(_isNewRecord, _id, _parentID, _applicationID, _departmentID, _userID, _type, _roleIDs, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyPositionDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, Guid? _applicationID, Guid? _departmentID, Guid? _userID, byte? _type, string _roleIDs, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyPosition",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,AApplicationID=_applicationID,ADepartmentID=_departmentID,AUserID=_userID,AType=_type,ARoleIDs=string.IsNullOrWhiteSpace(_roleIDs) ? _roleIDs : ReplaceArabicWithPersianChars(_roleIDs),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyPosition(bool? _isNewRecord, Guid? _id, Guid? _parentID, Guid? _applicationID, Guid? _departmentID, Guid? _userID, byte? _type, string _roleIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPosition(_isNewRecord, _id, _parentID, _applicationID, _departmentID, _userID, _type, _roleIDs, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyPositionHistory

public System.Data.SqlClient.SqlCommand GetCommand_ModifyPositionHistory(bool? _isNewRecord, Guid? _id, Guid? _positionID, Guid? _userID, string _letterNumber, DateTime? _date, string _comment, Guid? _creatorUserID, Guid? _creatorPositionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyPositionHistory", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ALetterNumber", IsOutput = false, Value = string.IsNullOrWhiteSpace(_letterNumber) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_letterNumber) }, 
					new Parameter { Name = "@ADate", IsOutput = false, Value = _date == null ? DBNull.Value : (object)_date }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@ACreatorUserID", IsOutput = false, Value = _creatorUserID == null ? DBNull.Value : (object)_creatorUserID }, 
					new Parameter { Name = "@ACreatorPositionID", IsOutput = false, Value = _creatorPositionID == null ? DBNull.Value : (object)_creatorPositionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyPositionHistoryAsync(bool? _isNewRecord, Guid? _id, Guid? _positionID, Guid? _userID, string _letterNumber, DateTime? _date, string _comment, Guid? _creatorUserID, Guid? _creatorPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPositionHistory(_isNewRecord, _id, _positionID, _userID, _letterNumber, _date, _comment, _creatorUserID, _creatorPositionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyPositionHistoryDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _positionID, Guid? _userID, string _letterNumber, DateTime? _date, string _comment, Guid? _creatorUserID, Guid? _creatorPositionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyPositionHistory",new {AIsNewRecord=_isNewRecord,AID=_id,APositionID=_positionID,AUserID=_userID,ALetterNumber=string.IsNullOrWhiteSpace(_letterNumber) ? _letterNumber : ReplaceArabicWithPersianChars(_letterNumber),ADate=_date,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),ACreatorUserID=_creatorUserID,ACreatorPositionID=_creatorPositionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyPositionHistory(bool? _isNewRecord, Guid? _id, Guid? _positionID, Guid? _userID, string _letterNumber, DateTime? _date, string _comment, Guid? _creatorUserID, Guid? _creatorPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPositionHistory(_isNewRecord, _id, _positionID, _userID, _letterNumber, _date, _comment, _creatorUserID, _creatorPositionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyPositionType

public System.Data.SqlClient.SqlCommand GetCommand_ModifyPositionType(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _positionType, byte? _userType, Guid? _applicationID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyPositionType", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@AUserType", IsOutput = false, Value = _userType == null ? DBNull.Value : (object)_userType }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyPositionTypeAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _positionType, byte? _userType, Guid? _applicationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPositionType(_isNewRecord, _id, _parentID, _positionType, _userType, _applicationID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyPositionTypeDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _positionType, byte? _userType, Guid? _applicationID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyPositionType",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,APositionType=_positionType,AUserType=_userType,AApplicationID=_applicationID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyPositionType(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _positionType, byte? _userType, Guid? _applicationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyPositionType(_isNewRecord, _id, _parentID, _positionType, _userType, _applicationID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyRefreshToken

public System.Data.SqlClient.SqlCommand GetCommand_ModifyRefreshToken(bool? _isNewRecord, Guid? _id, Guid? _userID, DateTime? _issuedDate, DateTime? _expireDate, string _protectedTicket, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyRefreshToken", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AIssuedDate", IsOutput = false, Value = _issuedDate == null ? DBNull.Value : (object)_issuedDate }, 
					new Parameter { Name = "@AExpireDate", IsOutput = false, Value = _expireDate == null ? DBNull.Value : (object)_expireDate }, 
					new Parameter { Name = "@AProtectedTicket", IsOutput = false, Value = string.IsNullOrWhiteSpace(_protectedTicket) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_protectedTicket) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyRefreshTokenAsync(bool? _isNewRecord, Guid? _id, Guid? _userID, DateTime? _issuedDate, DateTime? _expireDate, string _protectedTicket, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyRefreshToken(_isNewRecord, _id, _userID, _issuedDate, _expireDate, _protectedTicket, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyRefreshTokenDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _userID, DateTime? _issuedDate, DateTime? _expireDate, string _protectedTicket, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyRefreshToken",new {AIsNewRecord=_isNewRecord,AID=_id,AUserID=_userID,AIssuedDate=_issuedDate,AExpireDate=_expireDate,AProtectedTicket=string.IsNullOrWhiteSpace(_protectedTicket) ? _protectedTicket : ReplaceArabicWithPersianChars(_protectedTicket)} , timeout );
}

public ResultSet ModifyRefreshToken(bool? _isNewRecord, Guid? _id, Guid? _userID, DateTime? _issuedDate, DateTime? _expireDate, string _protectedTicket, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyRefreshToken(_isNewRecord, _id, _userID, _issuedDate, _expireDate, _protectedTicket, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyRole

public System.Data.SqlClient.SqlCommand GetCommand_ModifyRole(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _permissions, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyRole", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@APermissions", IsOutput = false, Value = string.IsNullOrWhiteSpace(_permissions) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_permissions) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyRoleAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _permissions, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyRole(_isNewRecord, _id, _applicationID, _name, _permissions, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyRoleDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _permissions, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyRole",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),APermissions=string.IsNullOrWhiteSpace(_permissions) ? _permissions : ReplaceArabicWithPersianChars(_permissions),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyRole(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, string _permissions, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyRole(_isNewRecord, _id, _applicationID, _name, _permissions, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyUser

public System.Data.SqlClient.SqlCommand GetCommand_ModifyUser(bool? _isNewRecord, Guid? _id, bool? _enabled, string _username, string _password, DateTime? _passwordExpireDate, string _firstName, string _lastName, string _nationalCode, string _email, string _cellPhone, Guid? _applicationID, bool? _emailVerified, bool? _cellPhoneVerified, bool? _foreigner, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AEnabled", IsOutput = false, Value = _enabled == null ? DBNull.Value : (object)_enabled }, 
					new Parameter { Name = "@AUsername", IsOutput = false, Value = string.IsNullOrWhiteSpace(_username) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_username) }, 
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
					new Parameter { Name = "@APasswordExpireDate", IsOutput = false, Value = _passwordExpireDate == null ? DBNull.Value : (object)_passwordExpireDate }, 
					new Parameter { Name = "@AFirstName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_firstName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_firstName) }, 
					new Parameter { Name = "@ALastName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_lastName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_lastName) }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@ACellPhone", IsOutput = false, Value = string.IsNullOrWhiteSpace(_cellPhone) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_cellPhone) }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AEmailVerified", IsOutput = false, Value = _emailVerified == null ? DBNull.Value : (object)_emailVerified }, 
					new Parameter { Name = "@ACellPhoneVerified", IsOutput = false, Value = _cellPhoneVerified == null ? DBNull.Value : (object)_cellPhoneVerified }, 
					new Parameter { Name = "@AForeigner", IsOutput = false, Value = _foreigner == null ? DBNull.Value : (object)_foreigner }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyUserAsync(bool? _isNewRecord, Guid? _id, bool? _enabled, string _username, string _password, DateTime? _passwordExpireDate, string _firstName, string _lastName, string _nationalCode, string _email, string _cellPhone, Guid? _applicationID, bool? _emailVerified, bool? _cellPhoneVerified, bool? _foreigner, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyUser(_isNewRecord, _id, _enabled, _username, _password, _passwordExpireDate, _firstName, _lastName, _nationalCode, _email, _cellPhone, _applicationID, _emailVerified, _cellPhoneVerified, _foreigner, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyUserDapperAsync<T>(bool? _isNewRecord, Guid? _id, bool? _enabled, string _username, string _password, DateTime? _passwordExpireDate, string _firstName, string _lastName, string _nationalCode, string _email, string _cellPhone, Guid? _applicationID, bool? _emailVerified, bool? _cellPhoneVerified, bool? _foreigner, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyUser",new {AIsNewRecord=_isNewRecord,AID=_id,AEnabled=_enabled,AUsername=string.IsNullOrWhiteSpace(_username) ? _username : ReplaceArabicWithPersianChars(_username),APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password),APasswordExpireDate=_passwordExpireDate,AFirstName=string.IsNullOrWhiteSpace(_firstName) ? _firstName : ReplaceArabicWithPersianChars(_firstName),ALastName=string.IsNullOrWhiteSpace(_lastName) ? _lastName : ReplaceArabicWithPersianChars(_lastName),ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),ACellPhone=string.IsNullOrWhiteSpace(_cellPhone) ? _cellPhone : ReplaceArabicWithPersianChars(_cellPhone),AApplicationID=_applicationID,AEmailVerified=_emailVerified,ACellPhoneVerified=_cellPhoneVerified,AForeigner=_foreigner,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyUser(bool? _isNewRecord, Guid? _id, bool? _enabled, string _username, string _password, DateTime? _passwordExpireDate, string _firstName, string _lastName, string _nationalCode, string _email, string _cellPhone, Guid? _applicationID, bool? _emailVerified, bool? _cellPhoneVerified, bool? _foreigner, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyUser(_isNewRecord, _id, _enabled, _username, _password, _passwordExpireDate, _firstName, _lastName, _nationalCode, _email, _cellPhone, _applicationID, _emailVerified, _cellPhoneVerified, _foreigner, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteApplication

public System.Data.SqlClient.SqlCommand GetCommand_DeleteApplication(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteApplication", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteApplicationAsync(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplication(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteApplicationDapperAsync<T>(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteApplication",new {AID=_id,ACurrentUserID=_currentUserID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteApplication(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplication(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyUserSetting

public System.Data.SqlClient.SqlCommand GetCommand_ModifyUserSetting(Guid? _userID, string _setting, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyUserSetting", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ASetting", IsOutput = false, Value = string.IsNullOrWhiteSpace(_setting) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_setting) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyUserSettingAsync(Guid? _userID, string _setting, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyUserSetting(_userID, _setting, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyUserSettingDapperAsync<T>(Guid? _userID, string _setting, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyUserSetting",new {AUserID=_userID,ASetting=string.IsNullOrWhiteSpace(_setting) ? _setting : ReplaceArabicWithPersianChars(_setting)} , timeout );
}

public ResultSet ModifyUserSetting(Guid? _userID, string _setting, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyUserSetting(_userID, _setting, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyWebServiceUser

public System.Data.SqlClient.SqlCommand GetCommand_ModifyWebServiceUser(bool? _isNewRecord, Guid? _id, string _userName, string _password, Guid? _organID, bool? _enabled, DateTime? _passwordExpireDate, Guid? _creatorID, string _comment, int? timeout = null)
{
var cmd = base.CreateCommand("org.spModifyWebServiceUser", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AUserName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_userName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_userName) }, 
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
					new Parameter { Name = "@AOrganID", IsOutput = false, Value = _organID == null ? DBNull.Value : (object)_organID }, 
					new Parameter { Name = "@AEnabled", IsOutput = false, Value = _enabled == null ? DBNull.Value : (object)_enabled }, 
					new Parameter { Name = "@APasswordExpireDate", IsOutput = false, Value = _passwordExpireDate == null ? DBNull.Value : (object)_passwordExpireDate }, 
					new Parameter { Name = "@ACreatorID", IsOutput = false, Value = _creatorID == null ? DBNull.Value : (object)_creatorID }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyWebServiceUserAsync(bool? _isNewRecord, Guid? _id, string _userName, string _password, Guid? _organID, bool? _enabled, DateTime? _passwordExpireDate, Guid? _creatorID, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyWebServiceUser(_isNewRecord, _id, _userName, _password, _organID, _enabled, _passwordExpireDate, _creatorID, _comment, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyWebServiceUserDapperAsync<T>(bool? _isNewRecord, Guid? _id, string _userName, string _password, Guid? _organID, bool? _enabled, DateTime? _passwordExpireDate, Guid? _creatorID, string _comment, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spModifyWebServiceUser",new {AIsNewRecord=_isNewRecord,AID=_id,AUserName=string.IsNullOrWhiteSpace(_userName) ? _userName : ReplaceArabicWithPersianChars(_userName),APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password),AOrganID=_organID,AEnabled=_enabled,APasswordExpireDate=_passwordExpireDate,ACreatorID=_creatorID,AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment)} , timeout );
}

public ResultSet ModifyWebServiceUser(bool? _isNewRecord, Guid? _id, string _userName, string _password, Guid? _organID, bool? _enabled, DateTime? _passwordExpireDate, Guid? _creatorID, string _comment, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyWebServiceUser(_isNewRecord, _id, _userName, _password, _organID, _enabled, _passwordExpireDate, _creatorID, _comment, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region RemoveUserFromPosition

public System.Data.SqlClient.SqlCommand GetCommand_RemoveUserFromPosition(Guid? _positionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spRemoveUserFromPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> RemoveUserFromPositionAsync(Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_RemoveUserFromPosition(_positionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> RemoveUserFromPositionDapperAsync<T>(Guid? _positionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spRemoveUserFromPosition",new {APositionID=_positionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet RemoveUserFromPosition(Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_RemoveUserFromPosition(_positionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteClient

public System.Data.SqlClient.SqlCommand GetCommand_DeleteClient(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteClient", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteClientAsync(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClient(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteClientDapperAsync<T>(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteClient",new {AID=_id,ACurrentUserID=_currentUserID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteClient(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteClient(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteCommand

public System.Data.SqlClient.SqlCommand GetCommand_DeleteCommand(Guid? _id, Guid? _applicationID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteCommand", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteCommandAsync(Guid? _id, Guid? _applicationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteCommand(_id, _applicationID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteCommandDapperAsync<T>(Guid? _id, Guid? _applicationID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteCommand",new {AID=_id,AApplicationID=_applicationID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteCommand(Guid? _id, Guid? _applicationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteCommand(_id, _applicationID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetDefaultPosition

public System.Data.SqlClient.SqlCommand GetCommand_SetDefaultPosition(Guid? _positionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spSetDefaultPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetDefaultPositionAsync(Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetDefaultPosition(_positionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetDefaultPositionDapperAsync<T>(Guid? _positionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spSetDefaultPosition",new {APositionID=_positionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetDefaultPosition(Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetDefaultPosition(_positionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteDepartment

public System.Data.SqlClient.SqlCommand GetCommand_DeleteDepartment(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteDepartment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteDepartmentAsync(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDepartment(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteDepartmentDapperAsync<T>(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteDepartment",new {AID=_id,ACurrentUserID=_currentUserID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteDepartment(Guid? _id, Guid? _currentUserID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDepartment(_id, _currentUserID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteDynamicPermission

public System.Data.SqlClient.SqlCommand GetCommand_DeleteDynamicPermission(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("org.spDeleteDynamicPermission", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteDynamicPermissionAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDynamicPermission(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteDynamicPermissionDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("org.spDeleteDynamicPermission",new {AID=_id} , timeout );
}

public ResultSet DeleteDynamicPermission(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteDynamicPermission(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

}

class APP: Database
{
#region Constructors
public APP(string connectionString)
	:base(connectionString){}

public APP(string connectionString, IModelValueBinder modelValueBinder)
	:base(connectionString, modelValueBinder){}
#endregion

#region DeleteFAQGroup

public System.Data.SqlClient.SqlCommand GetCommand_DeleteFAQGroup(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteFAQGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteFAQGroupAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteFAQGroup(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteFAQGroupDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteFAQGroup",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteFAQGroup(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteFAQGroup(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteMessage

public System.Data.SqlClient.SqlCommand GetCommand_DeleteMessage(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteMessage", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AMessageID", IsOutput = false, Value = _messageID == null ? DBNull.Value : (object)_messageID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteMessageAsync(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteMessage(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteMessageDapperAsync<T>(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteMessage",new {ACurrentUserID=_currentUserID,AMessageID=_messageID} , timeout );
}

public ResultSet DeleteMessage(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteMessage(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteNotification

public System.Data.SqlClient.SqlCommand GetCommand_DeleteNotification(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteNotification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteNotificationAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteNotification(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteNotificationDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteNotification",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteNotification(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteNotification(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteNotificationCondition

public System.Data.SqlClient.SqlCommand GetCommand_DeleteNotificationCondition(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteNotificationCondition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteNotificationConditionAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteNotificationCondition(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteNotificationConditionDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteNotificationCondition",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteNotificationCondition(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteNotificationCondition(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAnnouncement

public System.Data.SqlClient.SqlCommand GetCommand_GetAnnouncement(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetAnnouncement", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAnnouncementAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncement(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAnnouncementDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetAnnouncement",new {AID=_id} , timeout );
}

public ResultSet GetAnnouncement(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncement(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAnnouncementPositionTypes

public System.Data.SqlClient.SqlCommand GetCommand_GetAnnouncementPositionTypes(Guid? _announcementID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetAnnouncementPositionTypes", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AAnnouncementID", IsOutput = false, Value = _announcementID == null ? DBNull.Value : (object)_announcementID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAnnouncementPositionTypesAsync(Guid? _announcementID, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncementPositionTypes(_announcementID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAnnouncementPositionTypesDapperAsync<T>(Guid? _announcementID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetAnnouncementPositionTypes",new {AAnnouncementID=_announcementID} , timeout );
}

public ResultSet GetAnnouncementPositionTypes(Guid? _announcementID, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncementPositionTypes(_announcementID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAnnouncements

public System.Data.SqlClient.SqlCommand GetCommand_GetAnnouncements(Guid? _userID, Guid? _applicationID, Guid? _currentUserProvinceID, string _title, byte? _enable, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetAnnouncements", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ACurrentUserProvinceID", IsOutput = false, Value = _currentUserProvinceID == null ? DBNull.Value : (object)_currentUserProvinceID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AEnable", IsOutput = false, Value = _enable == null ? DBNull.Value : (object)_enable }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAnnouncementsAsync(Guid? _userID, Guid? _applicationID, Guid? _currentUserProvinceID, string _title, byte? _enable, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncements(_userID, _applicationID, _currentUserProvinceID, _title, _enable, _type, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAnnouncementsDapperAsync<T>(Guid? _userID, Guid? _applicationID, Guid? _currentUserProvinceID, string _title, byte? _enable, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetAnnouncements",new {AUserID=_userID,AApplicationID=_applicationID,ACurrentUserProvinceID=_currentUserProvinceID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AEnable=_enable,AType=_type,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetAnnouncements(Guid? _userID, Guid? _applicationID, Guid? _currentUserProvinceID, string _title, byte? _enable, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncements(_userID, _applicationID, _currentUserProvinceID, _title, _enable, _type, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAnnouncementsForBulletin

public System.Data.SqlClient.SqlCommand GetCommand_GetAnnouncementsForBulletin(Guid? _positionID, Guid? _applicationID, Guid? _currentUserProvinceID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetAnnouncementsForBulletin", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ACurrentUserProvinceID", IsOutput = false, Value = _currentUserProvinceID == null ? DBNull.Value : (object)_currentUserProvinceID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAnnouncementsForBulletinAsync(Guid? _positionID, Guid? _applicationID, Guid? _currentUserProvinceID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncementsForBulletin(_positionID, _applicationID, _currentUserProvinceID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAnnouncementsForBulletinDapperAsync<T>(Guid? _positionID, Guid? _applicationID, Guid? _currentUserProvinceID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetAnnouncementsForBulletin",new {APositionID=_positionID,AApplicationID=_applicationID,ACurrentUserProvinceID=_currentUserProvinceID,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetAnnouncementsForBulletin(Guid? _positionID, Guid? _applicationID, Guid? _currentUserProvinceID, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetAnnouncementsForBulletin(_positionID, _applicationID, _currentUserProvinceID, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurvey

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurvey(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurvey", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurvey(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurvey",new {AID=_id} , timeout );
}

public ResultSet GetApplicationSurvey(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurvey(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyAnswer

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyAnswer(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyAnswer", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyAnswerAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyAnswer(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyAnswerDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyAnswer",new {AID=_id} , timeout );
}

public ResultSet GetApplicationSurveyAnswer(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyAnswer(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyAnswers

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyAnswers(Guid? _userID, DateTime? _date, int? _pageSize, int? _pageIndex, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyAnswers", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ADate", IsOutput = false, Value = _date == null ? DBNull.Value : (object)_date }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyAnswersAsync(Guid? _userID, DateTime? _date, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyAnswers(_userID, _date, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyAnswersDapperAsync<T>(Guid? _userID, DateTime? _date, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyAnswers",new {AUserID=_userID,ADate=_date,APageSize=_pageSize,APageIndex=_pageIndex} , timeout );
}

public ResultSet GetApplicationSurveyAnswers(Guid? _userID, DateTime? _date, int? _pageSize, int? _pageIndex, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyAnswers(_userID, _date, _pageSize, _pageIndex, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyGroup

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyGroup(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyGroupAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroup(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyGroupDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyGroup",new {AID=_id} , timeout );
}

public ResultSet GetApplicationSurveyGroup(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroup(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyGroups

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyGroups(Guid? _applicationSurveyID, Guid? _applicationID, string _name, bool? _showRemov, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyGroups", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationSurveyID", IsOutput = false, Value = _applicationSurveyID == null ? DBNull.Value : (object)_applicationSurveyID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AShowRemov", IsOutput = false, Value = _showRemov == null ? DBNull.Value : (object)_showRemov }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyGroupsAsync(Guid? _applicationSurveyID, Guid? _applicationID, string _name, bool? _showRemov, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroups(_applicationSurveyID, _applicationID, _name, _showRemov, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyGroupsDapperAsync<T>(Guid? _applicationSurveyID, Guid? _applicationID, string _name, bool? _showRemov, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyGroups",new {AApplicationSurveyID=_applicationSurveyID,AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AShowRemov=_showRemov,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetApplicationSurveyGroups(Guid? _applicationSurveyID, Guid? _applicationID, string _name, bool? _showRemov, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroups(_applicationSurveyID, _applicationID, _name, _showRemov, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyQuestion

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyQuestion(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyQuestion", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyQuestionAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestion(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyQuestionDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyQuestion",new {AID=_id} , timeout );
}

public ResultSet GetApplicationSurveyQuestion(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestion(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyQuestionChoice

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyQuestionChoice(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyQuestionChoice", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyQuestionChoiceAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestionChoice(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyQuestionChoiceDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyQuestionChoice",new {AID=_id} , timeout );
}

public ResultSet GetApplicationSurveyQuestionChoice(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestionChoice(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyQuestionChoices

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyQuestionChoices(Guid? _questionID, string _questionIDs, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyQuestionChoices", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AQuestionID", IsOutput = false, Value = _questionID == null ? DBNull.Value : (object)_questionID }, 
					new Parameter { Name = "@AQuestionIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_questionIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_questionIDs) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyQuestionChoicesAsync(Guid? _questionID, string _questionIDs, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestionChoices(_questionID, _questionIDs, _name, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyQuestionChoicesDapperAsync<T>(Guid? _questionID, string _questionIDs, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyQuestionChoices",new {AQuestionID=_questionID,AQuestionIDs=string.IsNullOrWhiteSpace(_questionIDs) ? _questionIDs : ReplaceArabicWithPersianChars(_questionIDs),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetApplicationSurveyQuestionChoices(Guid? _questionID, string _questionIDs, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestionChoices(_questionID, _questionIDs, _name, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyQuestions

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyQuestions(Guid? _groupID, string _groupIDs, string _name, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyQuestions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AGroupID", IsOutput = false, Value = _groupID == null ? DBNull.Value : (object)_groupID }, 
					new Parameter { Name = "@AGroupIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_groupIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_groupIDs) }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyQuestionsAsync(Guid? _groupID, string _groupIDs, string _name, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestions(_groupID, _groupIDs, _name, _type, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyQuestionsDapperAsync<T>(Guid? _groupID, string _groupIDs, string _name, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyQuestions",new {AGroupID=_groupID,AGroupIDs=string.IsNullOrWhiteSpace(_groupIDs) ? _groupIDs : ReplaceArabicWithPersianChars(_groupIDs),AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AType=_type,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetApplicationSurveyQuestions(Guid? _groupID, string _groupIDs, string _name, byte? _type, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyQuestions(_groupID, _groupIDs, _name, _type, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveys

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveys(Guid? _applicationID, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveys", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveysAsync(Guid? _applicationID, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveys(_applicationID, _name, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveysDapperAsync<T>(Guid? _applicationID, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveys",new {AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetApplicationSurveys(Guid? _applicationID, string _name, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveys(_applicationID, _name, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContact

public System.Data.SqlClient.SqlCommand GetCommand_GetContact(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContact", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContact(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContact",new {AID=_id} , timeout );
}

public ResultSet GetContact(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContact(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContactDetail

public System.Data.SqlClient.SqlCommand GetCommand_GetContactDetail(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContactDetail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactDetailAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactDetail(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactDetailDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContactDetail",new {AID=_id} , timeout );
}

public ResultSet GetContactDetail(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactDetail(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContactDetails

public System.Data.SqlClient.SqlCommand GetCommand_GetContactDetails(string _contactInfoIDs, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContactDetails", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AContactInfoIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_contactInfoIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_contactInfoIDs) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactDetailsAsync(string _contactInfoIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactDetails(_contactInfoIDs, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactDetailsDapperAsync<T>(string _contactInfoIDs, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContactDetails",new {AContactInfoIDs=string.IsNullOrWhiteSpace(_contactInfoIDs) ? _contactInfoIDs : ReplaceArabicWithPersianChars(_contactInfoIDs)} , timeout );
}

public ResultSet GetContactDetails(string _contactInfoIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactDetails(_contactInfoIDs, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContactInfo

public System.Data.SqlClient.SqlCommand GetCommand_GetContactInfo(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContactInfo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactInfoAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactInfo(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactInfoDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContactInfo",new {AID=_id} , timeout );
}

public ResultSet GetContactInfo(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactInfo(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContactInfos

public System.Data.SqlClient.SqlCommand GetCommand_GetContactInfos(Guid? _parentID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContactInfos", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactInfosAsync(Guid? _parentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactInfos(_parentID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactInfosDapperAsync<T>(Guid? _parentID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContactInfos",new {AParentID=_parentID} , timeout );
}

public ResultSet GetContactInfos(Guid? _parentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetContactInfos(_parentID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetContacts

public System.Data.SqlClient.SqlCommand GetCommand_GetContacts(Guid? _applicationID, string _title, string _content, DateTime? _creationDateFrom, DateTime? _creationDateTo, byte? _archivedType, string _note, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetContacts", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@ACreationDateFrom", IsOutput = false, Value = _creationDateFrom == null ? DBNull.Value : (object)_creationDateFrom }, 
					new Parameter { Name = "@ACreationDateTo", IsOutput = false, Value = _creationDateTo == null ? DBNull.Value : (object)_creationDateTo }, 
					new Parameter { Name = "@AArchivedType", IsOutput = false, Value = _archivedType == null ? DBNull.Value : (object)_archivedType }, 
					new Parameter { Name = "@ANote", IsOutput = false, Value = string.IsNullOrWhiteSpace(_note) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_note) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetContactsAsync(Guid? _applicationID, string _title, string _content, DateTime? _creationDateFrom, DateTime? _creationDateTo, byte? _archivedType, string _note, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetContacts(_applicationID, _title, _content, _creationDateFrom, _creationDateTo, _archivedType, _note, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetContactsDapperAsync<T>(Guid? _applicationID, string _title, string _content, DateTime? _creationDateFrom, DateTime? _creationDateTo, byte? _archivedType, string _note, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetContacts",new {AApplicationID=_applicationID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),ACreationDateFrom=_creationDateFrom,ACreationDateTo=_creationDateTo,AArchivedType=_archivedType,ANote=string.IsNullOrWhiteSpace(_note) ? _note : ReplaceArabicWithPersianChars(_note),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetContacts(Guid? _applicationID, string _title, string _content, DateTime? _creationDateFrom, DateTime? _creationDateTo, byte? _archivedType, string _note, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetContacts(_applicationID, _title, _content, _creationDateFrom, _creationDateTo, _archivedType, _note, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetDraftMessages

public System.Data.SqlClient.SqlCommand GetCommand_GetDraftMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetDraftMessages", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetDraftMessagesAsync(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetDraftMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetDraftMessagesDapperAsync<T>(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetDraftMessages",new {ACurrentUserID=_currentUserID,AApplicationID=_applicationID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetDraftMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetDraftMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetFAQ

public System.Data.SqlClient.SqlCommand GetCommand_GetFAQ(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetFAQ", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetFAQAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQ(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetFAQDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetFAQ",new {AID=_id} , timeout );
}

public ResultSet GetFAQ(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQ(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetFAQGroup

public System.Data.SqlClient.SqlCommand GetCommand_GetFAQGroup(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetFAQGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetFAQGroupAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQGroup(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetFAQGroupDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetFAQGroup",new {AID=_id} , timeout );
}

public ResultSet GetFAQGroup(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQGroup(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetFAQGroups

public System.Data.SqlClient.SqlCommand GetCommand_GetFAQGroups(Guid? _applicationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetFAQGroups", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetFAQGroupsAsync(Guid? _applicationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQGroups(_applicationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetFAQGroupsDapperAsync<T>(Guid? _applicationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetFAQGroups",new {AApplicationID=_applicationID,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetFAQGroups(Guid? _applicationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQGroups(_applicationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetFAQs

public System.Data.SqlClient.SqlCommand GetCommand_GetFAQs(Guid? _applicationID, Guid? _fAQGroupID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetFAQs", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AFAQGroupID", IsOutput = false, Value = _fAQGroupID == null ? DBNull.Value : (object)_fAQGroupID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetFAQsAsync(Guid? _applicationID, Guid? _fAQGroupID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQs(_applicationID, _fAQGroupID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetFAQsDapperAsync<T>(Guid? _applicationID, Guid? _fAQGroupID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetFAQs",new {AApplicationID=_applicationID,AFAQGroupID=_fAQGroupID,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetFAQs(Guid? _applicationID, Guid? _fAQGroupID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetFAQs(_applicationID, _fAQGroupID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetInboxMessages

public System.Data.SqlClient.SqlCommand GetCommand_GetInboxMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetInboxMessages", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetInboxMessagesAsync(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetInboxMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetInboxMessagesDapperAsync<T>(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetInboxMessages",new {ACurrentUserID=_currentUserID,AApplicationID=_applicationID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetInboxMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetInboxMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetMessage

public System.Data.SqlClient.SqlCommand GetCommand_GetMessage(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetMessage", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetMessageAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetMessage(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetMessageDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetMessage",new {AID=_id} , timeout );
}

public ResultSet GetMessage(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetMessage(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetMessageReceivers

public System.Data.SqlClient.SqlCommand GetCommand_GetMessageReceivers(Guid? _messageID, string _messageIDs, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetMessageReceivers", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AMessageID", IsOutput = false, Value = _messageID == null ? DBNull.Value : (object)_messageID }, 
					new Parameter { Name = "@AMessageIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_messageIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_messageIDs) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetMessageReceiversAsync(Guid? _messageID, string _messageIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetMessageReceivers(_messageID, _messageIDs, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetMessageReceiversDapperAsync<T>(Guid? _messageID, string _messageIDs, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetMessageReceivers",new {AMessageID=_messageID,AMessageIDs=string.IsNullOrWhiteSpace(_messageIDs) ? _messageIDs : ReplaceArabicWithPersianChars(_messageIDs)} , timeout );
}

public ResultSet GetMessageReceivers(Guid? _messageID, string _messageIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetMessageReceivers(_messageID, _messageIDs, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotification

public System.Data.SqlClient.SqlCommand GetCommand_GetNotification(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotification(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotification",new {AID=_id} , timeout );
}

public ResultSet GetNotification(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotification(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotificationCondition

public System.Data.SqlClient.SqlCommand GetCommand_GetNotificationCondition(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotificationCondition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationConditionAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationCondition(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationConditionDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotificationCondition",new {AID=_id} , timeout );
}

public ResultSet GetNotificationCondition(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationCondition(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotificationConditions

public System.Data.SqlClient.SqlCommand GetCommand_GetNotificationConditions(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotificationConditions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ANotificationID", IsOutput = false, Value = _notificationID == null ? DBNull.Value : (object)_notificationID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationConditionsAsync(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationConditions(_notificationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationConditionsDapperAsync<T>(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotificationConditions",new {ANotificationID=_notificationID,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetNotificationConditions(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationConditions(_notificationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotificationPositions

public System.Data.SqlClient.SqlCommand GetCommand_GetNotificationPositions(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotificationPositions", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ANotificationID", IsOutput = false, Value = _notificationID == null ? DBNull.Value : (object)_notificationID }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationPositionsAsync(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationPositions(_notificationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationPositionsDapperAsync<T>(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotificationPositions",new {ANotificationID=_notificationID,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetNotificationPositions(Guid? _notificationID, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationPositions(_notificationID, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotifications

public System.Data.SqlClient.SqlCommand GetCommand_GetNotifications(Guid? _applicationID, byte? _senderType, string _title, string _content, byte? _priority, byte? _state, DateTime? _creationDateFrom, DateTime? _creationDateTo, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotifications", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ASenderType", IsOutput = false, Value = _senderType == null ? DBNull.Value : (object)_senderType }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@APriority", IsOutput = false, Value = _priority == null ? DBNull.Value : (object)_priority }, 
					new Parameter { Name = "@AState", IsOutput = false, Value = _state == null ? DBNull.Value : (object)_state }, 
					new Parameter { Name = "@ACreationDateFrom", IsOutput = false, Value = _creationDateFrom == null ? DBNull.Value : (object)_creationDateFrom }, 
					new Parameter { Name = "@ACreationDateTo", IsOutput = false, Value = _creationDateTo == null ? DBNull.Value : (object)_creationDateTo }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationsAsync(Guid? _applicationID, byte? _senderType, string _title, string _content, byte? _priority, byte? _state, DateTime? _creationDateFrom, DateTime? _creationDateTo, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotifications(_applicationID, _senderType, _title, _content, _priority, _state, _creationDateFrom, _creationDateTo, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationsDapperAsync<T>(Guid? _applicationID, byte? _senderType, string _title, string _content, byte? _priority, byte? _state, DateTime? _creationDateFrom, DateTime? _creationDateTo, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotifications",new {AApplicationID=_applicationID,ASenderType=_senderType,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),APriority=_priority,AState=_state,ACreationDateFrom=_creationDateFrom,ACreationDateTo=_creationDateTo,APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetNotifications(Guid? _applicationID, byte? _senderType, string _title, string _content, byte? _priority, byte? _state, DateTime? _creationDateFrom, DateTime? _creationDateTo, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotifications(_applicationID, _senderType, _title, _content, _priority, _state, _creationDateFrom, _creationDateTo, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetNotificationsByPosition

public System.Data.SqlClient.SqlCommand GetCommand_GetNotificationsByPosition(Guid? _applicationID, Guid? _currentUserPositionID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetNotificationsByPosition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ACurrentUserPositionID", IsOutput = false, Value = _currentUserPositionID == null ? DBNull.Value : (object)_currentUserPositionID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetNotificationsByPositionAsync(Guid? _applicationID, Guid? _currentUserPositionID, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationsByPosition(_applicationID, _currentUserPositionID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetNotificationsByPositionDapperAsync<T>(Guid? _applicationID, Guid? _currentUserPositionID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetNotificationsByPosition",new {AApplicationID=_applicationID,ACurrentUserPositionID=_currentUserPositionID} , timeout );
}

public ResultSet GetNotificationsByPosition(Guid? _applicationID, Guid? _currentUserPositionID, int? timeout = null)
{
	using(var cmd = GetCommand_GetNotificationsByPosition(_applicationID, _currentUserPositionID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetOutboxMessages

public System.Data.SqlClient.SqlCommand GetCommand_GetOutboxMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetOutboxMessages", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@APageSize", IsOutput = false, Value = _pageSize == null ? DBNull.Value : (object)_pageSize }, 
					new Parameter { Name = "@APageIndex", IsOutput = false, Value = _pageIndex == null ? DBNull.Value : (object)_pageIndex }, 
					new Parameter { Name = "@ASortExp", IsOutput = false, Value = string.IsNullOrWhiteSpace(_sortExp) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_sortExp) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetOutboxMessagesAsync(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetOutboxMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetOutboxMessagesDapperAsync<T>(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetOutboxMessages",new {ACurrentUserID=_currentUserID,AApplicationID=_applicationID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),APageSize=_pageSize,APageIndex=_pageIndex,ASortExp=string.IsNullOrWhiteSpace(_sortExp) ? _sortExp : ReplaceArabicWithPersianChars(_sortExp)} , timeout );
}

public ResultSet GetOutboxMessages(Guid? _currentUserID, Guid? _applicationID, string _title, int? _pageSize, int? _pageIndex, string _sortExp, int? timeout = null)
{
	using(var cmd = GetCommand_GetOutboxMessages(_currentUserID, _applicationID, _title, _pageSize, _pageIndex, _sortExp, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyAnnouncement

public System.Data.SqlClient.SqlCommand GetCommand_ModifyAnnouncement(bool? _isNewRecord, Guid? _id, Guid? _applicationID, byte? _type, string _title, string _content, string _extendedContent, bool? _enable, DateTime? _releaseDate, DateTime? _dueDate, int? _order, Guid? _userID, bool? _pinned, string _positionTypes, bool? _allUsers, bool? _authorizedUsers, bool? _unAuthorizedUsers, bool? _expanded, Guid? _provinceID, byte? _priority, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyAnnouncement", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@AExtendedContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_extendedContent) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_extendedContent) }, 
					new Parameter { Name = "@AEnable", IsOutput = false, Value = _enable == null ? DBNull.Value : (object)_enable }, 
					new Parameter { Name = "@AReleaseDate", IsOutput = false, Value = _releaseDate == null ? DBNull.Value : (object)_releaseDate }, 
					new Parameter { Name = "@ADueDate", IsOutput = false, Value = _dueDate == null ? DBNull.Value : (object)_dueDate }, 
					new Parameter { Name = "@AOrder", IsOutput = false, Value = _order == null ? DBNull.Value : (object)_order }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@APinned", IsOutput = false, Value = _pinned == null ? DBNull.Value : (object)_pinned }, 
					new Parameter { Name = "@APositionTypes", IsOutput = false, Value = string.IsNullOrWhiteSpace(_positionTypes) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_positionTypes) }, 
					new Parameter { Name = "@AAllUsers", IsOutput = false, Value = _allUsers == null ? DBNull.Value : (object)_allUsers }, 
					new Parameter { Name = "@AAuthorizedUsers", IsOutput = false, Value = _authorizedUsers == null ? DBNull.Value : (object)_authorizedUsers }, 
					new Parameter { Name = "@AUnAuthorizedUsers", IsOutput = false, Value = _unAuthorizedUsers == null ? DBNull.Value : (object)_unAuthorizedUsers }, 
					new Parameter { Name = "@AExpanded", IsOutput = false, Value = _expanded == null ? DBNull.Value : (object)_expanded }, 
					new Parameter { Name = "@AProvinceID", IsOutput = false, Value = _provinceID == null ? DBNull.Value : (object)_provinceID }, 
					new Parameter { Name = "@APriority", IsOutput = false, Value = _priority == null ? DBNull.Value : (object)_priority }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyAnnouncementAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, byte? _type, string _title, string _content, string _extendedContent, bool? _enable, DateTime? _releaseDate, DateTime? _dueDate, int? _order, Guid? _userID, bool? _pinned, string _positionTypes, bool? _allUsers, bool? _authorizedUsers, bool? _unAuthorizedUsers, bool? _expanded, Guid? _provinceID, byte? _priority, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAnnouncement(_isNewRecord, _id, _applicationID, _type, _title, _content, _extendedContent, _enable, _releaseDate, _dueDate, _order, _userID, _pinned, _positionTypes, _allUsers, _authorizedUsers, _unAuthorizedUsers, _expanded, _provinceID, _priority, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyAnnouncementDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, byte? _type, string _title, string _content, string _extendedContent, bool? _enable, DateTime? _releaseDate, DateTime? _dueDate, int? _order, Guid? _userID, bool? _pinned, string _positionTypes, bool? _allUsers, bool? _authorizedUsers, bool? _unAuthorizedUsers, bool? _expanded, Guid? _provinceID, byte? _priority, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyAnnouncement",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,AType=_type,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),AExtendedContent=string.IsNullOrWhiteSpace(_extendedContent) ? _extendedContent : ReplaceArabicWithPersianChars(_extendedContent),AEnable=_enable,AReleaseDate=_releaseDate,ADueDate=_dueDate,AOrder=_order,AUserID=_userID,APinned=_pinned,APositionTypes=string.IsNullOrWhiteSpace(_positionTypes) ? _positionTypes : ReplaceArabicWithPersianChars(_positionTypes),AAllUsers=_allUsers,AAuthorizedUsers=_authorizedUsers,AUnAuthorizedUsers=_unAuthorizedUsers,AExpanded=_expanded,AProvinceID=_provinceID,APriority=_priority,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyAnnouncement(bool? _isNewRecord, Guid? _id, Guid? _applicationID, byte? _type, string _title, string _content, string _extendedContent, bool? _enable, DateTime? _releaseDate, DateTime? _dueDate, int? _order, Guid? _userID, bool? _pinned, string _positionTypes, bool? _allUsers, bool? _authorizedUsers, bool? _unAuthorizedUsers, bool? _expanded, Guid? _provinceID, byte? _priority, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAnnouncement(_isNewRecord, _id, _applicationID, _type, _title, _content, _extendedContent, _enable, _releaseDate, _dueDate, _order, _userID, _pinned, _positionTypes, _allUsers, _authorizedUsers, _unAuthorizedUsers, _expanded, _provinceID, _priority, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurvey

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurvey(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, bool? _enable, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurvey", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEnable", IsOutput = false, Value = _enable == null ? DBNull.Value : (object)_enable }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, bool? _enable, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurvey(_isNewRecord, _id, _applicationID, _name, _enable, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, bool? _enable, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurvey",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEnable=_enable,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurvey(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _name, bool? _enable, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurvey(_isNewRecord, _id, _applicationID, _name, _enable, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurveyAnswer

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurveyAnswer(bool? _isNewRecord, Guid? _id, Guid? _questionID, Guid? _userID, byte? _type, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurveyAnswer", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AQuestionID", IsOutput = false, Value = _questionID == null ? DBNull.Value : (object)_questionID }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyAnswerAsync(bool? _isNewRecord, Guid? _id, Guid? _questionID, Guid? _userID, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyAnswer(_isNewRecord, _id, _questionID, _userID, _type, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyAnswerDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _questionID, Guid? _userID, byte? _type, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurveyAnswer",new {AIsNewRecord=_isNewRecord,AID=_id,AQuestionID=_questionID,AUserID=_userID,AType=_type,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurveyAnswer(bool? _isNewRecord, Guid? _id, Guid? _questionID, Guid? _userID, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyAnswer(_isNewRecord, _id, _questionID, _userID, _type, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurveyGroup

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurveyGroup(bool? _isNewRecord, Guid? _id, Guid? _applicationSurveyID, string _name, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurveyGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationSurveyID", IsOutput = false, Value = _applicationSurveyID == null ? DBNull.Value : (object)_applicationSurveyID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyGroupAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationSurveyID, string _name, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyGroup(_isNewRecord, _id, _applicationSurveyID, _name, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyGroupDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationSurveyID, string _name, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurveyGroup",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationSurveyID=_applicationSurveyID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurveyGroup(bool? _isNewRecord, Guid? _id, Guid? _applicationSurveyID, string _name, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyGroup(_isNewRecord, _id, _applicationSurveyID, _name, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurveyParticipant

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurveyParticipant(bool? _isNewRecord, Guid? _id, Guid? _surveyID, Guid? _userID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurveyParticipant", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ASurveyID", IsOutput = false, Value = _surveyID == null ? DBNull.Value : (object)_surveyID }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyParticipantAsync(bool? _isNewRecord, Guid? _id, Guid? _surveyID, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyParticipant(_isNewRecord, _id, _surveyID, _userID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyParticipantDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _surveyID, Guid? _userID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurveyParticipant",new {AIsNewRecord=_isNewRecord,AID=_id,ASurveyID=_surveyID,AUserID=_userID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurveyParticipant(bool? _isNewRecord, Guid? _id, Guid? _surveyID, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyParticipant(_isNewRecord, _id, _surveyID, _userID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurveyQuestion

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurveyQuestion(bool? _isNewRecord, Guid? _id, Guid? _groupID, string _name, byte? _type, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurveyQuestion", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AGroupID", IsOutput = false, Value = _groupID == null ? DBNull.Value : (object)_groupID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyQuestionAsync(bool? _isNewRecord, Guid? _id, Guid? _groupID, string _name, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyQuestion(_isNewRecord, _id, _groupID, _name, _type, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyQuestionDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _groupID, string _name, byte? _type, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurveyQuestion",new {AIsNewRecord=_isNewRecord,AID=_id,AGroupID=_groupID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AType=_type,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurveyQuestion(bool? _isNewRecord, Guid? _id, Guid? _groupID, string _name, byte? _type, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyQuestion(_isNewRecord, _id, _groupID, _name, _type, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyApplicationSurveyQuestionChoice

public System.Data.SqlClient.SqlCommand GetCommand_ModifyApplicationSurveyQuestionChoice(bool? _isNewRecord, Guid? _id, Guid? _questionID, string _name, bool? _enable, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyApplicationSurveyQuestionChoice", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AQuestionID", IsOutput = false, Value = _questionID == null ? DBNull.Value : (object)_questionID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEnable", IsOutput = false, Value = _enable == null ? DBNull.Value : (object)_enable }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyApplicationSurveyQuestionChoiceAsync(bool? _isNewRecord, Guid? _id, Guid? _questionID, string _name, bool? _enable, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyQuestionChoice(_isNewRecord, _id, _questionID, _name, _enable, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyApplicationSurveyQuestionChoiceDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _questionID, string _name, bool? _enable, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyApplicationSurveyQuestionChoice",new {AIsNewRecord=_isNewRecord,AID=_id,AQuestionID=_questionID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEnable=_enable,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyApplicationSurveyQuestionChoice(bool? _isNewRecord, Guid? _id, Guid? _questionID, string _name, bool? _enable, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyApplicationSurveyQuestionChoice(_isNewRecord, _id, _questionID, _name, _enable, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyContact

public System.Data.SqlClient.SqlCommand GetCommand_ModifyContact(Guid? _id, Guid? _applicationID, string _name, string _email, string _tel, string _title, string _nationalCode, string _content, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyContact", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AEmail", IsOutput = false, Value = string.IsNullOrWhiteSpace(_email) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_email) }, 
					new Parameter { Name = "@ATel", IsOutput = false, Value = string.IsNullOrWhiteSpace(_tel) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_tel) }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@ANationalCode", IsOutput = false, Value = string.IsNullOrWhiteSpace(_nationalCode) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_nationalCode) }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyContactAsync(Guid? _id, Guid? _applicationID, string _name, string _email, string _tel, string _title, string _nationalCode, string _content, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContact(_id, _applicationID, _name, _email, _tel, _title, _nationalCode, _content, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyContactDapperAsync<T>(Guid? _id, Guid? _applicationID, string _name, string _email, string _tel, string _title, string _nationalCode, string _content, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyContact",new {AID=_id,AApplicationID=_applicationID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AEmail=string.IsNullOrWhiteSpace(_email) ? _email : ReplaceArabicWithPersianChars(_email),ATel=string.IsNullOrWhiteSpace(_tel) ? _tel : ReplaceArabicWithPersianChars(_tel),ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),ANationalCode=string.IsNullOrWhiteSpace(_nationalCode) ? _nationalCode : ReplaceArabicWithPersianChars(_nationalCode),AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyContact(Guid? _id, Guid? _applicationID, string _name, string _email, string _tel, string _title, string _nationalCode, string _content, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContact(_id, _applicationID, _name, _email, _tel, _title, _nationalCode, _content, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyContactDetail

public System.Data.SqlClient.SqlCommand GetCommand_ModifyContactDetail(bool? _isNewRecord, Guid? _id, Guid? _contactInfoID, byte? _type, string _name, string _value, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyContactDetail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AContactInfoID", IsOutput = false, Value = _contactInfoID == null ? DBNull.Value : (object)_contactInfoID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AValue", IsOutput = false, Value = string.IsNullOrWhiteSpace(_value) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_value) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyContactDetailAsync(bool? _isNewRecord, Guid? _id, Guid? _contactInfoID, byte? _type, string _name, string _value, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContactDetail(_isNewRecord, _id, _contactInfoID, _type, _name, _value, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyContactDetailDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _contactInfoID, byte? _type, string _name, string _value, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyContactDetail",new {AIsNewRecord=_isNewRecord,AID=_id,AContactInfoID=_contactInfoID,AType=_type,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AValue=string.IsNullOrWhiteSpace(_value) ? _value : ReplaceArabicWithPersianChars(_value),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyContactDetail(bool? _isNewRecord, Guid? _id, Guid? _contactInfoID, byte? _type, string _name, string _value, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContactDetail(_isNewRecord, _id, _contactInfoID, _type, _name, _value, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyContactInfo

public System.Data.SqlClient.SqlCommand GetCommand_ModifyContactInfo(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _name, int? _order, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyContactInfo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_name) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_name) }, 
					new Parameter { Name = "@AOrder", IsOutput = false, Value = _order == null ? DBNull.Value : (object)_order }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyContactInfoAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _name, int? _order, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContactInfo(_isNewRecord, _id, _parentID, _name, _order, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyContactInfoDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _name, int? _order, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyContactInfo",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,AName=string.IsNullOrWhiteSpace(_name) ? _name : ReplaceArabicWithPersianChars(_name),AOrder=_order,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyContactInfo(bool? _isNewRecord, Guid? _id, Guid? _parentID, string _name, int? _order, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyContactInfo(_isNewRecord, _id, _parentID, _name, _order, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyFAQ

public System.Data.SqlClient.SqlCommand GetCommand_ModifyFAQ(bool? _isNewRecord, Guid? _id, Guid? _fAQGroupID, string _question, string _answer, Guid? _userID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyFAQ", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AFAQGroupID", IsOutput = false, Value = _fAQGroupID == null ? DBNull.Value : (object)_fAQGroupID }, 
					new Parameter { Name = "@AQuestion", IsOutput = false, Value = string.IsNullOrWhiteSpace(_question) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_question) }, 
					new Parameter { Name = "@AAnswer", IsOutput = false, Value = string.IsNullOrWhiteSpace(_answer) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_answer) }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyFAQAsync(bool? _isNewRecord, Guid? _id, Guid? _fAQGroupID, string _question, string _answer, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyFAQ(_isNewRecord, _id, _fAQGroupID, _question, _answer, _userID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyFAQDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _fAQGroupID, string _question, string _answer, Guid? _userID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyFAQ",new {AIsNewRecord=_isNewRecord,AID=_id,AFAQGroupID=_fAQGroupID,AQuestion=string.IsNullOrWhiteSpace(_question) ? _question : ReplaceArabicWithPersianChars(_question),AAnswer=string.IsNullOrWhiteSpace(_answer) ? _answer : ReplaceArabicWithPersianChars(_answer),AUserID=_userID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyFAQ(bool? _isNewRecord, Guid? _id, Guid? _fAQGroupID, string _question, string _answer, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyFAQ(_isNewRecord, _id, _fAQGroupID, _question, _answer, _userID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyFAQGroup

public System.Data.SqlClient.SqlCommand GetCommand_ModifyFAQGroup(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _title, Guid? _userID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyFAQGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AUserID", IsOutput = false, Value = _userID == null ? DBNull.Value : (object)_userID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyFAQGroupAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _title, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyFAQGroup(_isNewRecord, _id, _applicationID, _title, _userID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyFAQGroupDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _title, Guid? _userID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyFAQGroup",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AUserID=_userID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyFAQGroup(bool? _isNewRecord, Guid? _id, Guid? _applicationID, string _title, Guid? _userID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyFAQGroup(_isNewRecord, _id, _applicationID, _title, _userID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyMessage

public System.Data.SqlClient.SqlCommand GetCommand_ModifyMessage(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderUserID, string _content, string _title, Guid? _parentID, string _receiverUserIDs, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyMessage", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ASenderUserID", IsOutput = false, Value = _senderUserID == null ? DBNull.Value : (object)_senderUserID }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AReceiverUserIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_receiverUserIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_receiverUserIDs) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyMessageAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderUserID, string _content, string _title, Guid? _parentID, string _receiverUserIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyMessage(_isNewRecord, _id, _applicationID, _senderUserID, _content, _title, _parentID, _receiverUserIDs, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyMessageDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderUserID, string _content, string _title, Guid? _parentID, string _receiverUserIDs, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyMessage",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,ASenderUserID=_senderUserID,AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AParentID=_parentID,AReceiverUserIDs=string.IsNullOrWhiteSpace(_receiverUserIDs) ? _receiverUserIDs : ReplaceArabicWithPersianChars(_receiverUserIDs),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyMessage(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderUserID, string _content, string _title, Guid? _parentID, string _receiverUserIDs, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyMessage(_isNewRecord, _id, _applicationID, _senderUserID, _content, _title, _parentID, _receiverUserIDs, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyNotification

public System.Data.SqlClient.SqlCommand GetCommand_ModifyNotification(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderPositionID, string _title, string _content, byte? _state, byte? _priority, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyNotification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@ASenderPositionID", IsOutput = false, Value = _senderPositionID == null ? DBNull.Value : (object)_senderPositionID }, 
					new Parameter { Name = "@ATitle", IsOutput = false, Value = string.IsNullOrWhiteSpace(_title) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_title) }, 
					new Parameter { Name = "@AContent", IsOutput = false, Value = string.IsNullOrWhiteSpace(_content) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_content) }, 
					new Parameter { Name = "@AState", IsOutput = false, Value = _state == null ? DBNull.Value : (object)_state }, 
					new Parameter { Name = "@APriority", IsOutput = false, Value = _priority == null ? DBNull.Value : (object)_priority }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyNotificationAsync(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderPositionID, string _title, string _content, byte? _state, byte? _priority, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyNotification(_isNewRecord, _id, _applicationID, _senderPositionID, _title, _content, _state, _priority, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyNotificationDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderPositionID, string _title, string _content, byte? _state, byte? _priority, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyNotification",new {AIsNewRecord=_isNewRecord,AID=_id,AApplicationID=_applicationID,ASenderPositionID=_senderPositionID,ATitle=string.IsNullOrWhiteSpace(_title) ? _title : ReplaceArabicWithPersianChars(_title),AContent=string.IsNullOrWhiteSpace(_content) ? _content : ReplaceArabicWithPersianChars(_content),AState=_state,APriority=_priority,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyNotification(bool? _isNewRecord, Guid? _id, Guid? _applicationID, Guid? _senderPositionID, string _title, string _content, byte? _state, byte? _priority, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyNotification(_isNewRecord, _id, _applicationID, _senderPositionID, _title, _content, _state, _priority, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyNotificationCondition

public System.Data.SqlClient.SqlCommand GetCommand_ModifyNotificationCondition(Guid? _id, bool? _isNewRecord, Guid? _notificationID, Guid? _departmentID, Guid? _provinceID, byte? _positionType, Guid? _positionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spModifyNotificationCondition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@ANotificationID", IsOutput = false, Value = _notificationID == null ? DBNull.Value : (object)_notificationID }, 
					new Parameter { Name = "@ADepartmentID", IsOutput = false, Value = _departmentID == null ? DBNull.Value : (object)_departmentID }, 
					new Parameter { Name = "@AProvinceID", IsOutput = false, Value = _provinceID == null ? DBNull.Value : (object)_provinceID }, 
					new Parameter { Name = "@APositionType", IsOutput = false, Value = _positionType == null ? DBNull.Value : (object)_positionType }, 
					new Parameter { Name = "@APositionID", IsOutput = false, Value = _positionID == null ? DBNull.Value : (object)_positionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyNotificationConditionAsync(Guid? _id, bool? _isNewRecord, Guid? _notificationID, Guid? _departmentID, Guid? _provinceID, byte? _positionType, Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyNotificationCondition(_id, _isNewRecord, _notificationID, _departmentID, _provinceID, _positionType, _positionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyNotificationConditionDapperAsync<T>(Guid? _id, bool? _isNewRecord, Guid? _notificationID, Guid? _departmentID, Guid? _provinceID, byte? _positionType, Guid? _positionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spModifyNotificationCondition",new {AID=_id,AIsNewRecord=_isNewRecord,ANotificationID=_notificationID,ADepartmentID=_departmentID,AProvinceID=_provinceID,APositionType=_positionType,APositionID=_positionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyNotificationCondition(Guid? _id, bool? _isNewRecord, Guid? _notificationID, Guid? _departmentID, Guid? _provinceID, byte? _positionType, Guid? _positionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyNotificationCondition(_id, _isNewRecord, _notificationID, _departmentID, _provinceID, _positionType, _positionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ArchiveNotification

public System.Data.SqlClient.SqlCommand GetCommand_ArchiveNotification(Guid? _notificationID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spArchiveNotification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ANotificationID", IsOutput = false, Value = _notificationID == null ? DBNull.Value : (object)_notificationID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ArchiveNotificationAsync(Guid? _notificationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ArchiveNotification(_notificationID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ArchiveNotificationDapperAsync<T>(Guid? _notificationID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spArchiveNotification",new {ANotificationID=_notificationID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ArchiveNotification(Guid? _notificationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ArchiveNotification(_notificationID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteAnnouncement

public System.Data.SqlClient.SqlCommand GetCommand_DeleteAnnouncement(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteAnnouncement", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteAnnouncementAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAnnouncement(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteAnnouncementDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteAnnouncement",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteAnnouncement(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAnnouncement(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteApplicationSurvey

public System.Data.SqlClient.SqlCommand GetCommand_DeleteApplicationSurvey(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteApplicationSurvey", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentPositionID", IsOutput = false, Value = _currentPositionID == null ? DBNull.Value : (object)_currentPositionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteApplicationSurveyAsync(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurvey(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteApplicationSurveyDapperAsync<T>(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteApplicationSurvey",new {AID=_id,ACurrentPositionID=_currentPositionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteApplicationSurvey(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurvey(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteApplicationSurveyGroup

public System.Data.SqlClient.SqlCommand GetCommand_DeleteApplicationSurveyGroup(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteApplicationSurveyGroup", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentPositionID", IsOutput = false, Value = _currentPositionID == null ? DBNull.Value : (object)_currentPositionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteApplicationSurveyGroupAsync(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyGroup(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteApplicationSurveyGroupDapperAsync<T>(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteApplicationSurveyGroup",new {AID=_id,ACurrentPositionID=_currentPositionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteApplicationSurveyGroup(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyGroup(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region PermanentDeleteMessage

public System.Data.SqlClient.SqlCommand GetCommand_PermanentDeleteMessage(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spPermanentDeleteMessage", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AMessageID", IsOutput = false, Value = _messageID == null ? DBNull.Value : (object)_messageID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> PermanentDeleteMessageAsync(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_PermanentDeleteMessage(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> PermanentDeleteMessageDapperAsync<T>(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spPermanentDeleteMessage",new {ACurrentUserID=_currentUserID,AMessageID=_messageID} , timeout );
}

public ResultSet PermanentDeleteMessage(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_PermanentDeleteMessage(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteApplicationSurveyQuestion

public System.Data.SqlClient.SqlCommand GetCommand_DeleteApplicationSurveyQuestion(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteApplicationSurveyQuestion", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentPositionID", IsOutput = false, Value = _currentPositionID == null ? DBNull.Value : (object)_currentPositionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteApplicationSurveyQuestionAsync(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyQuestion(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteApplicationSurveyQuestionDapperAsync<T>(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteApplicationSurveyQuestion",new {AID=_id,ACurrentPositionID=_currentPositionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteApplicationSurveyQuestion(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyQuestion(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteApplicationSurveyQuestionChoice

public System.Data.SqlClient.SqlCommand GetCommand_DeleteApplicationSurveyQuestionChoice(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteApplicationSurveyQuestionChoice", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ACurrentPositionID", IsOutput = false, Value = _currentPositionID == null ? DBNull.Value : (object)_currentPositionID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteApplicationSurveyQuestionChoiceAsync(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyQuestionChoice(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteApplicationSurveyQuestionChoiceDapperAsync<T>(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteApplicationSurveyQuestionChoice",new {AID=_id,ACurrentPositionID=_currentPositionID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteApplicationSurveyQuestionChoice(Guid? _id, Guid? _currentPositionID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteApplicationSurveyQuestionChoice(_id, _currentPositionID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SendMessage

public System.Data.SqlClient.SqlCommand GetCommand_SendMessage(Guid? _messageID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSendMessage", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AMessageID", IsOutput = false, Value = _messageID == null ? DBNull.Value : (object)_messageID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SendMessageAsync(Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_SendMessage(_messageID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SendMessageDapperAsync<T>(Guid? _messageID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSendMessage",new {AMessageID=_messageID} , timeout );
}

public ResultSet SendMessage(Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_SendMessage(_messageID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SendNotification

public System.Data.SqlClient.SqlCommand GetCommand_SendNotification(Guid? _notificationID, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSendNotification", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ANotificationID", IsOutput = false, Value = _notificationID == null ? DBNull.Value : (object)_notificationID }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SendNotificationAsync(Guid? _notificationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SendNotification(_notificationID, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SendNotificationDapperAsync<T>(Guid? _notificationID, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSendNotification",new {ANotificationID=_notificationID,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SendNotification(Guid? _notificationID, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SendNotification(_notificationID, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetAnnouncementOrders

public System.Data.SqlClient.SqlCommand GetCommand_SetAnnouncementOrders(string _orders, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSetAnnouncementOrders", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AOrders", IsOutput = false, Value = string.IsNullOrWhiteSpace(_orders) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_orders) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
					new Parameter { Name = "@AResult", IsOutput = true }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetAnnouncementOrdersAsync(string _orders, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetAnnouncementOrders(_orders, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetAnnouncementOrdersDapperAsync<T>(string _orders, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSetAnnouncementOrders",new {AOrders=string.IsNullOrWhiteSpace(_orders) ? _orders : ReplaceArabicWithPersianChars(_orders),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetAnnouncementOrders(string _orders, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetAnnouncementOrders(_orders, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetArchive

public System.Data.SqlClient.SqlCommand GetCommand_SetArchive(Guid? _id, byte? _archiveType, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSetArchive", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AArchiveType", IsOutput = false, Value = _archiveType == null ? DBNull.Value : (object)_archiveType }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetArchiveAsync(Guid? _id, byte? _archiveType, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetArchive(_id, _archiveType, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetArchiveDapperAsync<T>(Guid? _id, byte? _archiveType, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSetArchive",new {AID=_id,AArchiveType=_archiveType,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetArchive(Guid? _id, byte? _archiveType, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetArchive(_id, _archiveType, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteContactDetail

public System.Data.SqlClient.SqlCommand GetCommand_DeleteContactDetail(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteContactDetail", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteContactDetailAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteContactDetail(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteContactDetailDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteContactDetail",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteContactDetail(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteContactDetail(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteContactInfo

public System.Data.SqlClient.SqlCommand GetCommand_DeleteContactInfo(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteContactInfo", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteContactInfoAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteContactInfo(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteContactInfoDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteContactInfo",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteContactInfo(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteContactInfo(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetMessageAsSeen

public System.Data.SqlClient.SqlCommand GetCommand_SetMessageAsSeen(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSetMessageAsSeen", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ACurrentUserID", IsOutput = false, Value = _currentUserID == null ? DBNull.Value : (object)_currentUserID }, 
					new Parameter { Name = "@AMessageID", IsOutput = false, Value = _messageID == null ? DBNull.Value : (object)_messageID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetMessageAsSeenAsync(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_SetMessageAsSeen(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetMessageAsSeenDapperAsync<T>(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSetMessageAsSeen",new {ACurrentUserID=_currentUserID,AMessageID=_messageID} , timeout );
}

public ResultSet SetMessageAsSeen(Guid? _currentUserID, Guid? _messageID, int? timeout = null)
{
	using(var cmd = GetCommand_SetMessageAsSeen(_currentUserID, _messageID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetNote

public System.Data.SqlClient.SqlCommand GetCommand_SetNote(Guid? _id, string _note, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSetNote", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ANote", IsOutput = false, Value = string.IsNullOrWhiteSpace(_note) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_note) }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetNoteAsync(Guid? _id, string _note, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetNote(_id, _note, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetNoteDapperAsync<T>(Guid? _id, string _note, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSetNote",new {AID=_id,ANote=string.IsNullOrWhiteSpace(_note) ? _note : ReplaceArabicWithPersianChars(_note),ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet SetNote(Guid? _id, string _note, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_SetNote(_id, _note, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region SetNotificationPositionFromCondition

public System.Data.SqlClient.SqlCommand GetCommand_SetNotificationPositionFromCondition(Guid? _applicationID, Guid? _conditionID, int? timeout = null)
{
var cmd = base.CreateCommand("app.spSetNotificationPositionFromCondition", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AApplicationID", IsOutput = false, Value = _applicationID == null ? DBNull.Value : (object)_applicationID }, 
					new Parameter { Name = "@AConditionID", IsOutput = false, Value = _conditionID == null ? DBNull.Value : (object)_conditionID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> SetNotificationPositionFromConditionAsync(Guid? _applicationID, Guid? _conditionID, int? timeout = null)
{
	using(var cmd = GetCommand_SetNotificationPositionFromCondition(_applicationID, _conditionID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> SetNotificationPositionFromConditionDapperAsync<T>(Guid? _applicationID, Guid? _conditionID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spSetNotificationPositionFromCondition",new {AApplicationID=_applicationID,AConditionID=_conditionID} , timeout );
}

public ResultSet SetNotificationPositionFromCondition(Guid? _applicationID, Guid? _conditionID, int? timeout = null)
{
	using(var cmd = GetCommand_SetNotificationPositionFromCondition(_applicationID, _conditionID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteFAQ

public System.Data.SqlClient.SqlCommand GetCommand_DeleteFAQ(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("app.spDeleteFAQ", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteFAQAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteFAQ(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteFAQDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spDeleteFAQ",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteFAQ(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteFAQ(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetApplicationSurveyGroupByList

public System.Data.SqlClient.SqlCommand GetCommand_GetApplicationSurveyGroupByList(int? timeout = null)
{
var cmd = base.CreateCommand("app.spGetApplicationSurveyGroupByList", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetApplicationSurveyGroupByListAsync(int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroupByList(timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetApplicationSurveyGroupByListDapperAsync<T>(int? timeout = null)
{
	return await  DapperQueryAsync<T>("app.spGetApplicationSurveyGroupByList",new {} , timeout );
}

public ResultSet GetApplicationSurveyGroupByList(int? timeout = null)
{
	using(var cmd = GetCommand_GetApplicationSurveyGroupByList(timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

}

class PBL: Database
{
#region Constructors
public PBL(string connectionString)
	:base(connectionString){}

public PBL(string connectionString, IModelValueBinder modelValueBinder)
	:base(connectionString, modelValueBinder){}
#endregion

#region ExecPasswordBlackList

public System.Data.SqlClient.SqlCommand GetCommand_ExecPasswordBlackList(int? _repeatCount, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spExecPasswordBlackList", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ARepeatCount", IsOutput = false, Value = _repeatCount == null ? DBNull.Value : (object)_repeatCount }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ExecPasswordBlackListAsync(int? _repeatCount, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ExecPasswordBlackList(_repeatCount, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ExecPasswordBlackListDapperAsync<T>(int? _repeatCount, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spExecPasswordBlackList",new {ARepeatCount=_repeatCount,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ExecPasswordBlackList(int? _repeatCount, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ExecPasswordBlackList(_repeatCount, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAttachment

public System.Data.SqlClient.SqlCommand GetCommand_GetAttachment(Guid? _id, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAttachmentAsync(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachment(_id, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAttachmentDapperAsync<T>(Guid? _id, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetAttachment",new {AID=_id} , timeout );
}

public ResultSet GetAttachment(Guid? _id, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachment(_id, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAttachmentsByParentIDs

public System.Data.SqlClient.SqlCommand GetCommand_GetAttachmentsByParentIDs(string _parentIDs, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetAttachmentsByParentIDs", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentIDs", IsOutput = false, Value = string.IsNullOrWhiteSpace(_parentIDs) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_parentIDs) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAttachmentsByParentIDsAsync(string _parentIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachmentsByParentIDs(_parentIDs, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAttachmentsByParentIDsDapperAsync<T>(string _parentIDs, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetAttachmentsByParentIDs",new {AParentIDs=string.IsNullOrWhiteSpace(_parentIDs) ? _parentIDs : ReplaceArabicWithPersianChars(_parentIDs)} , timeout );
}

public ResultSet GetAttachmentsByParentIDs(string _parentIDs, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachmentsByParentIDs(_parentIDs, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetAttachments

public System.Data.SqlClient.SqlCommand GetCommand_GetAttachments(Guid? _parentID, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetAttachments", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetAttachmentsAsync(Guid? _parentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachments(_parentID, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetAttachmentsDapperAsync<T>(Guid? _parentID, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetAttachments",new {AParentID=_parentID} , timeout );
}

public ResultSet GetAttachments(Guid? _parentID, int? timeout = null)
{
	using(var cmd = GetCommand_GetAttachments(_parentID, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region GetPasswordBlackList

public System.Data.SqlClient.SqlCommand GetCommand_GetPasswordBlackList(string _password, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spGetPasswordBlackList", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@APassword", IsOutput = false, Value = string.IsNullOrWhiteSpace(_password) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_password) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> GetPasswordBlackListAsync(string _password, int? timeout = null)
{
	using(var cmd = GetCommand_GetPasswordBlackList(_password, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> GetPasswordBlackListDapperAsync<T>(string _password, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spGetPasswordBlackList",new {APassword=string.IsNullOrWhiteSpace(_password) ? _password : ReplaceArabicWithPersianChars(_password)} , timeout );
}

public ResultSet GetPasswordBlackList(string _password, int? timeout = null)
{
	using(var cmd = GetCommand_GetPasswordBlackList(_password, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region ModifyAttachment

public System.Data.SqlClient.SqlCommand GetCommand_ModifyAttachment(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, byte[] _data, bool? _isUnique, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spModifyAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AIsNewRecord", IsOutput = false, Value = _isNewRecord == null ? DBNull.Value : (object)_isNewRecord }, 
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@AParentID", IsOutput = false, Value = _parentID == null ? DBNull.Value : (object)_parentID }, 
					new Parameter { Name = "@AType", IsOutput = false, Value = _type == null ? DBNull.Value : (object)_type }, 
					new Parameter { Name = "@AFileName", IsOutput = false, Value = string.IsNullOrWhiteSpace(_fileName) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_fileName) }, 
					new Parameter { Name = "@AComment", IsOutput = false, Value = string.IsNullOrWhiteSpace(_comment) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_comment) }, 
					new Parameter { Name = "@AData", IsOutput = false, Value = _data == null ? DBNull.Value : (object)_data }, 
					new Parameter { Name = "@AIsUnique", IsOutput = false, Value = _isUnique == null ? DBNull.Value : (object)_isUnique }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> ModifyAttachmentAsync(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, byte[] _data, bool? _isUnique, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAttachment(_isNewRecord, _id, _parentID, _type, _fileName, _comment, _data, _isUnique, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> ModifyAttachmentDapperAsync<T>(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, byte[] _data, bool? _isUnique, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spModifyAttachment",new {AIsNewRecord=_isNewRecord,AID=_id,AParentID=_parentID,AType=_type,AFileName=string.IsNullOrWhiteSpace(_fileName) ? _fileName : ReplaceArabicWithPersianChars(_fileName),AComment=string.IsNullOrWhiteSpace(_comment) ? _comment : ReplaceArabicWithPersianChars(_comment),AData=_data,AIsUnique=_isUnique,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet ModifyAttachment(bool? _isNewRecord, Guid? _id, Guid? _parentID, byte? _type, string _fileName, string _comment, byte[] _data, bool? _isUnique, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_ModifyAttachment(_isNewRecord, _id, _parentID, _type, _fileName, _comment, _data, _isUnique, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region AddLog

public System.Data.SqlClient.SqlCommand GetCommand_AddLog(string _log, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spAddLog", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> AddLogAsync(string _log, int? timeout = null)
{
	using(var cmd = GetCommand_AddLog(_log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> AddLogDapperAsync<T>(string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spAddLog",new {ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet AddLog(string _log, int? timeout = null)
{
	using(var cmd = GetCommand_AddLog(_log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

#region DeleteAttachment

public System.Data.SqlClient.SqlCommand GetCommand_DeleteAttachment(Guid? _id, string _log, int? timeout = null)
{
var cmd = base.CreateCommand("pbl.spDeleteAttachment", 
	System.Data.CommandType.StoredProcedure, 
	new Parameter[]{
					new Parameter { Name = "@AID", IsOutput = false, Value = _id == null ? DBNull.Value : (object)_id }, 
					new Parameter { Name = "@ALog", IsOutput = false, Value = string.IsNullOrWhiteSpace(_log) ? DBNull.Value : (object)ReplaceArabicWithPersianChars(_log) }, 
	});

			if (timeout != null)
				cmd.CommandTimeout = (int)timeout;
			return cmd;
}

public async Task<ResultSet> DeleteAttachmentAsync(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAttachment(_id, _log, timeout))
{
	return new ResultSet(cmd, await ExecuteAsync(cmd), _modelValueBinder);
}
}

public async Task<AppCore.Result<IEnumerable<T>>> DeleteAttachmentDapperAsync<T>(Guid? _id, string _log, int? timeout = null)
{
	return await  DapperQueryAsync<T>("pbl.spDeleteAttachment",new {AID=_id,ALog=string.IsNullOrWhiteSpace(_log) ? _log : ReplaceArabicWithPersianChars(_log)} , timeout );
}

public ResultSet DeleteAttachment(Guid? _id, string _log, int? timeout = null)
{
	using(var cmd = GetCommand_DeleteAttachment(_id, _log, timeout))
{
	return new ResultSet(cmd, Execute(cmd), _modelValueBinder);
}
}

#endregion

}

}
