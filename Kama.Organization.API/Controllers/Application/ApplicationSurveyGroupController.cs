using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey-group")]
    public class ApplicationSurveyGroupController : BaseApiController<Core.Service.IApplicationSurveyGroupService>
    {
        public ApplicationSurveyGroupController(Core.Service.IApplicationSurveyGroupService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.ApplicationSurveyGroup>> Add(model.ApplicationSurveyGroup model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.ApplicationSurveyGroup>> Edit(model.ApplicationSurveyGroup model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurveyGroup>> Get([FromUri]Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> List(model.ApplicationSurveyGroupListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("ListGroupAndQuestion")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ListGroupAndQuestion(model.ApplicationSurveyGroupListVM model)
            => _service.ListGroupAndQuestionAsync(model);

        [HttpPost, Route("ReportGroup")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ReportGroup(model.ApplicationSurveyGroupListVM model)
            => _service.ReportGroupAsync(model);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete([FromUri]Guid Id)
            => _service.DeleteAsync(Id);
    }
}