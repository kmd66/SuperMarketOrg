using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/Notification")]
    public class NotificationController : BaseApiController<@Service.INotificationService>
    {
        public NotificationController(@Service.INotificationService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.Notification>> Add(@Model.Notification model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.Notification>> Edit(@Model.Notification model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("Archive/{id:guid}")]
        public Task<AppCore.Result> Archive(Guid id)
            => _service.ArchiveAsync(id);

        [HttpPost, Route("Send/{id:guid}")]
        public Task<AppCore.Result> Send(Guid id)
            => _service.SendAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.Notification>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.Notification>>> List(Model.NotificationsListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("ListByPosition")]
        public Task<AppCore.Result<IEnumerable<@Model.Notification>>> ListByPosition(Model.NotificationListByPositionVM model)
            => _service.ListByPositionAsync(model);

        [HttpPost, Route("ListPositions")]
        public Task<AppCore.Result<IEnumerable<Model.NotificationPosition>>> ListPositions(Model.NotificationPositionsListVM model)
            => _service.ListPositionsAsync(model);
    }
}