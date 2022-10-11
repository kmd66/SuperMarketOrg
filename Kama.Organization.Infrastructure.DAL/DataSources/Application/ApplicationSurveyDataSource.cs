using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyDataSource : DataSource, Core.DataSource.IApplicationSurveyDataSource
    {
        public ApplicationSurveyDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.ApplicationSurvey>> ModifyAsync(bool isNewRecord, Core.Model.ApplicationSurvey model, AppCore.IActivityLog log)
        {
            return null;
            //try
            //{
            //    var result = (await _dbAPP.ModifyApplicationSurveyAsync(
            //        _isNewRecord: isNewRecord
            //        , _id: model.ID
            //        , _applicationID: _requestInfo.ApplicationId
            //        , _name: model.Name
            //        , _enable: model.Enable
            //        , _log: log?.Value
            //        )).ToActionResult<Core.Model.ApplicationSurvey>();

            //    if (result.Success)
            //        return await GetAsync(model.ID);

            //    return result;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurvey>> CreateAsync(Core.Model.ApplicationSurvey model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.ApplicationSurvey>> UpdateAsync(Core.Model.ApplicationSurvey model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurvey>>> ListAsync(Core.Model.ApplicationSurveyListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveysAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _name: model.Name,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.ApplicationSurvey>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurvey>> GetAsync(Guid Id)
        {

            return null;
            //try
            //{
            //    var result = (await _dbAPP.GetApplicationSurveyAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurvey>();

            //    return result;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            return null;
            //try
            //{
            //    var result = (await _dbAPP.DeleteApplicationSurveyAsync(
            //        _id: id,
            //        _currentPositionID: _requestInfo.PositionId,
            //        _log: log?.Value
            //        )).ToActionResult<Core.Model.ApplicationSurvey>();

            //    return result;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
        }
    }
}

