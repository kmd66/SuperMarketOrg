using Kama.AppCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Application>> CreateAsync(Model.Application application, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Application>> UpdateAsync(Model.Application application, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Core.Model.Application>>> ListAsync(Core.Model.ApplicationListVM model);

        Task<AppCore.Result<Core.Model.Application>> GetAsync(Guid id);

        Task<Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
