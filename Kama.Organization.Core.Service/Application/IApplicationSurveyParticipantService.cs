using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyParticipantService : IService
    {
        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> AddAsync(Model.ApplicationSurveyParticipant model);

        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> EditAsync(Model.ApplicationSurveyParticipant model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyParticipant>>> ListAsync(Model.ApplicationSurveyParticipantListVM model);
        
        Task<AppCore.Result<Model.ApplicationSurveyParticipant>> GetAsync(Guid Id);

    }
}