using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface ICommandService : IService
    {
        Task<AppCore.Result<Model.Command>> AddAsync(Model.Command model);

        Task<AppCore.Result<Model.Command>> EditAsync(Model.Command model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Command>>> ListAsync(Core.Model.CommandListVM model);

        Task<AppCore.Result<Model.Command>> GetAsync(Guid id);
    }
}