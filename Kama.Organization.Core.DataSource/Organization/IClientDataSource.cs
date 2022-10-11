using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Core.DataSource
{
    public interface IClientDataSource : IDataSource
    {
        Task<AppCore.Result<IEnumerable<Model.Client>>> ListAsync(Guid applicationId);
        Task<AppCore.Result<Model.Client>> CreateAsync(Model.Client client, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Client>> UpdateAsync(Model.Client client, AppCore.IActivityLog log);
        Task<AppCore.Result<Model.Client>> GetAsync(Guid id);
        Task<Result<IEnumerable<Client>>> ListAsync(ClientListVM model);
        Task<Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}