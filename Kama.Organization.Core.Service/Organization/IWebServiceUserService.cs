using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IWebServiceUserService : IService
    {
        Task<AppCore.Result<Model.WebServiceUser>> AddAsync(Model.WebServiceUser model);

        Task<AppCore.Result<Model.WebServiceUser>> EditAsync(Model.WebServiceUser model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.WebServiceUser>> GetAsync(Guid id);

        Task<AppCore.Result<Model.WebServiceUser>> GetAsync(Model.WebServiceUserGetVM model);

        Task<AppCore.Result<IEnumerable<Model.WebServiceUser>>> ListAsync(Model.WebServiceUserListVM model);

    }
}