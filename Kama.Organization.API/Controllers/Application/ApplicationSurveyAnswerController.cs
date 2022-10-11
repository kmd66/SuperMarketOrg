using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey-answer")]
    public class ApplicationSurveyAnswerController : BaseApiController<Core.Service.IApplicationSurveyAnswerService>
    {
        public ApplicationSurveyAnswerController(Core.Service.IApplicationSurveyAnswerService service) : base(service)
        {
        }

        [HttpPost, Route("Modify")]
        public Task<AppCore.Result> Modify(model.InsertSurveyAnswer model)
            => _service.ModifyAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurveyAnswer>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyAnswer>>> List(model.ApplicationSurveyAnswerListVM model)
            => _service.ListAsync(model);
    }
}