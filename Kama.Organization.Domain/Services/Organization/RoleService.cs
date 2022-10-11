using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    internal class RoleService : Service<Core.DataSource.IRoleDataSource>, Core.Service.IRoleService
    {
        public RoleService(
            AppCore.IOC.IContainer container,
            ICommandDataSource commandDataSource
            )
            : base(container)
        {
            _commandDataSource = commandDataSource;
        }

        readonly ICommandDataSource _commandDataSource;

        public async Task<AppCore.Result<Core.Model.Role>> AddAsync(Core.Model.Role model)
        {
            model.ID = Guid.NewGuid();
            var result = await _dataSource.CreateAsync(model, null);
            if (!result.Success)
                return result;

            return await this.GetAsync(model.ID);
        }

        public async Task<AppCore.Result<Core.Model.Role>> EditAsync(Core.Model.Role model)
        {
            var result = await _dataSource.UpdateAsync(model, null);
            if (!result.Success)
                return result;

            return await this.GetAsync(model.ID);
        }

        public Task<AppCore.Result> DeleteAsync(Core.Model.Role model)
        {
            return _dataSource.DeleteAsync(model.ID, null);
        }

        public async Task<AppCore.Result<Core.Model.Role>> GetAsync(Guid id)
        {
            var async = new
            {
                getAsync = _dataSource.GetAsync(id),
                permissionAsync = _commandDataSource.ListAsync(new CommandListVM { RoleID = id})
            };

            var getResult = await async.getAsync;
            if (!getResult.Success)
                return getResult;

            var permissionResult = await async.permissionAsync;
            if (!permissionResult.Success)
                return Result<Role>.Failure(message: permissionResult.Message);

            getResult.Data.Permissions = permissionResult.Data.ToList();
            return getResult;
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.Role>>> ListAsync(Core.Model.RoleListVM model)
            => _dataSource.ListAsync(model);

    }
}