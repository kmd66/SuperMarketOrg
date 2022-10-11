using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Command")]
    public class CommandController : BaseApiController<Core.Service.ICommandService>
    {
        public CommandController(Core.Service.ICommandService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Command>> Add(model.Command model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit"), AllowAnonymous]
        public Task<AppCore.Result<model.Command>> Edit(model.Command model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Command>>> List(Core.Model.CommandListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Command>> Get(Guid id)
            => _service.GetAsync(id);


    }
}