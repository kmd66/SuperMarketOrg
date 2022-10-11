using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyService : Service<Core.DataSource.IApplicationSurveyDataSource>, Core.Service.IApplicationSurveyService
    {
        public ApplicationSurveyService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurvey>> AddAsync(Core.Model.ApplicationSurvey model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurvey>> EditAsync(Core.Model.ApplicationSurvey model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurvey>>> ListAsync(Core.Model.ApplicationSurveyListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.ApplicationSurvey>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);
    }
}
