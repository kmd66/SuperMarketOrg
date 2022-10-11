using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class ApplicationSurveyParticipantService : Service<Core.DataSource.IApplicationSurveyParticipantDataSource>, Core.Service.IApplicationSurveyParticipantService
    {
        public ApplicationSurveyParticipantService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> AddAsync(Core.Model.ApplicationSurveyParticipant model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> EditAsync(Core.Model.ApplicationSurveyParticipant model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.ApplicationSurveyParticipant>>> ListAsync(Core.Model.ApplicationSurveyParticipantListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.ApplicationSurveyParticipant>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);
        
    }
}
