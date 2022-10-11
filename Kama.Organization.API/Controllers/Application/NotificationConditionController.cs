using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/NotificationCondition")]
    public class NotificationConditionController : BaseApiController<@Service.INotificationConditionService>
    {
        public NotificationConditionController(@Service.INotificationConditionService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.NotificationCondition>> Add(@Model.NotificationCondition model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.NotificationCondition>> Edit(@Model.NotificationCondition model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);


        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.NotificationCondition>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.NotificationCondition>>> List(Model.NotificationConditionsListVM model)
            => _service.ListAsync(model);
    }
}