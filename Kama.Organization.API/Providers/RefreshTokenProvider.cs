using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Kama.Organization.API.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var _refreshTokenService = Kama.Organization.API.IOC.Activator.Container.TryResolve<Core.Service.IRefreshTokenService>();

            var refreshTokenLifeTime = context.OwinContext.Get<string>("clientRefreshTokenLifeTime") ?? "60";
            var refreshTokenId = context.OwinContext.Get<string>("RefreshTokenID");

            Core.Model.RefreshToken refreshToken = null;
            if (!string.IsNullOrWhiteSpace(refreshTokenId))
                refreshToken = (await _refreshTokenService.GetAsync(Guid.Parse(refreshTokenId))).Data;

            AppCore.Result<Core.Model.RefreshToken> result = null;
            if (refreshToken != null && !refreshToken.Expired)
            {
                refreshToken.ExpireDate = DateTime.Now.AddMinutes(Convert.ToDouble(refreshTokenLifeTime));
                result = await _refreshTokenService.EditAsync(refreshToken);
            }
            else
            {
                refreshToken = new Core.Model.RefreshToken()
                {
                    ID = Guid.NewGuid(),
                    UserID = Guid.Parse(context.Ticket.Identity.GetUserId()),
                    IssuedDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
                };

                context.Ticket.Properties.IssuedUtc = refreshToken.IssuedDate.ToUniversalTime();
                context.Ticket.Properties.ExpiresUtc = refreshToken.ExpireDate.ToUniversalTime();

                refreshToken.ProtectedTicket = context.SerializeTicket();

                result = await _refreshTokenService.AddAsync(refreshToken);
            }

            if (result.Success)
                context.SetToken(refreshToken.ID.ToString("n"));
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var _refreshTokenService = Kama.Organization.API.IOC.Activator.Container.TryResolve<Core.Service.IRefreshTokenService>();

            var allowedOrigin = context.OwinContext.Get<string>("clientAllowedOrigin");
            //var allowedOrigin = "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //string hashedTokenId = Library.Helper.Encryption.HashHelper.Instance.GetHash(context.Token);
            context.OwinContext.Set("RefreshTokenID", context.Token);
            Guid tokenId = Guid.Parse(context.Token);

            var getResult = await _refreshTokenService.GetAsync(tokenId);
            if (getResult.Success && getResult.Data != null && !getResult.Data.Expired )
            {
                context.DeserializeTicket(getResult.Data.ProtectedTicket);
                //await _refreshTokenService.DeleteAsync(tokenId);
            }
        }
    }
}