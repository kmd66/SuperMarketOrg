using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IDepartmentDataSource : IDataSource
    {
        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Department>> CreateAsync(Model.Department department, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Department>> UpdateAsync(Model.Department department, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Department>>> ListAsync(Model.DepartmentListVM department);

        Task<AppCore.Result<Core.Model.Department>> GetAsync(Guid id);
    }
}