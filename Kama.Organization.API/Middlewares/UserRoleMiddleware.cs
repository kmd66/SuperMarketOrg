//using Microsoft.Owin;
//using System.Threading.Tasks;
//using Owin;
//using System.Security.Claims;
//using System.Linq;
//using System.Threading;
//using System;

//namespace Kama.Organization.API
//{
//    public class UserRoleMiddleware : OwinMiddleware
//    {
//        private readonly Core.Service.IPermissionService _permissionService;

//        public UserRoleMiddleware(OwinMiddleware next, AppCore.IOC.IContainer container)
//            : base(next)
//        {
//            _permissionService = container.Resolve<Core.Service.IPermissionService>();
//        }

//        public override async Task Invoke(IOwinContext context)
//        {
//            if (!context.Authentication.User.Identity.IsAuthenticated)
//                await base.Next.Invoke(context);

//            ClaimsPrincipal principal = Thread.CurrentPrincipal as ClaimsPrincipal;
//            // set permissions on user claims
//            if (principal != null)
//            {
//                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
//                if (identity != null)
//                {
//                    var username = identity.Name;
//                    var userId = identity.GetUserId<Guid>();

//                    // get user permissions
//                    var permittionsResult = await _permissionService.GetSecurityDataAsync(new Core.Model.User { Username = username, ID = userId });

//                    //guid var roleClaims = permittionsResult.Data.Roles.Select(x => new Claim(ClaimTypes.Role, x));
//                    //guid var scopsClaims = permittionsResult.Data.Scopes.Select(x => new Claim("Scope", x.ToString()));
//                    //guid var commandClaims = permittionsResult.Data.Commands.Select(x => new Claim("Command", x.ToString()));

//                    ///guid identity.AddClaims(roleClaims.Union(scopsClaims).Union(commandClaims));

//                    Thread.CurrentPrincipal = principal;
//                }
//            }

//            await base.Next.Invoke(context);
//        }
//    }
//}