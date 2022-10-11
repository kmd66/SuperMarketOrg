using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface ITicketSubjectService : IService
    {
        Task<AppCore.Result<Model.TicketSubject>> AddAsync(Model.TicketSubject model);

        Task<AppCore.Result<Model.TicketSubject>> EditAsync(Model.TicketSubject model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.TicketSubject>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.TicketSubject>>> ListAsync(Model.TicketSubjectListVM model);

    }
}