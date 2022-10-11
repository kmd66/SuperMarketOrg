using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Application")]
    public class ApplicationController: BaseApiController<Core.Service.IApplicationService>
    {
        public ApplicationController(Core.Service.IApplicationService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Application>> Add(model.Application model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.Application>> Edit(model.Application model)
            => _service.EditAsync(model);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Application>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Application>>> List(model.ApplicationListVM model)
            => _service.ListAsync(model);
    }
}