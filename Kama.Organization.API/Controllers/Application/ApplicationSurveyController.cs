using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey")]
    public class ApplicationSurveyController : BaseApiController<Core.Service.IApplicationSurveyService>
    {
        public ApplicationSurveyController(Core.Service.IApplicationSurveyService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.ApplicationSurvey>> Add(model.ApplicationSurvey model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.ApplicationSurvey>> Edit(model.ApplicationSurvey model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurvey>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurvey>>> List(model.ApplicationSurveyListVM model)
            => _service.ListAsync(model);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete(Guid Id)
            => _service.DeleteAsync(Id);
    }
}