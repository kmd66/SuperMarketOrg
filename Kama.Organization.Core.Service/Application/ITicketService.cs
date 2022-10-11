using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface ITicketService : IService
    {
        Task<AppCore.Result<Model.Ticket>> AddAsync(Model.Ticket model);

        Task<AppCore.Result<Model.Ticket>> EditAsync(Model.Ticket model);

        Task<AppCore.Result<Model.Ticket>> SetTicketOwnerAsync(Model.Ticket model);

        Task<AppCore.Result<Model.Ticket>> RatingAsync(Model.Ticket model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.Ticket>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Ticket>>> ListAsync(Model.TicketListVM model);

        Task<AppCore.Result<IEnumerable<Model.Ticket>>> ReportAsync(Model.TicketReportListVM model);
    }
}