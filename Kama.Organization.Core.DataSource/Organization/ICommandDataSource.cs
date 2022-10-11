using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface ICommandDataSource: IDataSource
    {
        Task<AppCore.Result<Model.Command>> CreateAsync(Model.Command position, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Command>> UpdateAsync(Model.Command position, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Command>>> ListAsync(Core.Model.CommandListVM model);

        Task<AppCore.Result<Model.Command>> GetAsync(Guid id);
    }
}
