using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using @model = Core.Model;

    [RoutePrefix("api/v1/Message")]
    public class MessageController : BaseApiController<Core.Service.IMessageService>
    {
        public MessageController(Core.Service.IMessageService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Message>> Add(model.Message model)
            => _service.AddAsync(model);

        [HttpPost, Route("Edit")]
        public Task<AppCore.Result<model.Message>> Edit(model.Message model)
            => _service.EditAsync(model);

        [HttpPost, Route("Delete/{id:guid}")]
        public Task<AppCore.Result> Delete([FromUri]Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("PermanentDelete/{id:guid}")]
        public Task<AppCore.Result> PermanentDelete([FromUri]Guid id)
            => _service.PermanentDeleteAsync(id);

        [HttpPost, Route("Seen/{id:guid}")]
        public Task<AppCore.Result> Seen([FromUri]Guid id)
           => _service.SeenAsync(id);

        [HttpPost, Route("Send/{id:guid}")]
        public Task<AppCore.Result> Send([FromUri]Guid id)
            => _service.SendAsync(id);

        [HttpPost, Route("Get/{id:guid}")]
        public Task<AppCore.Result<model.Message>> Get([FromUri]Guid id)
            => _service.GetAsync(id);

        [HttpPost, Route("ListInBox")]
        public Task<AppCore.Result<IEnumerable<model.Message>>> ListInBox(Core.Model.InboxMessageListVM model)
            => _service.ListInBoxAsync(model);

        [HttpPost, Route("ListOutBox")]
        public Task<AppCore.Result<IEnumerable<model.Message>>> ListOutBox(Core.Model.OutboxMessageListVM model)
            => _service.ListOutBoxAsync(model);

        [HttpPost, Route("ListDraft")]
        public Task<AppCore.Result<IEnumerable<model.Message>>> ListDraft(Core.Model.DraftMessageListVM model)
            => _service.ListDraftAsync(model);

    }
}