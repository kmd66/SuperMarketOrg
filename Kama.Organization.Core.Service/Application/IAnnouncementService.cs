using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IAnnouncementService : IService
    {
        Task<AppCore.Result<Model.Announcement>> AddAsync(Model.Announcement announcement);

        Task<AppCore.Result<Model.Announcement>> EditAsync(Model.Announcement announcement);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result> SetOrdersAsync(IEnumerable<Core.Model.Announcement> models);

        Task<AppCore.Result<Model.Announcement>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Announcement>>> ListAsync(Model.AnnouncementListVM announcement);

        Task<AppCore.Result<IEnumerable<Model.Announcement>>> ListForBulletinAsync(Model.AnnouncementListVM announcement);

        Task<AppCore.Result<IEnumerable<Model.AnnouncementPositionType>>> ListPositionTypesAsync(Guid announcementId);
    }
}