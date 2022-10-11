using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface INotificationConditionDataSource : IDataSource
    {
        Task<AppCore.Result<Model.NotificationCondition>> CreateAsync(Model.NotificationCondition model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.NotificationCondition>> UpdateAsync(Model.NotificationCondition model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.NotificationCondition>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.NotificationCondition>>> ListAsync(Core.Model.NotificationConditionsListVM model);

    }
}
