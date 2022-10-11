using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface ITicketSubjectUserService : IService
    {
        Task<AppCore.Result<Model.TicketSubjectUser>> AddAsync(Model.TicketSubjectUser model);

        Task<AppCore.Result<Model.TicketSubjectUser>> EditAsync(Model.TicketSubjectUser model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.TicketSubjectUser>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.TicketSubjectUser>>> ListAsync(Model.TicketSubjectUserListVM model);

    }
}