using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using mdl = Core.Model;

    [RoutePrefix("api/v1/place")]
    public class PlaceController : BaseApiController<Core.Service.IPlaceService>
    {
        public PlaceController(Core.Service.IPlaceService service) : base(service)
        {
        }

        [HttpPost, Route("Delete/{id:guid}")]
        public AppCore.Result Delete(Guid id)
        {
            return AppCore.Result.Failure(-1, "");
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<mdl.Place>> Add(mdl.Place model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<mdl.Place>> Edit(mdl.Place model)
            => _service.EditAsync(model);

        [AllowAnonymous]
        [HttpPost, Route("list")]
        public Task<AppCore.Result<IEnumerable<mdl.Place>>> List(mdl.PlaceListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("get/{id:guid}")]
        public Task<AppCore.Result<mdl.Place>> Get(Guid id)
            => _service.GetAsync(id);
    }
}