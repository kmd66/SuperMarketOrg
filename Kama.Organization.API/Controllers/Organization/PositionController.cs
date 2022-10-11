using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using model = Kama.Organization.Core.Model;
using Kama.Organization.Core.Model;

namespace Kama.Organization.API.Controllers
{

    [RoutePrefix("api/v1/Position")]
    public class PositionController : BaseApiController<Core.Service.IPositionService>
    {
        public PositionController(Core.Service.IPositionService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Position>> Add(Position model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit"), AllowAnonymous]
        public Task<AppCore.Result<Position>> Edit(Position model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("SetDefault/{positionId:guid}")]
        public Task<AppCore.Result> SetDefault(Guid positionId)
            => _service.SetDefaultAsync(positionId);

        [HttpPost, Route("RemoveUser/{id:guid}")]
        public Task<AppCore.Result> RemoveUser(Guid id)
            => _service.RemoveUserAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Position<PositionType>>>> List(PositionListVM model)
            => _service.ListAsync<PositionType>(model);

        [HttpPost, Route("ListCurrentUserPositions")]
        public Task<AppCore.Result<IEnumerable<model.Position<PositionType>>>> ListCurrentUserPositions()
           => _service.ListCurrentUserPositionsAsync<PositionType>();

        [HttpPost, Route("ListInAllApplications")]
        public Task<AppCore.Result<IEnumerable<model.Position<PositionType>>>> ListInAllApplications(PositionListVM model)
            => _service.ListInAllApplicationsAsync<PositionType>(model);

        [HttpPost, Route("get/{id:guid}")]
        public Task<AppCore.Result<model.Position>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("GetOnlineCount")]
        public Task<AppCore.Result<model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCount()
            => _service.GetOnlineCountAsync();

        [HttpPost, Route("ListExcel")]
        public Task<AppCore.Result<byte[]>> ListExcel(PositionListVM model)
            => _service.ListExcelAsync<PositionType>(model);

        [HttpPost, Route("ListExcelWithRole")]
        public Task<AppCore.Result<byte[]>> ListExcelWithRole(PositionListVM model)
            => _service.ListExcelWithRolesAsync<PositionType>(model);

        [HttpPost, Route("GetPermissions/{positionId:guid}")]
        public Task<AppCore.Result<IEnumerable<object>>> GetPermissions(Guid positionId)
            => _service.GetPermissionsAsync(positionId);

        [HttpPost, Route("CheckPermission/commandId")]
        public Task<AppCore.Result<bool>> CheckPermission(Guid commandId)
           => _service.CheckPermission(commandId);
    }
}