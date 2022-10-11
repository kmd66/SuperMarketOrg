using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IDynamicPermissionService : IService
    {
        Task<AppCore.Result<Model.DynamicPermission>> AddAsync(Model.DynamicPermission model);

        Task<AppCore.Result<Model.DynamicPermission>> EditAsync(Model.DynamicPermission model);

        Task<AppCore.Result> DeleteAsync(Model.DynamicPermission model);

        Task<AppCore.Result<IEnumerable<Model.DynamicPermission>>> ListAsync(Model.DynamicPermissionListVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.Position>>> ListPositionsAsync(Core.Model.DynamicPermissionListPositionsVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.Model>>> ListObjectsByPositionAsync(Guid positionId);

        Task<AppCore.Result<Model.DynamicPermission>> GetAsync(Guid id);

    }
}