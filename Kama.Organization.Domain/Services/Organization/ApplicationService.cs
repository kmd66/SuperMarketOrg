using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class ApplicationService:Service<Core.DataSource.IApplicationDataSource>, Core.Service.IApplicationService
    {
        public ApplicationService(AppCore.IOC.IContainer container)
            :base(container)
        {
        }

        public Task<AppCore.Result<model.Application>> AddAsync(model.Application model)
        {
            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.Application>> EditAsync(model.Application model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<IEnumerable<model.Application>>> ListAsync(model.ApplicationListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<model.Application>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

    }
}
