using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class RefreshTokenDataSource : DataSource, Core.DataSource.IRefreshTokenDataSource
    {
        public RefreshTokenDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        protected async Task<AppCore.Result<@Model.RefreshToken>> ModifyAsync(bool isNewRecord, Core.Model.RefreshToken model)
        {
            try
            {
                var result = (await _dbORG.ModifyRefreshTokenAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _userID: model.UserID,
                    _expireDate: model.ExpireDate,
                    _issuedDate: model.IssuedDate,
                    _protectedTicket: model.ProtectedTicket
                    )).ToActionResult<@Model.RefreshToken>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Task<AppCore.Result<@Model.RefreshToken>> CreateAsync(Core.Model.RefreshToken model)
            => ModifyAsync(true, model);

        public Task<AppCore.Result<@Model.RefreshToken>> UpdateAsync(Core.Model.RefreshToken model)
            => ModifyAsync(false, model);

        public async Task<AppCore.Result> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbORG.DeleteRefreshTokenAsync(
                    _id: id
                );

                return result.ToActionResult();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<@Model.RefreshToken>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetRefreshTokenAsync(
                    _id: id
                    )).ToActionResult<@Model.RefreshToken>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}