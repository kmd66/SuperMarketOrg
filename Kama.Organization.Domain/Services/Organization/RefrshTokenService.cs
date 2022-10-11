using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    internal class RefreshTokenService : Service<Core.DataSource.IRefreshTokenDataSource>, Core.Service.IRefreshTokenService
    {
        public RefreshTokenService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<@Model.RefreshToken>> AddAsync(@Model.RefreshToken model)
            => _dataSource.CreateAsync(model);

        public Task<AppCore.Result<@Model.RefreshToken>> EditAsync(@Model.RefreshToken model)
            => _dataSource.UpdateAsync(model);

        public Task<AppCore.Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id);

        public Task<AppCore.Result<@Model.RefreshToken>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

    }
}