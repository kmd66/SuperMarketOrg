using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Kama.Organization.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //if (actionContext.Request.Headers.Any(h => h.Key == "Authorization")  // has token
            //    && !HttpContext.Current.User.Identity.IsAuthenticated)           // expired
            //{
            //    HttpResponseMessage response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NonAuthoritativeInformation, AppCore.Result.Failure(-397, "توکن منقضی شده است."));
            //    actionContext.Response = response;
            //    return;
            //}

            //if (Core.AppSettings.DeploymentMode == AppCore.DeploymentMode.Development
            //    && Core.AppSettings.BypassAuthorization)
            //    return;

            base.OnAuthorization(actionContext);
        }
    }
}