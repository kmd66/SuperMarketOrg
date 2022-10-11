using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AppActivator = Kama.Organization.API.IOC.Activator;
using Kama.Library.Helper.Security;

namespace Kama.Organization.API.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context
                //if you want to force sending clientId/secrects once obtain access tokens.
                context.Validated();
                context.SetError("invalid_clientId", "کد امنیتی برنامه باید ارسال شود.");
                return;
            }

            var _clientService = AppActivator.Container.TryResolve<Core.Service.IClientService>();
            var clientResult = await _clientService.GetAsync(Guid.Parse(context.ClientId));
            if (!clientResult.Success)
            {
                context.SetError("invalid_clientId", "دریافت اطلاعات برنامه کاربردی با خطا مواجه شد.");
                return;
            }
            var client = clientResult.Data;

            if (client == null)
            {
                context.SetError("invalid_app", $"برنامه '{context.ClientId}' در سیستم ثبت نشده.");
                return;
            }

            if (client.Type == Core.Model.ClientType.Native)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_secret", "کد امنیتی برنامه باید ارسال شود.");
                    return;
                }
                else
                {
                    if (clientSecret != Library.Helper.Encryption.HashHelper.Instance.GetHash(client.Secret))
                    {
                        context.SetError("invalid_secret", "کد امنیتی برنامه نا معتبر است.");
                        return;
                    }
                }
            }

            if (!(client.Enabled && client.ApplicationEnabled))
            {
                context.SetError("invalid_app", "برنامه غیر فعال است.");
                return;
            }

            context.OwinContext.Set("clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set("clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());
            context.OwinContext.Set("ApplicationID", client.ApplicationID.ToString());
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowOrgin = context.OwinContext.Get<string>("clientAllowedOrigin") ?? "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowOrgin });

            var applicationId = Guid.Parse(context.OwinContext.Get<string>("ApplicationID"));
            var zone = context.OwinContext.Get<string>("Zone");

            var token = new Core.Model.Token();
            var form = await context.Request.ReadFormAsync();

            byte loginTypeValue = 0;
            byte.TryParse(form["LoginType"], out loginTypeValue);
            token.LoginType = (Core.Model.LoginType)loginTypeValue;

            token.username = context.UserName;
            token.password = context.Password;

            token.CellPhone = form["CellPhone"];
            token.Email = form["Email"];
            token.SecurityStamp = form["SecurityStamp"];

            var _userService = AppActivator.Container.TryResolve<Core.Service.IUserService>();

            Core.Model.User user = null;
            switch (token.LoginType)
            {
                case Core.Model.LoginType.Unknown:
                case Core.Model.LoginType.نام_کاربری_و_کلمه_عبور:
                    var password = token.password.HashText();
                    var userResult = await _userService.GetAsync(token.username, password, applicationId);
                    user = userResult.Data;
                    break;
                //case Core.Model.LoginType.تلفن_همراه_و_کلمه_عبور:
                //    var userResult = await _userService.GetAsync(token.UserName, token.Password);
                //    loggedInUser = userResult.Data;
                //    break;
                case Core.Model.LoginType.تلفن_همراه_و_کد_امنیتی:
                    //var _smsSecurityStampService = AppActivator.Container.TryResolve<Core.Service.ISmsSecurityStampService>();
                    //var stampResult = await _smsSecurityStampService.VerifyAsync(new Core.Model.SmsSecurityStamp { CellPhone = token.CellPhone, Stamp = token.SecurityStamp });
                    //if (!stampResult.Success)
                    //{
                    //    context.SetError("invalid_user", "کد امنیتی اشتباه است.");
                    //    return;
                    //}

                    //var userListResult = await _userService.ListAsync(new Core.Model.UserListVM { CellPhone = token.CellPhone });
                    //if (!userListResult.Success || userListResult.Data == null || userListResult.Data.ToList().Count() == 0)
                    //{
                    //    context.SetError("invalid_user", "کاربری با مشخصات واردشده یافت نشد.");
                    //    return;
                    //}
                    //else if (userListResult.Data.ToList().Count() > 1)
                    //{
                    //    context.SetError("invalid_user", "امکان ورود به سامانه با این شماره تلفن همراه وجود ندارد.");
                    //    return;
                    //}
                    //user = userListResult.Data.FirstOrDefault();
                    break;
            };

            if (user == null)
            {
                context.SetError("invalid_user", "کاربری با مشخصات واردشده یافت نشد.");
                return;
            }

            if (!user.Enabled)
            {
                context.SetError("invalid_user", "کاربر مورد نظر غیرفعال می باشد.");
                return;
            }

            //get loggedin user's positions
            var _positionService = AppActivator.Container.TryResolve<Core.Service.IPositionService>();
            var getDefaultPositionResult = await _positionService.GetDefaultPosition(applicationId, user.ID);
            if (!getDefaultPositionResult.Success)
            {
                context.SetError("invalid_user", getDefaultPositionResult.Message);
                return;
            }
            var defaultPosition = getDefaultPositionResult.Data;

            var claims = new List<Claim>
            {
                new Claim(type: ClaimTypes.Name, value: user.Username??""),
                new Claim(type: ClaimTypes.NameIdentifier, value: user.ID.ToString()),
                new Claim(type: AppCore.Claims.ApplicationId, value: applicationId.ToString()),
                new Claim(type: AppCore.Claims.ClientId, value: context.ClientId),
                new Claim(type: AppCore.Claims.DepartmentId, value: defaultPosition.DepartmentID.ToString()),
                new Claim(type: AppCore.Claims.DepartmentType, value: defaultPosition.DepartmentType.ToString("d")),
                new Claim(type: AppCore.Claims.ProvinceId, value: defaultPosition.ProvinceID.ToString()),
                new Claim(type: AppCore.Claims.PositionId, value: defaultPosition.ID.ToString()),
                new Claim(type: AppCore.Claims.PositionType, value: defaultPosition.Type.ToString("d")),
                new Claim(type: AppCore.Claims.UserId, value: user.ID.ToString()),
                new Claim(type: AppCore.Claims.UserType, value: defaultPosition.UserType.ToString("d"))
            };

            var identity = new ClaimsIdentity(claims, context.Options.AuthenticationType);

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "as:client_id", context.ClientId ?? string.Empty
                    },
                    {
                        "username", user.Username??""
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
        //test
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            //var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            //var currentClient = context.ClientId;

            context.Ticket.Properties.Dictionary["as:client_id"] = context.ClientId;
            //if (originalClient != currentClient)
            //{
            //    context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
            //    return Task.FromResult<object>(null);
            //}

            var applicationId = Guid.Parse(context.OwinContext.Get<string>("ApplicationID"));

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            var userId = Guid.Parse(newIdentity.GetUserId());

            var _positionService = AppActivator.Container.TryResolve<Core.Service.IPositionService>();
            var getDefaultPositionResult = await _positionService.GetDefaultPosition(applicationId, userId);
            if (!getDefaultPositionResult.Success)
            {
                context.SetError("invalid_user", getDefaultPositionResult.Message);
                return;
            }
            var defaultPosition = getDefaultPositionResult.Data;

            ReplaceClaim(newIdentity, AppCore.Claims.ApplicationId, applicationId.ToString());
            ReplaceClaim(newIdentity, AppCore.Claims.ClientId, context.ClientId);
            ReplaceClaim(newIdentity, AppCore.Claims.PositionId, defaultPosition.ID.ToString());
            ReplaceClaim(newIdentity, AppCore.Claims.PositionType, defaultPosition.Type.ToString("d"));
            ReplaceClaim(newIdentity, AppCore.Claims.DepartmentId, defaultPosition.DepartmentID.ToString());
            ReplaceClaim(newIdentity, AppCore.Claims.DepartmentType, defaultPosition.DepartmentType.ToString("d"));
            ReplaceClaim(newIdentity, AppCore.Claims.ProvinceId, defaultPosition.ProvinceID.ToString());
            ReplaceClaim(newIdentity, AppCore.Claims.UserType, defaultPosition.UserType.ToString("d"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            //return Task.FromResult<object>(null);
        }

        void ReplaceClaim(ClaimsIdentity identity, string type, string value)
        {
            var oldClaim = identity.Claims.FirstOrDefault(c => c.Type == type);
            identity.RemoveClaim(oldClaim);
            identity.AddClaim(new Claim(type: type, value: value));
        }
    }
}