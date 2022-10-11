using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface INotificationConditionService : IService
    {
        Task<AppCore.Result<Model.NotificationCondition>> AddAsync(Model.NotificationCondition model);

        Task<AppCore.Result<Model.NotificationCondition>> EditAsync(Model.NotificationCondition model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Model.NotificationCondition>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.NotificationCondition>>> ListAsync(Model.NotificationConditionsListVM model);
    }
}