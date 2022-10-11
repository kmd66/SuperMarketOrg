using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Client")]
    public class ClientController: BaseApiController<Core.Service.IClientService>
    {
        public ClientController(Core.Service.IClientService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Client>> Add(model.Client model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.Client>> Edit(model.Client model)
            => _service.EditAsync(model);


        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Client>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Client>>> List(model.ClientListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

    }
}