using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/TicketSequence")]
    public class TicketSequenceController : BaseApiController<@Service.ITicketSequenceService>
    {
        public TicketSequenceController(@Service.ITicketSequenceService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.TicketSequence>> Add(@Model.TicketSequence model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.TicketSequence>> Edit(@Model.TicketSequence model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.TicketSequence>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.TicketSequence>>> List(Model.TicketSequenceListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("SetReadDate")]
        public Task<AppCore.Result<@Model.TicketSequence>> SetReadDate(@Model.TicketSequence model)
            => _service.SetReadDateAsync(model);
    }
}