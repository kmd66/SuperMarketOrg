using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyGroupService : Service<Core.DataSource.IApplicationSurveyGroupDataSource>, Core.Service.IApplicationSurveyGroupService
    {
        public ApplicationSurveyGroupService(AppCore.IOC.IContainer container,
            IApplicationSurveyAnswerDataSource applicationSurveyAnswerDataSource,
            IApplicationSurveyQuestionDataSource surveyQuestionDataSource)
            : base(container)
        {
            _applicationSurveyAnswerDataSource = applicationSurveyAnswerDataSource;
            _surveyQuestionDataSource = surveyQuestionDataSource;
        }
        readonly IApplicationSurveyAnswerDataSource _applicationSurveyAnswerDataSource;

        readonly IApplicationSurveyQuestionDataSource _surveyQuestionDataSource;

        public Task<AppCore.Result<ApplicationSurveyGroup>> AddAsync(ApplicationSurveyGroup model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<ApplicationSurveyGroup>> EditAsync(ApplicationSurveyGroup model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<ApplicationSurveyGroup>>> ListAsync(ApplicationSurveyGroupListVM model)
            => _dataSource.ListAsync(model);

        public async Task<AppCore.Result<IEnumerable<ApplicationSurveyGroup>>> ListGroupAndQuestionAsync(ApplicationSurveyGroupListVM model)
        {
            var listGropResult = await ListAsync(new ApplicationSurveyGroupListVM());
            if (!listGropResult.Success)
                return AppCore.Result<IEnumerable<ApplicationSurveyGroup>>.Failure(message: listGropResult.Message);
            var listGrop = listGropResult.Data.ToList();

            if (listGrop.Count < 1)
                return AppCore.Result<IEnumerable<ApplicationSurveyGroup>>.Failure(message: "گروه یافت نشد");

            var modelQuestion = new ApplicationSurveyQuestionListVM { GroupIDs = new List<Guid>() };
            foreach (var qrop in listGrop)
                modelQuestion.GroupIDs.Add(qrop.ID);

            var questionsResult = await _surveyQuestionDataSource.ListAsync(modelQuestion);
            if (!questionsResult.Success)
                return AppCore.Result<IEnumerable<ApplicationSurveyGroup>>.Failure(message: questionsResult.Message);

            foreach (var qrop in listGropResult.Data)
            {
                qrop.Questions = new List<ApplicationSurveyQuestion>();
                qrop.Questions.AddRange(questionsResult.Data.Where(x => x.GroupID == qrop.ID).ToList());
            }

            return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyGroup>>.Successful(data: listGropResult.Data);

        }

        public async Task<AppCore.Result<IEnumerable<ApplicationSurveyGroup>>> ReportGroupAsync(ApplicationSurveyGroupListVM model)
        {
            var groups = (await ListGroupAndQuestionAsync(model)).Data.ToList();

            var answers = (await _applicationSurveyAnswerDataSource.GroupByAsync(new ApplicationSurveyAnswerListVM { })).Data.ToList();

            foreach (var group in groups)
            {
                foreach (var question in group.Questions)
                {
                    question.Answers = answers.Where(a => a.QuestionID == question.ID).ToList();

                    foreach (var answer in question.Answers)
                        answer.Percent = (answer.Count * 100) / question.Answers.Sum(a => a.Count);
                }
            }

            return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyGroup>>.Successful(data: groups);

        }

        public async Task<AppCore.Result<ApplicationSurveyGroup>> GetAsync(Guid Id)
        {
            var listGropResult = await  _dataSource.GetAsync(Id); ;
            if (!listGropResult.Success)
                return AppCore.Result<ApplicationSurveyGroup>.Failure(message: listGropResult.Message);

            var questionsResult = await _surveyQuestionDataSource.ListAsync(new ApplicationSurveyQuestionListVM { GroupID = listGropResult.Data.ID });
            if (!questionsResult.Success)
                return AppCore.Result<ApplicationSurveyGroup>.Failure(message: questionsResult.Message);

            listGropResult.Data.Questions = new List<ApplicationSurveyQuestion>();
            listGropResult.Data.Questions.AddRange(questionsResult.Data.Where(x => x.GroupID == listGropResult.Data.ID).ToList());

            return AppCore.Result<Core.Model.ApplicationSurveyGroup>.Successful(data: listGropResult.Data);
        }

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);
    }
}
