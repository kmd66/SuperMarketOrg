using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IContactService : IService
    {

        Task<AppCore.Result<Model.Contact>> AddAsync(Model.Contact model);

        Task<AppCore.Result<Model.Contact>> SetArchiveAsync(Guid id);

        Task<AppCore.Result<Model.Contact>> SetUnArchiveAsync(Guid id);

        Task<AppCore.Result<Model.Contact>> SetNoteAsync(Model.Contact model);

        Task<AppCore.Result<IEnumerable<Model.Contact>>> ListAsync(Model.ContactListVM model);

        Task<AppCore.Result<Model.Contact>> GetAsync(Guid Id);

    }
}