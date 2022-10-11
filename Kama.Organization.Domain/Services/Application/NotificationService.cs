
using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class NotificationService : Service<Core.DataSource.INotificationDataSource>, Core.Service.INotificationService
    {
        public NotificationService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.Notification>> AddAsync(model.Notification notification)
        {
            notification.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(notification, null);
        }

        public Task<AppCore.Result<model.Notification>> EditAsync(model.Notification model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public async Task<AppCore.Result> SendAsync(Guid id)
        {
            var getResult = await this.GetAsync(id);
            if (!getResult.Success)
                return AppCore.Result.Failure(message: getResult.Message);
            var message = getResult.Data;

            if (string.IsNullOrEmpty(message.Title))
                return AppCore.Result.Failure(message: "عنوان وارد نشده است");

            if (string.IsNullOrEmpty(message.Content))
                return AppCore.Result.Failure(message: "محتوی اعلان وارد نشده است");

            return await _dataSource.SendAsync(id, null);
        }

        public Task<AppCore.Result> ArchiveAsync(Guid id)
        {
            return _dataSource.ArchiveAsync(id, null);
        }

        public Task<AppCore.Result<model.Notification>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.Notification>>> ListAsync(Model.NotificationsListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<IEnumerable<Model.Notification>>> ListByPositionAsync(Model.NotificationListByPositionVM model)
            => _dataSource.ListByPositionAsync(model);

        public Task<AppCore.Result<IEnumerable<Model.NotificationPosition>>> ListPositionsAsync(Model.NotificationPositionsListVM model)
            => _dataSource.ListPositionsAsync(model);
    }
}
