using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class NotificationConditionService : Service<Core.DataSource.INotificationConditionDataSource>, Core.Service.INotificationConditionService
    {
        public NotificationConditionService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.NotificationCondition>> AddAsync(model.NotificationCondition notification)
        {
            notification.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(notification, null);
        }

        public Task<AppCore.Result<model.NotificationCondition>> EditAsync(model.NotificationCondition model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<model.NotificationCondition>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.NotificationCondition>>> ListAsync(Model.NotificationConditionsListVM model)
            => _dataSource.ListAsync(model);
    }
}
