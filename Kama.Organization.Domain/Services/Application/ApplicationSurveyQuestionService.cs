using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyQuestionService : Service<Core.DataSource.IApplicationSurveyQuestionDataSource>, Core.Service.IApplicationSurveyQuestionService
    {
        public ApplicationSurveyQuestionService(AppCore.IOC.IContainer container,
            IApplicationSurveyGroupDataSource surveyGroupDataSource,
            IApplicationSurveyAnswerDataSource applicationSurveyAnswerDataSource,
            IApplicationSurveyQuestionChoiceDataSource surveyQuestionChoiceDataSource)
            : base(container)
        {
            _surveyGroupDataSource = surveyGroupDataSource;
            _surveyQuestionChoiceDataSource = surveyQuestionChoiceDataSource;
            _applicationSurveyAnswerDataSource = applicationSurveyAnswerDataSource;
        }

        readonly IApplicationSurveyGroupDataSource _surveyGroupDataSource;
        readonly IApplicationSurveyQuestionChoiceDataSource _surveyQuestionChoiceDataSource;
        readonly IApplicationSurveyAnswerDataSource _applicationSurveyAnswerDataSource;

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> AddAsync(Core.Model.ApplicationSurveyQuestion model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> EditAsync(Core.Model.ApplicationSurveyQuestion model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>> ListAsync(Core.Model.ApplicationSurveyQuestionListVM model)
            => _dataSource.ListAsync(model);

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>> ListQuestionAndChoiceAsync(Core.Model.ApplicationSurveyQuestionListVM model)
        {

            //var listResult = await _dataSource.ListAsync(model);
            //if (!listResult.Success)
            //    return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>.Failure(message: listResult.Message);
            //var list = listResult.Data.ToList();

            //if (list.Count < 1)
            //    return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>.Successful(data: listResult.Data);

            //var questionChoice = new ApplicationSurveyQuestionChoiceListVM { QuestionIDs = new List<Guid>() };
            //foreach (var question in list)
            //    questionChoice.QuestionIDs.Add(question.ID);

            //var questionChoiceResult = await _surveyQuestionChoiceDataSource.ListAsync(questionChoice);
            //if (!questionChoiceResult.Success)
            //    return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>.Failure(message: questionChoiceResult.Message);

            //foreach (var question in listResult.Data)
            //{
            //    question.Choice = new List<ApplicationSurveyQuestionChoice>();
            //    question.Choice.AddRange(questionChoiceResult.Data.Where(x => x.QuestionID == question.ID).ToList());
            //}

            //return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>.Successful(data: listResult.Data);
            return null;
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>> ReportQuestionAsync(Core.Model.ApplicationSurveyQuestionListVM model)
        {
            return null;
            //var questions = (await ListQuestionAndChoiceAsync(model)).Data.ToList();

            //var answers = (await _applicationSurveyAnswerDataSource.ListAsync(new ApplicationSurveyAnswerListVM { })).Data.ToList();

            //foreach (var question in questions)
            //{
            //    question.Answers = answers.Where(a => a.QuestionID == question.ID).ToList();

            //    foreach (var answer in question.Answers)
            //        answer.Percent = (answer.Count*100) / question.Answers.Sum(a => a.Count);

            //}
            //return AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestion>>.Successful(data: questions);
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestion>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);
    }
}
