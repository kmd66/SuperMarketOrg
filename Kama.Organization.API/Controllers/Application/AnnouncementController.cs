using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/Announcement")]
    public class AnnouncementController : BaseApiController<@Service.IAnnouncementService>
    {
        public AnnouncementController(@Service.IAnnouncementService service):base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.Announcement>> Add(@Model.Announcement model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.Announcement>> Edit(@Model.Announcement model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("SetOrders")]
        public Task<AppCore.Result> SetOrders(List<Core.Model.Announcement> models)
            => _service.SetOrdersAsync(models);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<@Model.Announcement>> Get([FromUri]Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.Announcement>>> List(@Model.AnnouncementListVM announcement)
            => _service.ListAsync(announcement);

        [HttpPost, Route("ListForBulletin")]
        public Task<AppCore.Result<IEnumerable<@Model.Announcement>>> ListForBulletin(@Model.AnnouncementListVM announcement)
            => _service.ListForBulletinAsync(announcement);

        [HttpPost, Route("ListUserTypes/{announcementId:guid}")]
        public Task<AppCore.Result<IEnumerable<@Model.AnnouncementPositionType>>> ListPositionTypes(Guid announcementId)
            => _service.ListPositionTypesAsync(announcementId);
    }
}