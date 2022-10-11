using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyQuestionService : IService
    {
        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> AddAsync(Model.ApplicationSurveyQuestion model);

        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> EditAsync(Model.ApplicationSurveyQuestion model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestion>>> ListAsync(Model.ApplicationSurveyQuestionListVM model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestion>>> ListQuestionAndChoiceAsync(Model.ApplicationSurveyQuestionListVM model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestion>>> ReportQuestionAsync(Model.ApplicationSurveyQuestionListVM model);

        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}