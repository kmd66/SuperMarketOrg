using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPlaceDataSource : IDataSource
    {
        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Place>> CreateAsync(Model.Place model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Place>> UpdateAsync(Model.Place model, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Place>>> ListAsync(Model.PlaceListVM place);

        Task<AppCore.Result<Model.Place>> GetAsync(Guid id);
    }
}