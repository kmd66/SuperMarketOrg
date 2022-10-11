using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyQuestionChoiceService : Service<Core.DataSource.IApplicationSurveyQuestionChoiceDataSource>, Core.Service.IApplicationSurveyQuestionChoiceService
    {
        public ApplicationSurveyQuestionChoiceService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> AddAsync(Core.Model.ApplicationSurveyQuestionChoice model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> EditAsync(Core.Model.ApplicationSurveyQuestionChoice model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyQuestionChoice>>> ListAsync(Core.Model.ApplicationSurveyQuestionChoiceListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyQuestionChoice>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);
    }
}
