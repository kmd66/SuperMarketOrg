using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/TicketSubjectUser")]
    public class TicketSubjectUserController : BaseApiController<@Service.ITicketSubjectUserService>
    {
        public TicketSubjectUserController(@Service.ITicketSubjectUserService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.TicketSubjectUser>> Add(@Model.TicketSubjectUser model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.TicketSubjectUser>> Edit(@Model.TicketSubjectUser model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.TicketSubjectUser>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.TicketSubjectUser>>> List(Model.TicketSubjectUserListVM model)
            => _service.ListAsync(model);
    }
}