using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Library.Helper;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class PositionDepartmentMappingDataSource : DataSource, Core.DataSource.IPositionDepartmentMappingDataSource
    {
        public PositionDepartmentMappingDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>> MapDepartmentsToPosition(Core.Model.PositionType positionType, IEnumerable<Core.Model.PositionDepartmentMapping> list, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.MapDepartmentsToPositionAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _positionType: (byte)positionType,
                    _mappings: list == null ? null : _objSerializer.Serialize(list.Select(m => new { m.DepartmentType, m.MaxUsersCount })),
                    _log: log?.Value
                    )).ToActionResult<Core.Model.PositionDepartmentMapping>();

                if (result.Success)
                    return await ListAsync(new Core.Model.PositionDepartmentMappingListVM { PositionType = positionType });

                return AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>.Failure(message: result.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>> MapPositionsToDepartment(Core.Model.DepartmentType departmentType, IEnumerable<Core.Model.PositionDepartmentMapping> list, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.MapPositionsToDepartmentAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _departmentType: (byte)departmentType,
                    _mappings: list == null ? null : _objSerializer.Serialize(list.Select(m => new { m.PositionType, m.MaxUsersCount })),
                    _log: log?.Value
                    )).ToActionResult<Core.Model.PositionDepartmentMapping>();

                if (result.Success)
                    return await ListAsync(new Core.Model.PositionDepartmentMappingListVM { DepartmentType = departmentType});

                return AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>.Failure(message: result.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>> ListAsync(Core.Model.PositionDepartmentMappingListVM model)
        {
            try
            {
                var result = (await _dbORG.GetPositionDepartmentMappingsAsync(
                        _applicationID: _requestInfo.ApplicationId,
                        _positionType: (byte)model.PositionType,
                        _departmentType: (byte)model.DepartmentType,
                        _sortExp: model.SortExp.ToSortExpString(),
                        _pageIndex: model.PageIndex,
                        _pageSize: model.PageSize
                    )).ToListActionResult<Core.Model.PositionDepartmentMapping>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}