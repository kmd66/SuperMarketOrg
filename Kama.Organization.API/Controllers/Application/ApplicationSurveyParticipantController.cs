using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/application-survey-participant")]
    public class ApplicationSurveyParticipantController : BaseApiController<Core.Service.IApplicationSurveyParticipantService>
    {
        public ApplicationSurveyParticipantController(Core.Service.IApplicationSurveyParticipantService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.ApplicationSurveyParticipant>> Add(model.ApplicationSurveyParticipant model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.ApplicationSurveyParticipant>> Edit(model.ApplicationSurveyParticipant model)
            => _service.EditAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.ApplicationSurveyParticipant>> Get(Guid Id)
            => _service.GetAsync(Id);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.ApplicationSurveyParticipant>>> List(model.ApplicationSurveyParticipantListVM model)
            => _service.ListAsync(model);
    }
}