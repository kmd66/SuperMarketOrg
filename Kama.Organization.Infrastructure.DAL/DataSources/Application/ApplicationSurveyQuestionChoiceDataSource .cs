using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyQuestionChoiceDataSource : DataSource, Core.DataSource.IApplicationSurveyQuestionChoiceDataSource
    {
        public ApplicationSurveyQuestionChoiceDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> ModifyAsync(bool isNewRecord, Core.Model.ApplicationSurveyQuestionChoice model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyApplicationSurveyQuestionChoiceAsync(
                    _isNewRecord: isNewRecord
                    , _id: model.ID
                    , _questionID : model.QuestionID
                    , _name: model.Name
                    , _enable: model.Enable
                    , _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyQuestionChoice>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> CreateAsync(Core.Model.ApplicationSurveyQuestionChoice model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> UpdateAsync(Core.Model.ApplicationSurveyQuestionChoice model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestionChoice>>> ListAsync(Core.Model.ApplicationSurveyQuestionChoiceListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyQuestionChoicesAsync(
                    _questionID:model.QuestionID,
                    _questionIDs: _objSerializer.Serialize(model.QuestionIDs),
                    _name: model.Name,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.ApplicationSurveyQuestionChoice>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyQuestionChoiceAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurveyQuestionChoice>();

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
                var result = (await _dbAPP.DeleteApplicationSurveyQuestionChoiceAsync(
                    _id: id,
                    _currentPositionID: _requestInfo.PositionId,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyQuestionChoice>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

