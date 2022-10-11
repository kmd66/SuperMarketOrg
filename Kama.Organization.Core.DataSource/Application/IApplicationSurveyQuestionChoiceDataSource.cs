using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyQuestionChoiceDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> CreateAsync(Model.ApplicationSurveyQuestionChoice model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> UpdateAsync(Model.ApplicationSurveyQuestionChoice model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyQuestionChoice>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestionChoice>>> ListAsync(Model.ApplicationSurveyQuestionChoiceListVM model);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
