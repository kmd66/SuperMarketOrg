using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kama.Library.Helper;
using mdl = Kama.Organization.Core.Model;
using Kama.Organization.Core;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class PositionDataSource : DataSource, Core.DataSource.IPositionDataSource
    {
        public PositionDataSource(AppCore.IOC.IContainer container,
            IAppSetting appSetting): base(container)
        {
            _appSetting = appSetting;
        }

        private readonly IAppSetting _appSetting;

        private async Task<AppCore.Result<Position>> ModifyAsync(bool isNewRecord, Position model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyPositionAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _applicationID: _requestInfo.ApplicationId,
                    _departmentID: model.DepartmentID,
                    _userID: model.UserID,
                    _type: (byte)model.Type,
                    _roleIDs: model.Roles.IsNullOrEmpty() ? null : _objSerializer.Serialize(model.Roles.Select(e => new { ID = e.ID })),
                    _log: log?.Value
                )).ToActionResult<Position>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<mdl.Position>> CreateAsync(mdl.Position position, AppCore.IActivityLog log)
        {
            position.ID = Guid.NewGuid();
            return ModifyAsync(true, position, log);
        }

        public Task<AppCore.Result<mdl.Position>> UpdateAsync(mdl.Position position, AppCore.IActivityLog log)
            => ModifyAsync(false, position, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeletePositionAsync(
                    _id: id, 
                    _removerID: _requestInfo.UserId, 
                    _log: log?.Value
                )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> SetDefaultAsync(Guid positionId, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.SetDefaultPositionAsync(
                    _positionID: positionId,
                    _log: log?.Value
                )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> RemoveUserAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.RemoveUserFromPositionAsync(
                    _positionID: id,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<mdl.Position<T>>>> ListAsync<T>(Guid? applicationId, mdl.PositionListVM model)
        {
            try
            {
                var result = (await _dbORG.GetPositionsAsync(
                    _iDs: model.IDs == null ? null : _objSerializer.Serialize(model.IDs.Select(x => new { ID = x })),
                    _applicationID: applicationId,
                    _departmentID: model.DepartmentId,
                    _type: (byte)model.Type,
                    _types: model.Types == null ? null : _objSerializer.Serialize(model.Types.Select(x => new { Type = x })),
                    _userType: (byte)model.UserType,
                    _userID: model.UserID,
                    _nationalCode: model.NationalCode,
                    _firstName: model.FirstName,
                    _lastName: model.LastName,
                    _name: model.Name,
                    _email: model.Email,
                    _cellphone: model.CellPhone,
                    _departmentName: model.DepartmentName,
                    _enableState: (byte)model.EnableState,
                    _roleID: model.RoleID,
                    _pageSize: model.PageSize,
                    _pageIndex: model.PageIndex
                )).ToListActionResult<Core.Model.Position<T>>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<mdl.Position<T>>>> ListWithRolesAsync<T>(mdl.PositionListVM model)
        {
            try
            {
                var result = (await _dbORG.GetPositionsWithRolesAsync(
                    _iDs: model.IDs == null ? null : _objSerializer.Serialize(model.IDs.Select(x => new { ID = x })),
                    _applicationID: _requestInfo.ApplicationId,
                    _departmentID: model.DepartmentId,
                    _type: (byte)model.Type,
                    _types: model.Types == null ? null : _objSerializer.Serialize(model.Types.Select(x => new { Type = x })),
                    _userType: (byte)model.UserType,
                    _userID: model.UserID,
                    _nationalCode: model.NationalCode,
                    _firstName: model.FirstName,
                    _lastName: model.LastName,
                    _name: model.Name,
                    _email: model.Email,
                    _cellphone: model.CellPhone,
                    _departmentName: model.DepartmentName,
                    _enableState: (byte)model.EnableState,
                    _roleID: model.RoleID,
                    _pageSize: model.PageSize,
                    _pageIndex: model.PageIndex
                )).ToListActionResult<Position<T>>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<mdl.Position>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetPositionAsync(
                        _id: id
                    )).ToActionResult<Core.Model.Position>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<mdl.GetOnlineUsersAndPositionsCountVM>> GetOnlineCountAsync()
        {
            try
            {
                var result = (await _dbORG.GetOnlineUsersAndPositionsCountAsync(
                        _applicationID: _requestInfo.ApplicationId,
                        _accessTokenExpireTimeSpan: _appSetting.AccessTokenExpireTimeSpan
                    )).ToActionResult<Core.Model.GetOnlineUsersAndPositionsCountVM>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<mdl.Command>>> GetPermissionsAsync(Guid positionId, Guid? commandId)
        {
            try
            {
                var result = (await _dbORG.GetPositionPermissionsAsync(
                    _positionID: positionId,
                    _commandID: commandId
                )).ToListActionResult<mdl.Command>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}