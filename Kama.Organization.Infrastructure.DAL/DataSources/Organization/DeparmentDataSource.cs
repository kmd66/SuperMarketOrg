using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class DepartmentDataSource : DataSource, Core.DataSource.IDepartmentDataSource
    {
        public DepartmentDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Department>> ModifyAsync(bool isNewRecord, Core.Model.Department model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyDepartmentAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _node: model.Node,
                    _provinceID: model.ProvinceID,
                    _code: model.Code,
                    _enabled: model.Enabled,
                    _type: (byte)model.Type,
                    _name: model.Name,
                    _address: model.Address,
                    _postalCode: model.PostalCode,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Department>();

                if(result.Success)
                    return await this.GetAsync(model.ID);

                return AppCore.Result<Core.Model.Department>.Successful(message: result.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Department>> CreateAsync(Core.Model.Department model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Department>> UpdateAsync(Core.Model.Department model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeleteDepartmentAsync(
                        _id: id, 
                        _currentUserID: _requestInfo.UserId,
                        _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Department>>> ListAsync(Core.Model.DepartmentListVM department)
        {
            try
            {
                var result = (await _dbORG.GetDepartmentsAsync(
                    _parentID: department.ParentID,
                    _provinceID: department.ProvinceID,
                    _type: (byte)department.Type,
                    _name: department.Name,
                    _code: department.Code,
                    _searchWithHierarchy: department.SearchWithHierarchy,
                    _pageIndex: department.PageIndex,
                    _pageSize: department.PageSize
                    )).ToListActionResult<Core.Model.Department>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Department>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetDepartmentAsync(
                        _id: id
                    )).ToActionResult<Core.Model.Department>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}