using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface ITicketDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Ticket>> CreateAsync(Model.Ticket model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Ticket>> UpdateAsync(Model.Ticket model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Ticket>> SetTicketOwnerAsync(Model.Ticket model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Ticket>> RatingAsync(Model.Ticket model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Ticket>>> ListAsync(Core.Model.TicketListVM model);

        Task<AppCore.Result<IEnumerable<Model.Ticket>>> ReportAsync(Core.Model.TicketReportListVM model);

        Task<AppCore.Result<Model.Ticket>> GetAsync(Guid id);

    }
}
