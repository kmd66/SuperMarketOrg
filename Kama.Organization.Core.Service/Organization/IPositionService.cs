using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IPositionService : IService
    {
        Task<AppCore.Result<Model.Position>> AddAsync(Model.Position model);

        Task<AppCore.Result<Model.Position>> EditAsync(Model.Position model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result> SetDefaultAsync(Guid positionId);

        Task<AppCore.Result> RemoveUserAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Position<T>>>> ListAsync<T>(Model.PositionListVM model);

        Task<AppCore.Result<IEnumerable<Model.Position<T>>>> ListCurrentUserPositionsAsync<T>();

        Task<AppCore.Result<IEnumerable<Model.Position<T>>>> ListInAllApplicationsAsync<T>(Core.Model.PositionListVM model);

        Task<AppCore.Result<Model.Position>> GetAsync(Guid id);

        Task<AppCore.Result<Core.Model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCountAsync();

        Task<AppCore.Result<Core.Model.Position<Core.Model.PositionType>>> GetDefaultPosition(Guid applicationId, Guid userId);

        Task<AppCore.Result<IEnumerable<object>>> GetPermissionsAsync(Guid positionId);

        Task<AppCore.Result<byte[]>> ListExcelAsync<T>(Core.Model.PositionListVM model);

        Task<AppCore.Result<byte[]>> ListExcelWithRolesAsync<T>(Core.Model.PositionListVM model);

        Task<AppCore.Result<bool>> CheckPermission(Guid commandId);

    }

}