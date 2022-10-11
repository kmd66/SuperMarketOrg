using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/DynamicPermission")]
    public class DynamicPermissionController : BaseApiController<Core.Service.IDynamicPermissionService>
    {
        public DynamicPermissionController(Core.Service.IDynamicPermissionService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.DynamicPermission>> Add(model.DynamicPermission model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.DynamicPermission>> Edit(model.DynamicPermission model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete")]
        public Task<AppCore.Result> Delete(model.DynamicPermission model)
           => _service.DeleteAsync(model);

        [HttpGet, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.DynamicPermission>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.DynamicPermission>>> List(model.DynamicPermissionListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("ListPositions")]
        public Task<AppCore.Result<IEnumerable<model.Position>>> ListPositionsAsync(model.DynamicPermissionListPositionsVM model)
            => _service.ListPositionsAsync(model);

        [HttpPost, Route("ListObjectsByPosition")]
        public Task<AppCore.Result<IEnumerable<model.Model>>> ListObjectsByPositionAsync(Guid positionId)
            => _service.ListObjectsByPositionAsync(positionId);
    }
}