using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IDepartmentService : IService
    {
        Task<AppCore.Result<Model.Department>> AddAsync(Model.Department model);

        Task<AppCore.Result<Model.Department>> EditAsync(Model.Department model);

        Task<AppCore.Result> DeleteAsync(Model.Department model);

        Task<AppCore.Result<IEnumerable<Model.Department>>> ListAsync(Model.DepartmentListVM department);

        Task<AppCore.Result<Core.Model.Department>> GetAsync(Guid id);
    }
}