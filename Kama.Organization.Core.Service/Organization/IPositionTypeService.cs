using Kama.AppCore;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IPositionTypeService : IService
    {
        Task<AppCore.Result<PositionTypeModel>> AddAsync(PositionTypeModel model);

        Task<AppCore.Result<PositionTypeModel>> EditAsync(PositionTypeModel model);

        Task<Result> SetRolesAsync(PositionTypeModel model);

        Task<Result<IEnumerable<PositionTypeModel>>> ListAsync();

        Task<Result<PositionTypeModel>> GetAsync(Guid id);

        Task<Result<IEnumerable<Role>>> GetRolesAsync(PositionType positionType);

    }
}