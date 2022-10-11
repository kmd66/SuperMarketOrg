using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IDynamicPermissionDataSource : IDataSource
    {
        Task<AppCore.Result<Model.DynamicPermission>> CreateAsync(Model.DynamicPermission DynamicPermission);

        Task<AppCore.Result<Model.DynamicPermission>> UpdateAsync(Model.DynamicPermission DynamicPermission);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.DynamicPermission>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.DynamicPermission>>> ListAsync(Model.DynamicPermissionListVM model);

        Task<AppCore.Result<IEnumerable<Model.Position>>> ListPositionsAsync(Core.Model.DynamicPermissionListPositionsVM model);

        Task<AppCore.Result<IEnumerable<Model.Model>>> ListObjectsByPositionAsync(Guid positoinId);


    }
}