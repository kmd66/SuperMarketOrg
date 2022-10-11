using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.Model;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class RoleDataSource : DataSource, Core.DataSource.IRoleDataSource
    {
        public RoleDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Role>> ModifyAsync(bool isNewRecord, Core.Model.Role model, AppCore.IActivityLog log)
        {
            try
            {
                var result = await _dbORG.ModifyRoleAsync(
                    _isNewRecord: isNewRecord, 
                    _id: model.ID, 
                    _applicationID: model.ApplicationID, 
                    _name: model.Name, 
                    _permissions: model.Permissions == null ? null : _objSerializer.Serialize(model.Permissions.Select(p => new { CommandID = p.ID })),
                    _log: log?.Value
                );

                if (result.DbSucceed())
                    return await GetAsync(model.ID);

                return result.ToActionResult<Core.Model.Role>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Role>> CreateAsync(Core.Model.Role Role, AppCore.IActivityLog log)
            => ModifyAsync(true, Role, log);

        public Task<AppCore.Result<Core.Model.Role>> UpdateAsync(Core.Model.Role Role, AppCore.IActivityLog log)
            => ModifyAsync(false, Role, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = await _dbORG.DeleteRoleAsync(id, log?.Value);

                return result.ToActionResult();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Role>>> ListAsync(Core.Model.RoleListVM model)
        {
            try
            {
                var result = (await _dbORG.GetRolesAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _name: model.Name,
                    _positionType: (byte)model.PositionType,
                    _positionID: model.PositionID,
                    _userID: model.UserID,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                )).ToListActionResult<Core.Model.Role>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Role>> GetAsync(Guid id)
        {
            try
            {
                var result = await _dbORG.GetRoleAsync(id);

                return result.ToActionResult<Core.Model.Role>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}