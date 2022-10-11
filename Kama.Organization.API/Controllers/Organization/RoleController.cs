using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Role")]
    public class RoleController : BaseApiController<Core.Service.IRoleService>
    {
        public RoleController(Core.Service.IRoleService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Role>> Add(model.Role model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.Role>> Edit(model.Role model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<AppCore.Result> Delete(model.Role model)
           => _service.DeleteAsync(model);

        [HttpGet, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Role>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Role>>> List(model.RoleListVM model)
            => _service.ListAsync(model);
    }
}