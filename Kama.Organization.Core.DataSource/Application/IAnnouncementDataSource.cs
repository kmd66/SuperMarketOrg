using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IAnnouncementDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Announcement>> CreateAsync(Model.Announcement model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Announcement>> UpdateAsync(Model.Announcement model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> SetOrdersAsync(IEnumerable<Core.Model.Announcement> models, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Announcement>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Core.Model.Announcement>>> ListAsync(Model.AnnouncementListVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.Announcement>>> ListForBulletinAsync(Model.AnnouncementListVM model);

        Task<AppCore.Result<IEnumerable<Core.Model.AnnouncementPositionType>>> ListPositionTypesAsync(Guid model);

    }
}
