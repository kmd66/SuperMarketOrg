using System;
using System.Collections.Generic;
using System.Web.Http;
using Kama.Organization.Core.Service;
using System.Reflection;
using System.Web.Http.Controllers;

namespace Kama.Organization.API.Controllers
{
    //[Authorize]
    //[Library.Helper.Log.Attributes.ActivityLog]
    public class BaseApiController<T> : ApiController
        where T : IService
    {
        public BaseApiController(T service)
        {
            _service = service;
        }

        protected readonly T _service;

        [HttpGet, Route("Run")]
        public IHttpActionResult Run()
        {
            return Ok();
        }
    }
}
