using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kama.Organization.API.Controllers
{
    [RoutePrefix("api/v1/User")]
    public class UserController : BaseApiController<Core.Service.IUserService>
    {
        public UserController(Core.Service.IUserService service) : base(service)
        {
        }

        [HttpPost, Route("Add")]
        public Task<AppCore.Result<Core.Model.User>> Add(Core.Model.User model)
            => _service.AddAsync(model);

        [HttpPost, Route("edit")]
        public Task<AppCore.Result<Core.Model.User>> Edit(Core.Model.User model)
            => _service.EditAsync(model);

        [HttpPost, Route("delete/{id:guid}")]
        public Task<AppCore.Result> Delete(Guid id)
            => _service.DeleteAsync(id);

        [HttpPost, Route("EditProfile")]
        public Task<AppCore.Result<Core.Model.User>> EditProfile(Core.Model.UserProfileVM model)
            => _service.EditProfileAsync(model);

        [HttpPost, Route("VerifyCellPhone")]
        public Task<AppCore.Result> VerifyCellPhone(Core.Model.VerifyCellPhoneVM model)
            => _service.VerifyCellPhoneAsync(model);

        [HttpPost, Route("VerifyEmail")]
        public Task<AppCore.Result> VerifyEmail(Core.Model.VerifyEmailVM model)
            => _service.VerifyEmailAsync(model);

        [HttpPost, Route("SendSecurityCodeBySms")]
        public Task<AppCore.Result> SendSecurityCodeBySms(Core.Model.User model)
            => _service.SendSecurityCodeBySmsAsync(model);

        [HttpPost, Route("SendSecurityCodeByEmail")]
        public Task<AppCore.Result> SendSecurityCodeByEmail(Core.Model.User model)
            => _service.SendSecurityCodeByEmailAsync(model);

        [HttpPost, Route("ResetPassword")]
        public Task<AppCore.Result> ResetPassword(Core.Model.User model)
            => _service.ResetPasswordAsync(model);

        [HttpPost, Route("SetPassword")]
        public Task<AppCore.Result> SetPassword(Core.Model.SetPasswordVM model)
            => _service.SetPasswordAsync(model);

        [HttpPost, Route("SetPasswordWithSecuriyStamp")]
        public Task<AppCore.Result> SetPasswordWithSecuriyStamp(Core.Model.SetPasswordWithSecuriyStampVM model)
            => _service.SetPasswordWithSecuriyStampAsync(model);

        [HttpPost, Route("SaveSetting")]
        public Task<AppCore.Result> SaveSetting(Core.Model.UserSetting model)
            => _service.SaveSettingAsync(model);

        [HttpPost, Route("List")]
        public Task<AppCore.Result<IEnumerable<Core.Model.User>>> List(Core.Model.UserListVM model)
            => _service.ListAsync(model);

        [AllowAnonymous]
        [HttpGet, Route("Get/{id:guid}")]
        public Task<AppCore.Result<Core.Model.User>> Get(Guid id)
            => _service.GetAsync(id);

        [HttpGet, Route("Get/{username}")]
        public Task<AppCore.Result<Core.Model.User>> Get(string username)
            => _service.GetAsync(username);

        [HttpPost, Route("GetByNationalCode/{nationalCode}")]
        public Task<AppCore.Result<Core.Model.User>> GetByNationalCode(string nationalCode)
            => _service.GetByNationalCodeAsync(nationalCode);

        [HttpPost, Route("GetByEmail/{email}")]
        public Task<AppCore.Result<Core.Model.User>> GetByEmail(string email)
            => _service.GetByEmailAsync(email);

        [HttpPost, Route("GetSetting")]
        public Task<AppCore.Result<Core.Model.UserSetting>> GetSetting()
            => _service.GetSettingAsync();
    }
}