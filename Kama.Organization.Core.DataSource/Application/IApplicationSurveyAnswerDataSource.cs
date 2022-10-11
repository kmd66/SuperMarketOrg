using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyAnswerDataSource : IDataSource
    {
        Task<AppCore.Result> ModifyAsync(Core.Model.InsertSurveyAnswer model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyAnswer>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyAnswer>>> ListAsync(Model.ApplicationSurveyAnswerListVM model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyAnswer>>> GroupByAsync(Model.ApplicationSurveyAnswerListVM model);
    }
}
