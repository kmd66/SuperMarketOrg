using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using mdl = Core.Model;

    [RoutePrefix("api/v1/positionHistory")]
    public class PositionHistoryController : BaseApiController<Core.Service.IPositionHistoryService>
    {
        public PositionHistoryController(Core.Service.IPositionHistoryService service) : base(service)
        {
        }

        [HttpPost, Route("Delete/{id:guid}")]
        public AppCore.Result Delete(Guid id)
        {
            return AppCore.Result.Failure(-1, "");
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<mdl.PositionHistory>> Add(mdl.PositionHistory model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<mdl.PositionHistory>> Edit(mdl.PositionHistory model)
            => _service.EditAsync(model);

        [HttpPost, Route("list")]
        public Task<AppCore.Result<IEnumerable<mdl.PositionHistory>>> List(mdl.PositionHistoryListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("get/{id:guid}")]
        public Task<AppCore.Result<mdl.PositionHistory>> Get(Guid id)
            => _service.GetAsync(id);
    }
}