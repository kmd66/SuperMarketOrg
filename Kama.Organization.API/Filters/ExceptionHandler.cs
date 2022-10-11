using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Kama.AppCore;

namespace Kama.Organization.API.Filters
{
    public class ExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            string exceptionMessage = context.Exception.ToMessageString(Core.AppSettings.DeploymentMode);
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.OK, AppCore.Result.Failure(code: -1, message: exceptionMessage)));
            return Task.FromResult(0);
        }
    }
}