using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IWebServiceUserDataSource : IDataSource
    {
        Task<AppCore.Result<Model.WebServiceUser>> CreateAsync(Model.WebServiceUser model);

        Task<AppCore.Result<Model.WebServiceUser>> UpdateAsync(Model.WebServiceUser model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.WebServiceUser>> GetAsync(Guid id);

        Task<AppCore.Result<Model.WebServiceUser>> GetAsync(Model.WebServiceUserGetVM model);

        Task<AppCore.Result<IEnumerable<Model.WebServiceUser>>> ListAsync(Model.WebServiceUserListVM model);

    }
}