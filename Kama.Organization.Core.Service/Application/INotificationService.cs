using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface INotificationService : IService
    {
        Task<AppCore.Result<Model.Notification>> AddAsync(Model.Notification model);

        Task<AppCore.Result<Model.Notification>> EditAsync(Model.Notification model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result> SendAsync(Guid id);

        Task<AppCore.Result> ArchiveAsync(Guid id);

        Task<AppCore.Result<Model.Notification>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Notification>>> ListAsync(Model.NotificationsListVM model);

        Task<AppCore.Result<IEnumerable<Model.Notification>>> ListByPositionAsync(Model.NotificationListByPositionVM model);

        Task<AppCore.Result<IEnumerable<Model.NotificationPosition>>> ListPositionsAsync(Model.NotificationPositionsListVM model);
    }
}