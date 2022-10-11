using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    class AnnouncementService : Service<Core.DataSource.IAnnouncementDataSource>, Core.Service.IAnnouncementService
    {
        public AnnouncementService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<@Model.Announcement>> AddAsync(@Model.Announcement model)
        {
            if (_requestInfo.ProvinceId != null)
                model.ProvinceID = _requestInfo.ProvinceId;

            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<@Model.Announcement>> EditAsync(@Model.Announcement model)
        {
            if (_requestInfo.ProvinceId != null)
                model.ProvinceID = _requestInfo.ProvinceId;

            return _dataSource.UpdateAsync(model, null);
        }


        public Task<AppCore.Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id, null);

        public Task<AppCore.Result> SetOrdersAsync(IEnumerable<Core.Model.Announcement> models)
        {
            return _dataSource.SetOrdersAsync(models, null);
        }

        public Task<AppCore.Result<@Model.Announcement>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<@Model.Announcement>>> ListAsync(@Model.AnnouncementListVM model)
        {
            return _dataSource.ListAsync(model);
        }

        public Task<AppCore.Result<IEnumerable<@Model.Announcement>>> ListForBulletinAsync(@Model.AnnouncementListVM model)
        {
            return _dataSource.ListForBulletinAsync(model);
        }

        public Task<AppCore.Result<IEnumerable<@Model.AnnouncementPositionType>>> ListPositionTypesAsync(Guid announcementId)
        {
            return _dataSource.ListPositionTypesAsync(announcementId);
        }

    }
}
