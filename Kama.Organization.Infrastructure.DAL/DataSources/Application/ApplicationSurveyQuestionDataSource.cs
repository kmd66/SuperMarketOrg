using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyQuestionDataSource : DataSource, Core.DataSource.IApplicationSurveyQuestionDataSource
    {
        public ApplicationSurveyQuestionDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }
        
        private async Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> ModifyAsync(bool isNewRecord, Core.Model.ApplicationSurveyQuestion model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyApplicationSurveyQuestionAsync(
                    _isNewRecord: isNewRecord
                    , _id: model.ID
                    , _groupID: model.GroupID
                    , _name: model.Name
                    , _type: (byte)model.Type
                    , _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyQuestion>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> CreateAsync(Core.Model.ApplicationSurveyQuestion model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> UpdateAsync(Core.Model.ApplicationSurveyQuestion model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>> ListAsync(Core.Model.ApplicationSurveyQuestionListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyQuestionsAsync(
                    _groupID: model.GroupID,
                    _groupIDs: _objSerializer.Serialize(model.GroupIDs),
                    _name: model.Name,
                    _type: (byte)model.Type,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.ApplicationSurveyQuestion>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyQuestionAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurveyQuestion>();

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
                var result = (await _dbAPP.DeleteApplicationSurveyQuestionAsync(
                    _id: id,
                    _currentPositionID: _requestInfo.PositionId,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyQuestion>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

