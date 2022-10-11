using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.AppCore;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Core.Service
{
    public interface IClientService : IService
    {
        
        Task<AppCore.Result<Model.Client>> GetAsync(Guid id);

        Task<AppCore.Result<Model.Client>> AddAsync(Model.Client model);

        Task<AppCore.Result<Model.Client>> EditAsync(Model.Client model);

        Task<AppCore.Result<IEnumerable<Model.Client>>> ListAsync(Guid applicationId);

        Task<Result<IEnumerable<Client>>> ListAsync(ClientListVM model);

        Task<Result> DeleteAsync(Guid id);
    }
}