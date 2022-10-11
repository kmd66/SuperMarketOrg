using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource.Organization
{
    public interface IDynamicPermissionDataSource : IDataSource
    {
        Task<AppCore.Result<DynamicPermission>> CreateAsync(DynamicPermission DynamicPermission);

        Task<AppCore.Result<DynamicPermission>> UpdateAsync(DynamicPermission DynamicPermission);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<DynamicPermission>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<DynamicPermission>>> ListAsync(DynamicPermissionListVM model);

        Task<AppCore.Result<IEnumerable<Model.Position>>> ListPositionsAsync(DynamicPermissionListPositionsVM model);

        Task<AppCore.Result<IEnumerable<Model.Model>>> ListObjectsByPositionAsync();

    }
}
