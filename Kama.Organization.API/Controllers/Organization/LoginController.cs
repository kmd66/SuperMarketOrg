using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/Login")]
    public class LoginController : BaseApiController<Core.Service.IRefreshTokenService>
    {
        public LoginController(Core.Service.IRefreshTokenService service) : base(service)
        {
        }

        [HttpPost, Route("logout/{RefreshTokenID:guid}")]
        public Task<AppCore.Result> Logout(Guid RefreshTokenID)
            => _service.DeleteAsync(RefreshTokenID);
    }
}