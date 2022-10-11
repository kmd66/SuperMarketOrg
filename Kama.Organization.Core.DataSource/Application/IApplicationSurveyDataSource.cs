using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ApplicationSurvey>> CreateAsync(Model.ApplicationSurvey faqGroup, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurvey>> UpdateAsync(Model.ApplicationSurvey faqGroup, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurvey>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurvey>>> ListAsync(Model.ApplicationSurveyListVM model);
        
        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
