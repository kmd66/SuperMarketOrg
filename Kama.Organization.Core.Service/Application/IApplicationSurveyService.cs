using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyService : IService
    {
        Task<AppCore.Result<Model.ApplicationSurvey>> AddAsync(Model.ApplicationSurvey model);

        Task<AppCore.Result<Model.ApplicationSurvey>> EditAsync(Model.ApplicationSurvey model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurvey>>> ListAsync(Model.ApplicationSurveyListVM model);
        
        Task<AppCore.Result<Model.ApplicationSurvey>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}