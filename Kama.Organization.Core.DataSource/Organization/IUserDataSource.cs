using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IUserDataSource : IDataSource
    {
        Task<AppCore.Result<Model.User>> CreateAsync(Model.User model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.User>> UpdateAsync(Model.User model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> VerifyCellPhoneAsync(Guid userID, bool isVerified, AppCore.IActivityLog log);

        Task<AppCore.Result> VerifyEmailAsync(Guid userID, bool isVerified, AppCore.IActivityLog log);

        Task<AppCore.Result> SetPasswordAsync(Guid userId, string newPasswrod, DateTime? passwordExpireDate, AppCore.IActivityLog log);

        Task<AppCore.Result> ModifySettingAsync(Model.UserSetting model);

        Task<AppCore.Result<IEnumerable<Model.User>>> ListAsync(Model.UserListVM model);

        Task<AppCore.Result<Model.User>> GetAsync(Guid? id, string userName, string nationalCode, string email, string password, Guid? applicationId = null);

        Task<AppCore.Result<Model.UserSetting>> GetSettingAsync();

        Task<AppCore.Result<Model.UserModifyValidation>> GetModifyUserValidationAsync(Core.Model.User model);
    }
}