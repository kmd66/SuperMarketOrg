using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface ITicketSubjectUserDataSource : IDataSource
    {
        Task<AppCore.Result<Model.TicketSubjectUser>> CreateAsync(Model.TicketSubjectUser model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.TicketSubjectUser>> UpdateAsync(Model.TicketSubjectUser model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.TicketSubjectUser>>> ListAsync(Core.Model.TicketSubjectUserListVM model);

        Task<AppCore.Result<Model.TicketSubjectUser>> GetAsync(Guid id);

    }
}
