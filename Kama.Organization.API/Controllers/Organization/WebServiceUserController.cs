using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/WebServiceUser")]
    public class WebServiceUserController : BaseApiController<Core.Service.IWebServiceUserService>
    {
        public WebServiceUserController(Core.Service.IWebServiceUserService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Core.Model.WebServiceUser>> Add(Core.Model.WebServiceUser model)
            => _service.AddAsync(model);

        [HttpPost, Route("edit")]
        public Task<AppCore.Result<Core.Model.WebServiceUser>> Edit(Core.Model.WebServiceUser model)
            => _service.EditAsync(model);

        [HttpPost, Route("delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<Core.Model.WebServiceUser>>> List(Core.Model.WebServiceUserListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Core.Model.WebServiceUser>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("Get")]
        public Task<AppCore.Result<Core.Model.WebServiceUser>> Get(Core.Model.WebServiceUserGetVM model)
            => _service.GetAsync(model);

    }
}