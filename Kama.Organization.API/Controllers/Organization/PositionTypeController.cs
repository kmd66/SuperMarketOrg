using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using model = Kama.Organization.Core.Model;
using Kama.Organization.Core.Model;
using Kama.AppCore;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/PositionType")]
    public class PositionTypeController : BaseApiController<Core.Service.IPositionTypeService>
    {
        public PositionTypeController(Core.Service.IPositionTypeService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<Result<PositionTypeModel>> Add(PositionTypeModel model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<Result<PositionTypeModel>> Edit(PositionTypeModel model)
            => _service.EditAsync(model);

        [HttpPost, Route("SetRoles")]
        public Task<Result> SetRoles(PositionTypeModel model)
            => _service.SetRolesAsync(model);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<PositionTypeModel>>> List()
            => _service.ListAsync();

        [HttpPost, Route("Get")]
        public Task<AppCore.Result<PositionTypeModel>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("GetRoles/{positionType}")]
        public Task<Result<IEnumerable<Role>>> GetRoles(PositionType positionType)
            => _service.GetRolesAsync(positionType);

    }
}