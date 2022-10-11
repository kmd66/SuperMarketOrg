using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class ContactService : Service<Core.DataSource.IContactDataSource>, Core.Service.IContactService
    {
        public ContactService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.Contact>> AddAsync(model.Contact model)
        {
            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.Contact>> SetArchiveAsync(Guid id)
            => _dataSource.SetArchiveAsync(id, true, null);

        public Task<AppCore.Result<model.Contact>> SetUnArchiveAsync(Guid id)
            => _dataSource.SetArchiveAsync(id, false, null);

        public Task<AppCore.Result<model.Contact>> SetNoteAsync(model.Contact model)
            => _dataSource.SetNoteAsync(model, null);

        public Task<AppCore.Result<IEnumerable<model.Contact>>> ListAsync(model.ContactListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<model.Contact>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);
    }
}
