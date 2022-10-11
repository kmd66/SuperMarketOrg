using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey-question")]
    public class ApplicationSurveyQuestionController : BaseApiController<Core.Service.IApplicationSurveyQuestionService>
    {
        public ApplicationSurveyQuestionController(Core.Service.IApplicationSurveyQuestionService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestion>> Add(model.ApplicationSurveyQuestion model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestion>> Edit(model.ApplicationSurveyQuestion model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestion>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> List(model.ApplicationSurveyQuestionListVM model)
            => _service.ListAsync(model);

        [HttpPost, Route("ListQuestionAndChoice")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ListQuestionAndChoice(model.ApplicationSurveyQuestionListVM model)
            => _service.ListQuestionAndChoiceAsync(model);

        [HttpPost, Route("ReportQuestion")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ReportQuestion(model.ApplicationSurveyQuestionListVM model)
            => _service.ReportQuestionAsync(model);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete(Guid Id)
            => _service.DeleteAsync(Id);
    }
}