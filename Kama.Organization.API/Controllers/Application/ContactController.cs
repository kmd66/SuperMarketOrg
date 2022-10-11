using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    using model = Core.Model;

    [RoutePrefix("api/v1/Contact")]
    public class ContactController : BaseApiController<Core.Service.IContactService>
    {
        public ContactController(Core.Service.IContactService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<model.Contact>> Add(model.Contact contact)
                 => _service.AddAsync(contact);

        [HttpPost, Route("SetArchive")]
        public Task<AppCore.Result<model.Contact>> SetArchive(Guid id)
             => _service.SetArchiveAsync(id);

        [HttpPost, Route("SetUnArchive")]
        public Task<AppCore.Result<model.Contact>> SetUnArchive(Guid id)
             => _service.SetUnArchiveAsync(id);

        [HttpPost, Route("SetNote")]
        public Task<AppCore.Result<model.Contact>> SetNote(model.Contact contact)
       => _service.SetNoteAsync(contact);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<model.Contact>>> List(model.ContactListVM model)
            => _service.ListAsync(model);

        [HttpGet, Route("Get/{Id:guid}")]
        public Task<AppCore.Result<model.Contact>> Get([FromUri]Guid Id)
            => _service.GetAsync(Id);
    }
}