using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = Kama.Organization.Core.Model;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/Attachment")]
    public class AttachmentController : BaseApiController<Core.Service.IAttachmentService>
    {
        public AttachmentController(Core.Service.IAttachmentService service)
            : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Model.Attachment>> Add(Model.Attachment model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<Model.Attachment>> Edit(Model.Attachment model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<AppCore.Result> Delete(Model.Attachment model)
            => _service.DeleteAsync(model);

        [AllowAnonymous]
        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Model.Attachment>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List/{compalintId:guid}")]
        public Task<AppCore.Result<IEnumerable<Model.Attachment>>> List([FromUri]Guid compalintId)
            => _service.ListAsync(compalintId);
    }
}