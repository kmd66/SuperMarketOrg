using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IApplicationSurveyAnswerService : IService
    {
        Task<AppCore.Result> ModifyAsync(Core.Model.InsertSurveyAnswer model);

        Task<AppCore.Result<IEnumerable<Model.ApplicationSurveyAnswer>>> ListAsync(Model.ApplicationSurveyAnswerListVM model);
        
        Task<AppCore.Result<Model.ApplicationSurveyAnswer>> GetAsync(Guid Id);


    }
}