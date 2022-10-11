using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/FAQGroup")]
    public class FAQGroupController : BaseApiController<Core.Service.IFAQGroupService>
    {
        public FAQGroupController(Core.Service.IFAQGroupService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.FAQGroup>> Add(model.FAQGroup model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.FAQGroup>> Edit(model.FAQGroup model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.FAQGroup>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.FAQGroup>>> List(model.FAQGroupListVM faqGroupListVM)
            => _service.ListAsync(faqGroupListVM);

        [HttpPost, Route("ListWithFAQs")]
        public Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListWithFAQs(model.FAQGroupListVM faqGroupListVM)
            => _service.ListWithFAQsAsync(faqGroupListVM);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete(Guid Id)
            => _service.DeleteAsync(Id);
    }
}