using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface ITicketSubjectDataSource : IDataSource
    {
        Task<AppCore.Result<Model.TicketSubject>> CreateAsync(Model.TicketSubject model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.TicketSubject>> UpdateAsync(Model.TicketSubject model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.TicketSubject>>> ListAsync(Core.Model.TicketSubjectListVM model);

        Task<AppCore.Result<Model.TicketSubject>> GetAsync(Guid id);

    }
}
