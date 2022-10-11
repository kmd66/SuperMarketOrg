using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IApplicationSurveyParticipantDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> CreateAsync(Model.ApplicationSurveyParticipant model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> UpdateAsync(Model.ApplicationSurveyParticipant model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyParticipant>>> ListAsync(Model.ApplicationSurveyParticipantListVM model);
    }
}
