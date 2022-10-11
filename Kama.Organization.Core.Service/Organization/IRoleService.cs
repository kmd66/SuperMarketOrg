using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IRoleService : IService
    {
        Task<AppCore.Result<Model.Role>> AddAsync(Model.Role model);

        Task<AppCore.Result<Model.Role>> EditAsync(Model.Role model);

        Task<AppCore.Result> DeleteAsync(Model.Role model);

        Task<AppCore.Result<IEnumerable<Model.Role>>> ListAsync(Model.RoleListVM model);

        Task<AppCore.Result<Model.Role>> GetAsync(Guid id);

    }
}