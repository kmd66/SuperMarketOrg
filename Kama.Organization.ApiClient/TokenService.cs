using Kama.Organization.ApiClient.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kama.Organization.ApiClient.Interface
{
    public interface ITokenService : IService
    {
        Task<AppCore.Result<string>> GetToken(Core.Model.Token model, IDictionary<string, string> httpHeaders = null);

        Task<AppCore.Result<string>> GetRefreshToken(Core.Model.GetRefreshTokenVM model, IDictionary<string, string> httpHeaders = null);
    }
}
namespace Kama.Organization.ApiClient
{
    public class TokenErrorResult
    {
        public string error { get; set; }

        public string error_description { get; set; }
    }

    partial class TokenService : Service, ITokenService
    {
        public TokenService(IOrganizationClient client,
            AppCore.IObjectSerializer objectSerializer)
        {
            _client = client;
            _objectSerializer = objectSerializer;
        }

        readonly IOrganizationClient _client;
        readonly AppCore.IObjectSerializer _objectSerializer;

        public async Task<AppCore.Result<string>> GetToken(Core.Model.Token model, IDictionary<string, string> httpHeaders = null)
        {
            using (var client = new System.Net.Http.HttpClient() { BaseAddress = new Uri(_client.Host) })
            {
                var strContent = $"LoginType={model.LoginType.ToString()}&UserName={model.username}&CellPhone={model.CellPhone}&Email={model.Email}&Password={model.password}&grant_type={model.grant_type}&client_id={model.client_id}&client_secret={model.client_secret}";
                var content = new System.Net.Http.StringContent(strContent, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.PostAsync(requestUri: "token", content: content);
                var strRespContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return AppCore.Result<string>.Successful(data: strRespContent);

                var errorResult = _objectSerializer.Deserialize<TokenErrorResult>(strRespContent);
                return AppCore.Result<string>.Failure(message: errorResult?.error_description ?? "نام کاربری و یا کلمه عبور اشتباه است.");

                //return AppCore.Result<string>.Failure(code:(int)response.StatusCode);
            }

            //return _client.SendAsync<Core.Model.Token>(true, url, routeParamValues, httpHeaders, model);
        }

        public async Task<AppCore.Result<string>> GetRefreshToken(Core.Model.GetRefreshTokenVM model, IDictionary<string, string> httpHeaders = null)
        {
            using (var client = new System.Net.Http.HttpClient() { BaseAddress = new Uri(_client.Host) })
            {
                var strContent = $"grant_type={model.grant_type}&client_id={model.client_id}&client_secret={model.client_secret}&&refresh_token={model.refresh_token}";
                var content = new System.Net.Http.StringContent(strContent, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.PostAsync(requestUri: "token", content: content);
                var strRespContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return AppCore.Result<string>.Successful(data: strRespContent);

                var errorResult = _objectSerializer.Deserialize<TokenErrorResult>(strRespContent);

                if (errorResult?.error?.ToLower() == "invalid_grant")
                    return AppCore.Result<string>.Failure(code: 401, message: errorResult?.error_description ?? "خطای نامشخص.");

                return AppCore.Result<string>.Failure(message: errorResult?.error_description ?? "خطای نامشخص.");

                //return AppCore.Result<string>.Failure(code:(int)response.StatusCode);
            }

            //return _client.SendAsync<Core.Model.Token>(true, url, routeParamValues, httpHeaders, model);
        }

    }
}

