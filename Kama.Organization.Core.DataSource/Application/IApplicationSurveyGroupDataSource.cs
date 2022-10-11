using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyGroupDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ApplicationSurveyGroup>> CreateAsync(Model.ApplicationSurveyGroup model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyGroup>> UpdateAsync(Model.ApplicationSurveyGroup model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyGroup>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyGroup>>> ListAsync(Model.ApplicationSurveyGroupListVM model);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
