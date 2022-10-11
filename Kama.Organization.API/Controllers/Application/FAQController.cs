using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/FAQ")]
    public class FAQController : BaseApiController<Core.Service.IFAQService>
    {
        public FAQController(Core.Service.IFAQService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.FAQ>> Add(model.FAQ model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.FAQ>> Edit(model.FAQ model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.FAQ>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.FAQ>>> List(model.FAQListVM faqListVm)
            => _service.ListAsync(faqListVm);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete(Guid Id)
            => _service.DeleteAsync(Id);
    }
}