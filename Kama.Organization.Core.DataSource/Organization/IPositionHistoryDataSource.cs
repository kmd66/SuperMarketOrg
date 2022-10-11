using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPositionHistoryDataSource : IDataSource
    {
        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.PositionHistory>> CreateAsync(Model.PositionHistory model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.PositionHistory>> UpdateAsync(Model.PositionHistory model, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.PositionHistory>>> ListAsync(Model.PositionHistoryListVM place);

        Task<AppCore.Result<Model.PositionHistory>> GetAsync(Guid id);
    }
}