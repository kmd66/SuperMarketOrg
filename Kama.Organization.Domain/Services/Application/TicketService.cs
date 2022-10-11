
using Kama.Organization.Core;
using Kama.Organization.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class TicketService : Service<Core.DataSource.ITicketDataSource>, Core.Service.ITicketService
    {
        public TicketService(AppCore.IOC.IContainer container
            //, ICheckaAccessService checkaAccess
            )
            : base(container)
        {
            //_checkaAccess = checkaAccess;
        }
        //readonly ICheckaAccessService _checkaAccess;

        public async Task<AppCore.Result<model.Ticket>> AddAsync(model.Ticket ticket)
        {
            ticket.ID = Guid.NewGuid();
            return await _dataSource.CreateAsync(ticket, null);
        }

        public Task<AppCore.Result<model.Ticket>> EditAsync(model.Ticket model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<model.Ticket>> SetTicketOwnerAsync(model.Ticket model)
        {
            return _dataSource.SetTicketOwnerAsync(model, null);
        }

        public Task<AppCore.Result<model.Ticket>> RatingAsync(model.Ticket model)
        {
            return _dataSource.RatingAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<model.Ticket>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.Ticket>>> ListAsync(Model.TicketListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<IEnumerable<@Model.Ticket>>> ReportAsync(Model.TicketReportListVM model)
            => _dataSource.ReportAsync(model);

    }
}
