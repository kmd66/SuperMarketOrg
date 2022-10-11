//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace Kama.Organization.API.Controllers
//{
//    [RoutePrefix("api/v1/EmailSecurityStamp")]
//    public class EmailSecurityStampController : BaseApiController<Core.Service.IEmailSecurityStampService>
//    {
//        public EmailSecurityStampController(Core.Service.IEmailSecurityStampService service) : base(service)
//        {
//        }

//        [HttpPost, Route("Send")]
//        public Task<AppCore.Result> Send(Core.Model.EmailSecurityStamp model)
//            => _service.SendAsync(model);

//        [HttpPost, Route("Verify")]
//        public Task<AppCore.Result> Verify(Core.Model.EmailSecurityStamp model)
//            => _service.VerifyAsync(model);
//    }
//}