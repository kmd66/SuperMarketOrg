
using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class TicketSequenceService : Service<Core.DataSource.ITicketSequenceDataSource>, Core.Service.ITicketSequenceService
    {
        public TicketSequenceService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.TicketSequence>> AddAsync(model.TicketSequence ticketSequence)
        {
            ticketSequence.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(ticketSequence, null);
        }

        public Task<AppCore.Result<model.TicketSequence>> EditAsync(model.TicketSequence model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<model.TicketSequence>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.TicketSequence>>> ListAsync(Model.TicketSequenceListVM model)
            => _dataSource.ListAsync(model);


        public Task<AppCore.Result<model.TicketSequence>> SetReadDateAsync(model.TicketSequence model)
        {
            return _dataSource.SetReadDateAsync(model, null);
        }

    }
}
