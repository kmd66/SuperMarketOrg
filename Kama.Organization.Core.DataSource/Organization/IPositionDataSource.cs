using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPositionDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Position>> CreateAsync(Model.Position position, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Position>> UpdateAsync(Model.Position position, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> SetDefaultAsync(Guid positionId, AppCore.IActivityLog log);

        Task<AppCore.Result> RemoveUserAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Position<T>>>> ListAsync<T>(Guid? applicationId, Model.PositionListVM model);

        Task<AppCore.Result<IEnumerable<Model.Position<T>>>> ListWithRolesAsync<T>(Model.PositionListVM model);

        Task<AppCore.Result<Model.Position>> GetAsync(Guid id);

        Task<AppCore.Result<Model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCountAsync();

        Task<AppCore.Result<IEnumerable<@Model.Command>>> GetPermissionsAsync(Guid positionId, Guid? commandId);
    }
}