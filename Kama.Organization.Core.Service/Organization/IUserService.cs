using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IUserService : IService
    {
        Task<AppCore.Result<User>> AddAsync(User model);

        Task<AppCore.Result<User>> EditAsync(User user);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result<Core.Model.User>> EditProfileAsync(Core.Model.UserProfileVM model);

        Task<AppCore.Result> VerifyCellPhoneAsync(Core.Model.VerifyCellPhoneVM model);

        Task<AppCore.Result> VerifyEmailAsync(Core.Model.VerifyEmailVM model);

        Task<AppCore.Result> SendSecurityCodeBySmsAsync(@Model.User model);

        Task<AppCore.Result> SendSecurityCodeByEmailAsync(@Model.User model);

        Task<AppCore.Result> ResetPasswordAsync(User model);

        Task<AppCore.Result> SetPasswordAsync(SetPasswordVM model);

        Task<AppCore.Result> SetPasswordWithSecuriyStampAsync(Model.SetPasswordWithSecuriyStampVM model);

        Task<AppCore.Result> SaveSettingAsync(Model.UserSetting model);

        Task<AppCore.Result<IEnumerable<User>>> ListAsync(Model.UserListVM model);

        Task<AppCore.Result<User>> GetAsync(Guid id);

        Task<AppCore.Result<User>> GetAsync(string username);

        Task<AppCore.Result<User>> GetAsync(string username, string password, Guid? applicationId);

        Task<AppCore.Result<Core.Model.User>> GetByNationalCodeAsync(string nationalCode);

        Task<AppCore.Result<Core.Model.User>> GetByEmailAsync(string email);

        Task<AppCore.Result<Model.UserSetting>> GetSettingAsync();

    }
}