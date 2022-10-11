using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyGroupService : IService
    {
        Task<AppCore.Result<Model.ApplicationSurveyGroup>> AddAsync(Model.ApplicationSurveyGroup model);

        Task<AppCore.Result<Model.ApplicationSurveyGroup>> EditAsync(Model.ApplicationSurveyGroup model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyGroup>>> ListAsync(Model.ApplicationSurveyGroupListVM model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyGroup>>> ListGroupAndQuestionAsync(Model.ApplicationSurveyGroupListVM model);
       
        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyGroup>>> ReportGroupAsync(Model.ApplicationSurveyGroupListVM model);
        
        Task<AppCore.Result<Model.ApplicationSurveyGroup>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}