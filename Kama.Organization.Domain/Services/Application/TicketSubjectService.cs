
using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class TicketSubjectService : Service<Core.DataSource.ITicketSubjectDataSource>, Core.Service.ITicketSubjectService
    {
        public TicketSubjectService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.TicketSubject>> AddAsync(model.TicketSubject ticketSubject)
        {
            var validation = _ValidateForSave(ticketSubject);
            if (!validation.Result.Success)
                return AppCore.Result<model.TicketSubject>.FailureAsync(message: validation.Result.Message);

            ticketSubject.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(ticketSubject, null);
        }

        public Task<AppCore.Result<model.TicketSubject>> EditAsync(model.TicketSubject model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.TicketSubject>.FailureAsync(message: validation.Result.Message);

            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<model.TicketSubject>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.TicketSubject>>> ListAsync(Model.TicketSubjectListVM model)
            => _dataSource.ListAsync(model);

        private Task<AppCore.Result> _ValidateForSave(model.TicketSubject model)
        {
            if(model.Type == Model.UserType.Unknown)
                return AppCore.Result.FailureAsync(message: "نوع تیکت مشخص نشده ");
            return AppCore.Result.SuccessfulAsync();
        }
    }
}
