using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = Kama.Organization.Core.Model;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/ContactInfo")]
    public class ContactInfoController : BaseApiController<Core.Service.IContactInfoService>
    {
        public ContactInfoController(Core.Service.IContactInfoService service)
            : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Model.ContactInfo>> Add(Model.ContactInfo model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<Model.ContactInfo>> Edit(Model.ContactInfo model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete([FromUri]Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.ContactInfo>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List/{parentId:guid}")]
        public Task<AppCore.Result<IEnumerable<Model.ContactInfo>>> List([FromUri]Guid parentId)
            => _service.ListAsync(parentId);
    }
}