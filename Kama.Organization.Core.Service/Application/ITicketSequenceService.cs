using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface ITicketSequenceService : IService
    {
        Task<AppCore.Result<Model.TicketSequence>> AddAsync(Model.TicketSequence model);

        Task<AppCore.Result<Model.TicketSequence>> EditAsync(Model.TicketSequence model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.TicketSequence>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.TicketSequence>>> ListAsync(Model.TicketSequenceListVM model);

        Task<AppCore.Result<Model.TicketSequence>> SetReadDateAsync(Model.TicketSequence model);


    }
}