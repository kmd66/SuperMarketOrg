using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace Kama.Organization.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
                                                HttpActionContext actionContext,
                                                CancellationToken cancellationToken,
                                                Func<Task<HttpResponseMessage>> continuation)
        {
            var controllerDoNotValidateAttribute = actionContext
                    .ControllerContext
                    .ControllerDescriptor
                    .GetCustomAttributes<Attributes.DoNotValidateAttribute>()
                    .SingleOrDefault();

            var actionDoNotValidateAttribute = actionContext
                    .ActionDescriptor
                    .GetCustomAttributes<Attributes.DoNotValidateAttribute>()
                    .SingleOrDefault();

            //check whether modelState is valid or not
            if (controllerDoNotValidateAttribute != null
                || actionDoNotValidateAttribute != null
                || actionContext.ModelState.IsValid)
                return await continuation();

            //generate errors
            string errors = String.Join("&&", actionContext.ModelState.Values.Select(s => s.Errors.FirstOrDefault().ErrorMessage));

            return actionContext.Request.CreateResponse(AppCore.Result<Core.Model.Auth>.Failure(-1, errors));
        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}