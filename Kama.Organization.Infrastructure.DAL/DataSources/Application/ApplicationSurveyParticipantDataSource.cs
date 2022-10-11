using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyParticipantDataSource : DataSource, Core.DataSource.IApplicationSurveyParticipantDataSource
    {
        public ApplicationSurveyParticipantDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> ModifyAsync(bool isNewRecord, Core.Model.ApplicationSurveyParticipant model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyApplicationSurveyParticipantAsync(
                    _isNewRecord: isNewRecord
                    , _id: model.ID
                    , _surveyID: model.SurveyID
                    , _userID : model.UserID
                    , _log: log?.Value
                    )).ToActionResult<Core.Model.ApplicationSurveyParticipant>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> CreateAsync(Core.Model.ApplicationSurveyParticipant model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> UpdateAsync(Core.Model.ApplicationSurveyParticipant model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyParticipant>>> ListAsync(Core.Model.ApplicationSurveyParticipantListVM model)
        {
            //try
            //{
            //    var result = (await _dbAPP.GetApplicationSurveyParticipantsAsync(
            //        _surveyID : model.SurveyID,
            //        _userID : model.UserID,
            //        _pageIndex: model.PageIndex,
            //        _pageSize: model.PageSize,
            //        _sortExp: model.SortExp.ToSortExpString()
            //        )).ToListActionResult<Core.Model.ApplicationSurveyParticipant>();

            //    return result;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
            return null;
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> GetAsync(Guid Id)
        {
            //try
            //{
            //    var result = (await _dbAPP.GetApplicationSurveyParticipantAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurveyParticipant>();

            //    return result;
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
            return null;
        }
    }
}

