using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IRoleDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Role>> CreateAsync(Model.Role role, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Role>> UpdateAsync(Model.Role role, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Role>>> ListAsync(Model.RoleListVM model);

        Task<AppCore.Result<Model.Role>> GetAsync(Guid id);

    }
}