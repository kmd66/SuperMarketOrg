using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.Model;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class DynamicPermissionDataSource : DataSource, Core.DataSource.IDynamicPermissionDataSource
    {
        public DynamicPermissionDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.DynamicPermission>> ModifyAsync(bool isNewRecord, Core.Model.DynamicPermission model)
        {
            try
            {
                var details = new List<DynamicPermissionDetail>();

                if (model.ParentDepartments != null)
                    details.AddRange(model.ParentDepartments?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.ParentDepartment, GuidValue = x.ID }));

                if (model.Departments != null)
                    details.AddRange(model.Departments?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.Department, GuidValue = x.ID }));

                if (model.Provinces != null)
                    details.AddRange(model.Provinces?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.Province, GuidValue = x.ID }));

                if (model.Positions != null)
                details.AddRange(model.Positions?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.Position, GuidValue = x.ID }));

                if (model.DepartmentTypes != null)
                    details.AddRange(model.DepartmentTypes?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.DepartmentType, ByteValue= (byte)x }));

                if (model.PositionTypes != null)
                    details.AddRange(model.PositionTypes?.Select(x => new DynamicPermissionDetail { Type = DynamicPermissionDetailType.PositionType, ByteValue = (byte)x }));

                var result = await _dbORG.ModifyDynamicPermissionAsync(
                    _isNewRecord: isNewRecord, 
                    _id: model.ID, 
                    _applicationID: _requestInfo.ApplicationId,
                    _objectID: model.ObjectID, 
                    _order: model.Order,
                    _details: _objSerializer.Serialize(details)
                );

                if (result.DbSucceed())
                    return await GetAsync(model.ID);

                return result.ToActionResult<Core.Model.DynamicPermission>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.DynamicPermission>> CreateAsync(Core.Model.DynamicPermission DynamicPermission)
            => ModifyAsync(true, DynamicPermission);

        public Task<AppCore.Result<Core.Model.DynamicPermission>> UpdateAsync(Core.Model.DynamicPermission DynamicPermission)
            => ModifyAsync(false, DynamicPermission);

        public async Task<AppCore.Result> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbORG.DeleteDynamicPermissionAsync(id);

                return result.ToActionResult();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.DynamicPermission>>> ListAsync(Core.Model.DynamicPermissionListVM model)
        {
            try
            {
                var result = (await _dbORG.GetDynamicPermissionsAsync(
                    _objectID: model.ObjectID,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                )).ToListActionResult<Core.Model.DynamicPermission>();

                var detailResult = (await _dbORG.GetDynamicPermissionDetailsAsync(
                    _dynamicPermissionIDs: _objSerializer.Serialize(result.Data.Select(p => p.ID)),
                    _dynamicPermissionID: null
                    )).ToListActionResult<Core.Model.DynamicPermissionDetail>();

                result.Data.ToList().ForEach(p => p.ParentDepartments = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.ParentDepartment)?
                                                    .Select(d => new Department { ID = d.GuidValue, Name = d.DepartmentName })
                                                    .ToList());

                result.Data.ToList().ForEach(p => p.Departments = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Department)?
                                                    .Select(d => new Department { ID = d.GuidValue, Name = d.DepartmentName })
                                                    .ToList());

                result.Data.ToList().ForEach(p => p.Provinces = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Province)?
                                                    .Select(d => new Place { ID = d.GuidValue, Name = d.ProvinceName })
                                                    .ToList());

                result.Data.ToList().ForEach(p => p.Positions = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Position)?
                                                    .Select(d => new Position { ID = d.GuidValue, FirstName = d.FirstName, LastName = d.LastName })
                                                    .ToList());

                result.Data.ToList().ForEach(p => p.DepartmentTypes = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.DepartmentType)?
                                                    .Select(d => (DepartmentType)d.ByteValue)
                                                    .ToList());

                result.Data.ToList().ForEach(p => p.PositionTypes = detailResult.Data
                                                    .Where(d => d.DynamicPermissionID == p.ID)
                                                    .Where(d => d.Type == DynamicPermissionDetailType.PositionType)?
                                                    .Select(d => (PositionType)d.ByteValue)
                                                    .ToList());

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Position>>> ListPositionsAsync(Core.Model.DynamicPermissionListPositionsVM model)
        {
            try
            {
                var result = (await _dbORG.GetDynamicPermissionPositionsAsync(
                    _objectID: model.ObjectID,
                    _applicationID: _requestInfo.ApplicationId,
                    _sortExp: model.SortExp.ToSortExpString("ID"),
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize
                )).ToListActionResult<Position>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Model>>> ListObjectsByPositionAsync(Guid positoinId)
        {
            try
            {
                var result = (await _dbORG.GetDynamicPermissionObjectsByPositionAsync(
                    _positionID: positoinId,
                    _applicationID: _requestInfo.ApplicationId
                )).ToListActionResult<Model>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.DynamicPermission>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetDynamicPermissionAsync(
                    _id: id
                    )).ToActionResult<Core.Model.DynamicPermission>();

                var detailResult = (await _dbORG.GetDynamicPermissionDetailsAsync(
                    _dynamicPermissionIDs: null,
                    _dynamicPermissionID: id
                    )).ToListActionResult<Core.Model.DynamicPermissionDetail>();

                result.Data.ParentDepartments = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.ParentDepartment)?
                                                    .Select(d => new Department { ID = d.GuidValue, Name = d.DepartmentName })
                                                    .ToList();

                result.Data.Departments = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Department)?
                                                    .Select(d => new Department { ID = d.GuidValue, Name = d.DepartmentName })
                                                    .ToList();

                result.Data.Provinces = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Province)?
                                                    .Select(d => new Place { ID = d.GuidValue, Name = d.ProvinceName })
                                                    .ToList();

                result.Data.Positions = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.Position)?
                                                    .Select(d => new Position { ID = d.GuidValue, FirstName = d.FirstName, LastName = d.LastName })
                                                    .ToList();

                result.Data.DepartmentTypes = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.DepartmentType)?
                                                    .Select(d => (DepartmentType)d.ByteValue)
                                                    .ToList();

                result.Data.PositionTypes = detailResult.Data
                                                    .Where(d => d.Type == DynamicPermissionDetailType.PositionType)?
                                                    .Select(d => (PositionType)d.ByteValue)
                                                    .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}