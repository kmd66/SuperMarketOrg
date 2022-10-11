using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IPlaceService : IService
    {
        Task<AppCore.Result<Model.Place>> AddAsync(Model.Place model);

        Task<AppCore.Result<Model.Place>> EditAsync(Model.Place model);

        Task<AppCore.Result> DeleteAsync(Model.Place model);

        Task<AppCore.Result<IEnumerable<Model.Place>>> ListAsync(Model.PlaceListVM model);

        Task<AppCore.Result<Core.Model.Place>> GetAsync(Guid id);

    }
}