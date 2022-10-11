using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey-question-choice")]
    public class ApplicationSurveyQuestionChoiceController : BaseApiController<Core.Service.IApplicationSurveyQuestionChoiceService>
    {
        public ApplicationSurveyQuestionChoiceController(Core.Service.IApplicationSurveyQuestionChoiceService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Add(model.ApplicationSurveyQuestionChoice model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Edit(model.ApplicationSurveyQuestionChoice model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestionChoice>>> List(model.ApplicationSurveyQuestionChoiceListVM model)
            => _service.ListAsync(model);

        [HttpGet, Route("Delete/{Id:guid}")]
        public Task<AppCore.Result> Delete(Guid Id)
            => _service.DeleteAsync(Id);
    }
}