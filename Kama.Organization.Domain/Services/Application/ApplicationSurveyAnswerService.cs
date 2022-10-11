using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyAnswerService : Service<Core.DataSource.IApplicationSurveyAnswerDataSource>, Core.Service.IApplicationSurveyAnswerService
    {
        public ApplicationSurveyAnswerService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result> ModifyAsync(Core.Model.InsertSurveyAnswer model)
        {
            if(model.SurveyAnswer == null || model.SurveyAnswer.Count < 1)
                return AppCore.Result.Failure(message: "");

            return await _dataSource.ModifyAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyAnswer>>> ListAsync(Core.Model.ApplicationSurveyAnswerListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyAnswer>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);
    }
}
