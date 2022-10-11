using System;
using System.Threading.Tasks;
using Model = Kama.Organization.Core.Model;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/ContactDetail")]
    public class ContactDetailController : BaseApiController<Core.Service.IContactDetailService>
    {
        public ContactDetailController(Core.Service.IContactDetailService service)
            : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Model.ContactDetail>> Add(Model.ContactDetail model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<Model.ContactDetail>> Edit(Model.ContactDetail model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete([FromUri]Guid id)
            => _service.DeleteAsync(id);

    }
}