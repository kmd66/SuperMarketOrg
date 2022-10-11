using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using Kama.AppCore;
    using model = Core.Model;

    internal class ClientDataSource : DataSource, Core.DataSource.IClientDataSource
    {
        public ClientDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<model.Client>> ModifyAsync(bool isNewRecord, model.Client model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyClientAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID, 
                    _applicationID: model.ApplicationID,
                    _name: model.Name,
                    _secret: model.Secret,
                    _type: (byte)model.Type,
                    _enabled: model.Enabled,
                    _allowedOrigin: model.AllowedOrigin,
                    _refreshTokenLifeTime : model.RefreshTokenLifeTime,
                    _log: log?.Value
                    )).ToActionResult<model.Client>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<model.Client>> CreateAsync(model.Client client, AppCore.IActivityLog log)
            => ModifyAsync(true, client, log);

        public Task<AppCore.Result<model.Client>> UpdateAsync(model.Client client, AppCore.IActivityLog log)
            => ModifyAsync(false, client, log);

        public async Task<AppCore.Result<IEnumerable<model.Client>>> ListAsync( Guid id)
        {
            try
            {
                var result = (await _dbORG.GetClientsAsync(
                   _applicationID: id
                    )).ToListActionResult<model.Client>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeleteClientAsync(
                    _id: id,
                    _currentUserID: _requestInfo.UserId,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.Client>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetClientAsync(
                    _id: id
                    )).ToActionResult<model.Client>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<model.Client>>> ListAsync(model.ClientListVM model)
        {
            try
            {
                var result = (await _dbORG.GetClientsAsync(
                    _applicationID: model.ApplicationID

                    )).ToListActionResult<Core.Model.Client>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}