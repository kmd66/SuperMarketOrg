using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;
using Kama.Organization.Core.Service;

namespace Kama.Organization.API.Filters
{
    public class CheckPermissionFilter : IAuthorizationFilter
    {
        IPositionService _positionService;

        public CheckPermissionFilter(IPositionService positionService)
        { 
            _positionService = positionService;
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            //if (Core.AppSettings.DeploymentMode == AppCore.DeploymentMode.Development)
            //    return await continuation();

            var checkPermissionAttribute = actionContext
                .ActionDescriptor
                .GetCustomAttributes<Attributes.CheckPermissionAttribute>()
                .SingleOrDefault();

            if (checkPermissionAttribute == null)
                return await continuation();

            //Guid userId = actionContext.RequestContext.Principal.Identity.GetUserId<Guid>();
            Guid commandId = Core.Commands.GetCommandID(checkPermissionAttribute.Command);
            var checkPermissionResult = await _positionService.CheckPermission(commandId: commandId);
            if (!checkPermissionResult.Success)
                return actionContext.Request.CreateResponse(HttpStatusCode.NonAuthoritativeInformation, AppCore.Result<Core.Model.Auth>.Failure(-1, "شما مجوز انجام این عملیات را ندارید."));

            if (checkPermissionResult.Data)
                return await continuation();

            return actionContext.Request.CreateResponse(HttpStatusCode.NonAuthoritativeInformation, AppCore.Result<Core.Model.Auth>.Failure(-1, "شما مجوز انجام این عملیات را ندارید."));
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}