using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Department")]
    public class DepartmentController : BaseApiController<Core.Service.IDepartmentService>
    {
        public DepartmentController(Core.Service.IDepartmentService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Department>> Add(model.Department model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.Department>> Edit(model.Department model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete([FromUri]Guid id)
            => _service.DeleteAsync(new model.Department { ID = id });

        [HttpPost, Route("list")]
        public Task<AppCore.Result<IEnumerable<model.Department>>> List(model.DepartmentListVM department)
            => _service.ListAsync(department);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Department>> Get([FromUri]Guid id)
            => _service.GetAsync(id);
    }
}