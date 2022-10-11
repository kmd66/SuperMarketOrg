using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    internal class DynamicPermissionService : Service<Core.DataSource.IDynamicPermissionDataSource>, Core.Service.IDynamicPermissionService
    {
        public DynamicPermissionService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Core.Model.DynamicPermission>> AddAsync(Core.Model.DynamicPermission model)
        {
            var validationResult = await _ValidateForSaveAsync(model);
            if (!validationResult.Success)
                return Result<DynamicPermission>.Failure(message: validationResult.Message);

            model.ID = Guid.NewGuid();
            return await _dataSource.CreateAsync(model);
        }

        public async Task<AppCore.Result<Core.Model.DynamicPermission>> EditAsync(Core.Model.DynamicPermission model)
        {
            var validationResult = await _ValidateForSaveAsync(model);
            if (!validationResult.Success)
                return Result<DynamicPermission>.Failure(message: validationResult.Message);

            return await _dataSource.UpdateAsync(model);
        }

        public Task<AppCore.Result> DeleteAsync(Core.Model.DynamicPermission model)
            => _dataSource.DeleteAsync(model.ID);

        public Task<AppCore.Result<Core.Model.DynamicPermission>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<Core.Model.DynamicPermission>>> ListAsync(Core.Model.DynamicPermissionListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<IEnumerable<Core.Model.Position>>> ListPositionsAsync(Core.Model.DynamicPermissionListPositionsVM model)
            => _dataSource.ListPositionsAsync(model);

        public Task<AppCore.Result<IEnumerable<Core.Model.Model>>> ListObjectsByPositionAsync(Guid positionId)
            => _dataSource.ListObjectsByPositionAsync(positionId);

        private async Task<AppCore.Result> _ValidateForSaveAsync(DynamicPermission model)
        {
            return AppCore.Result.Successful();
        }
    }
}