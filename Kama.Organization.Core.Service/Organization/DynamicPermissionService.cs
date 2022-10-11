using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service.Organization
{
    public interface IDynamicPermissionService : IService
    {
        Task<AppCore.Result<DynamicPermission>> AddAsync(DynamicPermission model);

        Task<AppCore.Result<DynamicPermission>> EditAsync(DynamicPermission model);

        Task<AppCore.Result> DeleteAsync(DynamicPermission model);

        Task<AppCore.Result<IEnumerable<DynamicPermission>>> ListAsync(DynamicPermissionListVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.Position>>> ListPositionsAsync(DynamicPermissionListPositionsVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.Model>>> ListObjectsByPositionAsync();

        Task<AppCore.Result<DynamicPermission>> GetAsync(Guid id);

    }
}
