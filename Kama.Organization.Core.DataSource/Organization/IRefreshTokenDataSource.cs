using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IRefreshTokenDataSource : IDataSource
    {
        Task<AppCore.Result<Model.RefreshToken>> CreateAsync(Model.RefreshToken model);

        Task<AppCore.Result<Model.RefreshToken>> UpdateAsync(Model.RefreshToken model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.RefreshToken>> GetAsync(Guid id);
    }
}