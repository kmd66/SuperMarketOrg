using Kama.AppCore;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPositionTypeDataSource : IDataSource
    {
        Task<AppCore.Result<PositionTypeModel>> CreateAsync(PositionTypeModel model, AppCore.IActivityLog log);

        Task<AppCore.Result<PositionTypeModel>> UpdateAsync(PositionTypeModel model, AppCore.IActivityLog log);

        Task<Result> SetRolesAsync(PositionTypeModel model, IActivityLog log);

        Task<Result<IEnumerable<PositionTypeModel>>> ListAsync();

        Task<Result<PositionTypeModel>> GetAsync(Guid id);

        Task<Result<IEnumerable<Role>>> GetRolesAsync(PositionType positionType);
    }
}
