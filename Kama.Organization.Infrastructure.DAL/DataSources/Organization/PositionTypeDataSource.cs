using Kama.AppCore;
using Kama.Library.Helper;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using model = Core.Model;

    class PositionTypeDataSource : DataSource, Core.DataSource.IPositionTypeDataSource
    {
        public PositionTypeDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<PositionTypeModel>> ModifyAsync(bool isNewRecord, PositionTypeModel model, AppCore.IActivityLog log)
        {
            try
            {
                var command1 = _dbORG.GetCommand_ModifyPositionType(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _applicationID: _requestInfo.ApplicationId,
                    _userType: (byte)model.UserType,
                    _positionType: (byte)model.PositionType,
                    _log: log?.Value
                );

                var command2 = _dbORG.GetCommand_MapDepartmentsToPosition(
                    _applicationID: _requestInfo.ApplicationId,
                    _positionType: (byte)model.PositionType,
                    _mappings: model.PositionDepartmentMappings == null ? null : _objSerializer.Serialize(model.PositionDepartmentMappings.Select(m => new { m.DepartmentType, m.MaxUsersCount })),
                    _log: log?.Value
                    );

                _dbORG.BatchExcute(command1, command2);

                return await GetAsync(model.ID);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<PositionTypeModel>> CreateAsync(PositionTypeModel model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<PositionTypeModel>> UpdateAsync(PositionTypeModel model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<Result> SetRolesAsync(PositionTypeModel model, IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.SetPositionTypeRolesAsync(
                        _applicationID: _requestInfo.ApplicationId,
                        _positionType: (byte)model.PositionType,
                        _roleIDs: model.Roles == null ? null : _objSerializer.Serialize(model.Roles.Select(s => new { ID = s.ID })),
                        _log: log?.Value
                    )).ToListActionResult<PositionTypeModel>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<PositionTypeModel>>> ListAsync()
        {
            try
            {
                var result = (await _dbORG.GetPositionTypesAsync(
                        _applicationID: _requestInfo.ApplicationId
                    )).ToListActionResult<PositionTypeModel>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<PositionTypeModel>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetPositionTypeAsync(
                    _id: id
                )).ToActionResult<PositionTypeModel>();

                if (!result.Success)
                    return result;

                var positionMappingResult = (await _dbORG.GetPositionDepartmentMappingsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _positionType: (byte)result.Data.PositionType,
                    _departmentType: 0,
                    _sortExp: "",
                    _pageIndex: 0,
                    _pageSize: 0
                )).ToListActionResult<Core.Model.PositionDepartmentMapping>();

                result.Data.PositionDepartmentMappings = positionMappingResult.Data.ToList();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Role>>> GetRolesAsync(PositionType positionType)
        {
            try
            {
                var result = (await _dbORG.GetPositionTypeRolesAsync(
                        _positionType: (byte)positionType,
                        _applicationID: _requestInfo.ApplicationId
                    )).ToListActionResult<Role>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

