using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using @Model = Kama.Organization.Core.Model;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    internal class UserDataSource : DataSource, Core.DataSource.IUserDataSource
    {
        public UserDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<@Model.User>> ModifyAsync(bool isNewRecord, Model.User model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyUserAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _enabled: model.Enabled,
                    _username: model.Username,
                    _password: model.Password,
                    _passwordExpireDate: model.PasswordExpireDate,
                    _firstName: model.FirstName,
                    _lastName: model.LastName,
                    _nationalCode: model.NationalCode,
                    _email: model.Email,
                    _cellPhone: model.CellPhone,
                    _applicationID: _requestInfo.ApplicationId,
                    _cellPhoneVerified: model.CellPhoneVerified,
                    _emailVerified: model.EmailVerified,
                    _foreigner: model.Foreigner,
                    _log: log?.Value
                    )).ToActionResult<@Model.User>();

                if (result.Success)
                    return await this.GetAsync(model.ID, null, null, null, null);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<@Model.User>> CreateAsync(@Model.User model, AppCore.IActivityLog log)
        {
            model.ID = Guid.NewGuid();
            return await ModifyAsync(true, model, log);
        }

        public async Task<AppCore.Result<@Model.User>> UpdateAsync(@Model.User model, AppCore.IActivityLog log)
        {
            var getModifyUserValidation = await GetModifyUserValidationAsync(model);
            if (!getModifyUserValidation.Success)
                return AppCore.Result<Model.User>.Failure(message: getModifyUserValidation.Message);

            if (getModifyUserValidation.Data.IsCellPhoneChanged) {
                model.CellPhoneVerified = false;
            }

            if (getModifyUserValidation.Data.IsEmailChanged) {
                model.EmailVerified = false;
            }

            return await ModifyAsync(false, model, log);
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeleteUserAsync(
                    _id: id,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> VerifyCellPhoneAsync(Guid userID, bool isVerified, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.VerifyUserCellPhoneAsync(
                    _userID: userID,
                    _isVerified: isVerified,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> VerifyEmailAsync(Guid userID, bool isVerified, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.VerifyUserEmailAsync(
                    _userID: userID,
                    _isVerified: isVerified,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> SetPasswordAsync(Guid userId, string newPasswrod, DateTime? passwordExpireDate, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.SetUserPasswordAsync(
                    _id: userId,
                    _password: newPasswrod,
                    _passwordExpireDate: passwordExpireDate,
                    _log: log?.Value)).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> ModifySettingAsync(Model.UserSetting model)
        {
            try
            {
                var result = (await _dbORG.ModifyUserSettingAsync(
                    _userID: _requestInfo.UserId,
                    _setting: model.Setting
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<@Model.User>>> ListAsync(Model.UserListVM model)
        {
            try
            {
                var result = (await _dbORG.GetUsersAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _nationalCode: model.NationalCode,
                    _name: model.Name,
                    _email: model.Email,
                    _cellphone: model.CellPhone,
                    _enablOrDisable: (byte)model.EnableOrDisable,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<@Model.User>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Model.User>> GetAsync(Guid? id, string userName, string nationalCode, string email, string password, Guid? applicationId = null)
        {
            try
            {
                var result = (await _dbORG.GetUserAsync(
                    _id: id,
                    _userName: userName,
                    _nationalCode: nationalCode,
                    _email: email,
                    _password: password,
                    _applicationID: applicationId ?? _requestInfo.ApplicationId,
                    _currentUserID: _requestInfo.UserId
                    )).ToActionResult<Core.Model.User>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Model.UserSetting>> GetSettingAsync()
        {
            try
            {
                var result = (await _dbORG.GetUserSettingAsync(
                    _userID: _requestInfo.UserId
                )).ToActionResult<Core.Model.UserSetting>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Model.UserModifyValidation>> GetModifyUserValidationAsync(Core.Model.User model)
        {
            try
            {
                var result = (await _dbORG.GetModifyUserValidationAsync(
                    _id: model.ID,
                    _username: model.Username,
                    _nationalCode: model.NationalCode,
                    _email: model.Email,
                    _cellPhone: model.CellPhone
                )).ToActionResult<Core.Model.UserModifyValidation>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}