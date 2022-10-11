using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyQuestionDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> CreateAsync(Model.ApplicationSurveyQuestion model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> UpdateAsync(Model.ApplicationSurveyQuestion model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyQuestion>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyQuestion>>> ListAsync(Model.ApplicationSurveyQuestionListVM model);
        
        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
