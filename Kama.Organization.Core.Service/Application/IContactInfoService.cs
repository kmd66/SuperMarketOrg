using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IContactInfoService : IService
    {
        Task<AppCore.Result<Model.ContactInfo>> AddAsync(Model.ContactInfo model);

        Task<AppCore.Result<Model.ContactInfo>> EditAsync(Model.ContactInfo model);

        Task<AppCore.Result> DeleteAsync(Guid model);

        Task<AppCore.Result<Model.ContactInfo>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.ContactInfo>>> ListAsync(Guid parentId);
    }
}
