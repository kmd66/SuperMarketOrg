using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IContactDetailService : IService
    {
        Task<AppCore.Result<Model.ContactDetail>> AddAsync(Model.ContactDetail model);

        Task<AppCore.Result<Model.ContactDetail>> EditAsync(Model.ContactDetail model);

        Task<AppCore.Result> DeleteAsync(Guid model);
    }
}
