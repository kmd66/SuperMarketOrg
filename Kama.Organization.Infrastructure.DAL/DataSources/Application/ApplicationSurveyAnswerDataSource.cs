using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;
using System.Data.SqlClient;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class ApplicationSurveyAnswerDataSource : DataSource, Core.DataSource.IApplicationSurveyAnswerDataSource
    {
        public ApplicationSurveyAnswerDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result> ModifyAsync(Core.Model.InsertSurveyAnswer model, AppCore.IActivityLog log)
        {
            try
            {
                var commands = new List<SqlCommand>();

                foreach (var item in model.SurveyAnswer)
                {
                    var isNewRecord = true;
                    if (item.ID == Guid.Empty) { 
                        isNewRecord = true;
                        item.ID = Guid.NewGuid();
                    }
                    else  isNewRecord = false;

                    commands.Add(_dbAPP.GetCommand_ModifyApplicationSurveyAnswer(
                        _isNewRecord: isNewRecord
                        , _userID: _requestInfo.UserId
                        , _id: item.ID
                        , _type:(byte)item.Type
                        , _questionID: item.QuestionID
                        , _log: log?.Value
                    ));
                }

                await _dbAPP.BatchExcuteAsync(commands.ToArray());

                return AppCore.Result.Successful();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyAnswer>>> ListAsync(Core.Model.ApplicationSurveyAnswerListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyAnswersAsync(
                    _date: DateTime.Now.AddMonths(-1),
                    _userID: _requestInfo.UserId,
                    _pageIndex: 0,
                    _pageSize: 0
                    )).ToListActionResult<Core.Model.ApplicationSurveyAnswer>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyAnswer>>> GroupByAsync(Core.Model.ApplicationSurveyAnswerListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyGroupByListAsync()).ToListActionResult<Core.Model.ApplicationSurveyAnswer>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.ApplicationSurveyAnswer>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetApplicationSurveyAnswerAsync(_id: Id)).ToActionResult<Core.Model.ApplicationSurveyAnswer>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

