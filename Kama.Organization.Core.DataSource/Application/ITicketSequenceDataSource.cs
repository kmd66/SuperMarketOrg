using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface ITicketSequenceDataSource : IDataSource
    {
        Task<AppCore.Result<Model.TicketSequence>> CreateAsync(Model.TicketSequence model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.TicketSequence>> UpdateAsync(Model.TicketSequence model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.TicketSequence>>> ListAsync(Core.Model.TicketSequenceListVM model);

        Task<AppCore.Result<Model.TicketSequence>> GetAsync(Guid id);

        Task<AppCore.Result<Model.TicketSequence>> SetReadDateAsync(Model.TicketSequence model, AppCore.IActivityLog log);


    }
}
