//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace Kama.Organization.API.Controllers
//{
//    [RoutePrefix("api/v1/SmsSecurityStamp")]
//    public class SmsSecurityStampController : BaseApiController<Core.Service.ISmsSecurityStampService>
//    {
//        public SmsSecurityStampController(Core.Service.ISmsSecurityStampService service) : base(service)
//        {
//        }

//        [HttpPost, Route("Send")]
//        public Task<AppCore.Result> Send(Core.Model.SmsSecurityStamp model)
//            => _service.SendAsync(model);

//        [HttpPost, Route("Verify")]
//        public Task<AppCore.Result> Verify(Core.Model.SmsSecurityStamp model)
//            => _service.VerifyAsync(model);
//    }
//}