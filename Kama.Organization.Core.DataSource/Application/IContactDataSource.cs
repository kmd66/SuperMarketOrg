using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IContactDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Contact>> CreateAsync(Model.Contact contact, AppCore.IActivityLog log);


        Task<AppCore.Result<Model.Contact>> SetArchiveAsync(Guid id, bool archived, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Contact>> SetNoteAsync(Model.Contact model, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Contact>>> ListAsync(Model.ContactListVM model);

        Task<AppCore.Result<Model.Contact>> GetAsync(Guid? Id);
    }
}
