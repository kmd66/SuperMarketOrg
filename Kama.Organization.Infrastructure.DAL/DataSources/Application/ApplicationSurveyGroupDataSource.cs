using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyGroupDataSource : DataSource, Core.DataSource.IApplicationSurveyGroupDataSource
    {
        public ApplicationSurveyGroupDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }
        
        private async Task<AppCore.Result<Core.Model.ApplicationSurveyGroup>> ModifyAsync(bool isNewRecord, Core.Model.ApplicationSurveyGroup model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyApplicationSurveyGroupAsync(
                    _isNewRecord: isNewRecord
                    , _id: model.ID
                    , _applicationSurveyID: model.ApplicationSurveyID
                    , _name: model.Name
                    , _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyGroup>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyGroup>> CreateAsync(Core.Model.ApplicationSurveyGroup model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyGroup>> UpdateAsync(Core.Model.ApplicationSurveyGroup model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyGroup>>> ListAsync(Core.Model.ApplicationSurveyGroupListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyGroupsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _applicationSurveyID: model.ApplicationSurveyID,
                    _name: model.Name,
                    _showRemov: model.ShowRemov,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.ApplicationSurveyGroup>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurveyGroup>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyGroupAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurveyGroup>();

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
                var result = (await _dbAPP.DeleteApplicationSurveyGroupAsync(
                    _id: id,
                    _currentPositionID: _requestInfo.PositionId,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyGroup>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

