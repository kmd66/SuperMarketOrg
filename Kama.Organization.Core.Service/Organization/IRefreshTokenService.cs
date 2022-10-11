using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IRefreshTokenService : IService
    {
        Task<AppCore.Result<Model.RefreshToken>> AddAsync(Model.RefreshToken model);

        Task<AppCore.Result<@Model.RefreshToken>> EditAsync(@Model.RefreshToken model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.RefreshToken>> GetAsync(Guid id);

    }
}