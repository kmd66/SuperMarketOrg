using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IPositionHistoryService : IService
    {
        Task<AppCore.Result<Model.PositionHistory>> AddAsync(Model.PositionHistory model);

        Task<AppCore.Result<Model.PositionHistory>> EditAsync(Model.PositionHistory model);

        Task<AppCore.Result> DeleteAsync(Model.PositionHistory model);

        Task<AppCore.Result<IEnumerable<Model.PositionHistory>>> ListAsync(Model.PositionHistoryListVM model);

        Task<AppCore.Result<Core.Model.PositionHistory>> GetAsync(Guid id);
    }
}