using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyQuestionChoiceService : IService
    {
        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> AddAsync(Model.ApplicationSurveyQuestionChoice model);

        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> EditAsync(Model.ApplicationSurveyQuestionChoice model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestionChoice>>> ListAsync(Model.ApplicationSurveyQuestionChoiceListVM model);
        
        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}