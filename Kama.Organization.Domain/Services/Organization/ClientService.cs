using Kama.AppCore;
using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    internal class ClientService : Service<Core.DataSource.IClientDataSource>, Core.Service.IClientService
    {
        public ClientService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<IEnumerable<@Model.Client>>> ListAsync(Guid applicationId)
            => _dataSource.ListAsync(applicationId);

        public Task<AppCore.Result<@Model.Client>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.Client>>> ListAsync(@Model.ClientListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<@Model.Client>> AddAsync(@Model.Client model)
        {
            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<@Model.Client>> EditAsync(@Model.Client model)
        {
            return _dataSource.UpdateAsync(model, null);
        }
    }
}