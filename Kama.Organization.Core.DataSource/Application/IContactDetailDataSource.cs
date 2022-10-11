using Kama.Organization.Core.DataSource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IContactDetailDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ContactDetail>> CreateAsync(Model.ContactDetail model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ContactDetail>> UpdateAsync(Model.ContactDetail model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ContactDetail>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ContactDetail>>> ListAsync(IEnumerable<Model.ContactInfo> contactInfoIds);

    }
}
