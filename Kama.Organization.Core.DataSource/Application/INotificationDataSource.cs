using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface INotificationDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Notification>> CreateAsync(Model.Notification model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Notification>> UpdateAsync(Model.Notification model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> SendAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> ArchiveAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Notification>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Notification>>> ListAsync(Core.Model.NotificationsListVM model);

        Task<AppCore.Result<IEnumerable<Model.Notification>>> ListByPositionAsync(Core.Model.NotificationListByPositionVM model);

        Task<AppCore.Result<IEnumerable<Model.NotificationPosition>>> ListPositionsAsync(Core.Model.NotificationPositionsListVM model);

    }
}
