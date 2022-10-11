using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using model = Core.Model;

    class ApplicationDataSource : DataSource, Core.DataSource.IApplicationDataSource
    {
        public ApplicationDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<model.Application>> ModifyAsync(bool isNewRecord, model.Application model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyApplicationAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _code: model.Code,
                    _name: model.Name,
                    _enabled: model.Enabled,
                    _comment: model.Comment,
                    _log: log?.Value
                    )).ToActionResult<model.Application>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<model.Application>> CreateAsync(model.Application application, AppCore.IActivityLog log)
            => ModifyAsync(true, application, log);

        public Task<AppCore.Result<model.Application>> UpdateAsync(model.Application application, AppCore.IActivityLog log)
            => ModifyAsync(false, application, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeleteApplicationAsync(
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

        public async Task<AppCore.Result<IEnumerable<model.Application>>> ListAsync(Core.Model.ApplicationListVM model)
        {
            try
            {
                var result = (await _dbORG.GetApplicationsAsync(
                    _name: model.Name
                    )).ToListActionResult<model.Application>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.Application>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetApplicationAsync(
                    _id: id
                    )).ToActionResult<model.Application>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}

