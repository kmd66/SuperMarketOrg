
using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class TicketSubjectUserService : Service<Core.DataSource.ITicketSubjectUserDataSource>, Core.Service.ITicketSubjectUserService
    {
        public TicketSubjectUserService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.TicketSubjectUser>> AddAsync(model.TicketSubjectUser ticketSubjectUser)
        {
            ticketSubjectUser.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(ticketSubjectUser, null);
        }

        public Task<AppCore.Result<model.TicketSubjectUser>> EditAsync(model.TicketSubjectUser model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<model.TicketSubjectUser>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.TicketSubjectUser>>> ListAsync(Model.TicketSubjectUserListVM model)
            => _dataSource.ListAsync(model);

    }
}
