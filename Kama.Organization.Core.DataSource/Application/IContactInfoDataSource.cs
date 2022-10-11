using Kama.Organization.Core.DataSource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IContactInfoDataSource : IDataSource
    {
        Task<AppCore.Result<Model.ContactInfo>> CreateAsync(Model.ContactInfo model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ContactInfo>> UpdateAsync(Model.ContactInfo model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.ContactInfo>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ContactInfo>>> ListAsync(Guid parentId);

    }
}
