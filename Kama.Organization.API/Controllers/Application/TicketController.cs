using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using @Model = Kama.Organization.Core.Model;
using @Service = Kama.Organization.Core.Service;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/Ticket")]
    public class TicketController : BaseApiController<@Service.ITicketService>
    {
        public TicketController(@Service.ITicketService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<@Model.Ticket>> Add(@Model.Ticket model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<@Model.Ticket>> Edit(@Model.Ticket model)
            => _service.EditAsync(model);

        [HttpPost, Route("SetTicketOwner")]
        public Task<AppCore.Result<@Model.Ticket>> SetTicketOwner(@Model.Ticket model)
            => _service.SetTicketOwnerAsync(model);

        [HttpPost, Route("Rating")]
        public Task<AppCore.Result<@Model.Ticket>> Rating(@Model.Ticket model)
            => _service.RatingAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.Ticket>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<@Model.Ticket>>> List(Model.TicketListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("Report")]
        public Task<AppCore.Result<IEnumerable<@Model.Ticket>>> Report(Model.TicketReportListVM model)
            => _service.ReportAsync(model);
    }
}