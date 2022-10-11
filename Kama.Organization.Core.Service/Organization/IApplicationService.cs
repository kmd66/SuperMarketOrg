using Kama.AppCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationService : IService
    {
        Task<AppCore.Result<Model.Application>> AddAsync(Model.Application model);

        Task<AppCore.Result<Model.Application>> EditAsync(Model.Application model);

        Task<AppCore.Result<IEnumerable<Model.Application>>> ListAsync(Model.ApplicationListVM model);

        Task<AppCore.Result<Model.Application>> GetAsync(Guid id);

        Task<Result> DeleteAsync(Guid id);

    }
}