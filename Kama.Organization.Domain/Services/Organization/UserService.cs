using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kama.Library.Helper;
using Kama.Library.Helper.Security;
using Kama.Organization.Core;
using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;
using System.Text.RegularExpressions;

namespace Kama.Organization.Domain.Services
{
    class UserService : Service<Core.DataSource.IUserDataSource>, Core.Service.IUserService
    {
        public UserService(AppCore.IOC.IContainer container,
            IPasswordBlackListDataSource passwordBlackListDataSource
            )
            : base(container)
        {
            _passwordBlackListDataSource = passwordBlackListDataSource;
        }

        readonly IPasswordBlackListDataSource _passwordBlackListDataSource;

        public async Task<AppCore.Result<Core.Model.User>> AddAsync(Core.Model.User model)
        {
            try
            {
                var validationResult = await _ValidateForSaveAsync(model);
                if (!validationResult.Success)
                    return AppCore.Result<Core.Model.User>.Failure(message: validationResult.Message);

                if (string.IsNullOrEmpty(model.Username))
                    model.Username = model.NationalCode;

                if (string.IsNullOrWhiteSpace(model.Password))
                    model.Password = model.NationalCode;
                else if (!_CheckPassword(model.Password))
                    return AppCore.Result<User>.Failure(message: "رمز عبور باید بیش از 8 کاراکتر بوده و تر کیبی از حروف بزرگ، کوچک، اعداد وعلائم باشد");

                model.Enabled = true;
                model.CellPhoneVerified = true;
                model.EmailVerified = false;
                model.Password = model.Password.HashText();
                model.PasswordExpireDate = DateTime.Now.AddMonths(6);

                return await _dataSource.CreateAsync(model, null);
            }
            catch (Exception ex)
            {
                return AppCore.Result<Core.Model.User>.Failure(message: ex.Message);
            }
        }

        public async Task<AppCore.Result<Core.Model.User>> EditAsync(Core.Model.User model)
        {
            var validationResult = await _ValidateForSaveAsync(model);
            if (!validationResult.Success)
                return AppCore.Result<Core.Model.User>.Failure(message: validationResult.Message);

            return await _dataSource.UpdateAsync(model, null);
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id)
            => await _dataSource.DeleteAsync(id, null);

        public async Task<AppCore.Result<Core.Model.User>> EditProfileAsync(Core.Model.UserProfileVM model)
        {
            var getResult = await GetAsync((Guid)_requestInfo.UserId);
            if (!getResult.Success)
                return getResult;
            var userModel = getResult.Data;

            userModel.Username = model.Username;
            userModel.FirstName = model.FirstName;
            userModel.LastName = model.LastName;
            userModel.CellPhone = model.CellPhone;
            userModel.Email = model.Email;

            return await _dataSource.UpdateAsync(userModel, null);
        }

        public async Task<AppCore.Result> VerifyCellPhoneAsync(Core.Model.VerifyCellPhoneVM model)
        {
            var cellphone = model.CellPhone;
            if (cellphone == null)
            {
                var getResult = await this.GetAsync(model.ID);
                if (!getResult.Success)
                    return getResult;

                cellphone = getResult.Data.CellPhone;
            }

            //var stampResult = await _smsSecurityStampService.VerifyAsync(new Core.Model.SmsSecurityStamp { CellPhone = cellphone, Stamp = model.SecurityStamp });
            //if (!stampResult.Success)
            //    return stampResult;

            return await _dataSource.VerifyCellPhoneAsync(model.ID, true, null);
        }

        public async Task<AppCore.Result> VerifyEmailAsync(Core.Model.VerifyEmailVM model)
        {
            //var stampResult = await _emailSecurityStampService.VerifyAsync(new Core.Model.EmailSecurityStamp { Email = model.Email, Stamp = model.SecurityStamp });
            //if (!stampResult.Success)
            //    return stampResult;

            return await _dataSource.VerifyEmailAsync(model.ID, true, null);
        }

        public async Task<AppCore.Result> SendSecurityCodeBySmsAsync(Core.Model.User model)
        {
            Core.Model.User user = null;
            if (model.ID == Guid.Empty)
            {
                var getResult = await this.GetAsync(model.Username);
                if (!getResult.Success)
                    return getResult;
                user = getResult.Data;
            }
            else
            {
                var getResult = await this.GetAsync(model.ID);
                if (!getResult.Success)
                    return getResult;
                user = getResult.Data;
            }

            if (string.IsNullOrEmpty(user.CellPhone))
                return AppCore.Result.Failure(message: "برای کاربر مورد نظر شماره تلفن همراه ثبت نشده است.");

            return AppCore.Result.Failure(message: "برای کاربر مورد نظر شماره تلفن همراه ثبت نشده است.");
        }

        public async Task<AppCore.Result> SendSecurityCodeByEmailAsync(Core.Model.User model)
        {
            Core.Model.User user = null;
            if (model.ID == Guid.Empty)
            {
                var getResult = await this.GetAsync(model.Username);
                if (!getResult.Success)
                    return getResult;
                user = getResult.Data;
            }
            else
            {
                var getResult = await this.GetAsync(model.ID);
                if (!getResult.Success)
                    return getResult;
                user = getResult.Data;
            }

            if (string.IsNullOrEmpty(user.Email))
                return AppCore.Result.Failure(message: "برای کاربر مورد نظر ایمیل ثبت نشده است.");

            return AppCore.Result.Failure(message: "برای کاربر مورد نظر ایمیل ثبت نشده است.");
        }

        public async Task<AppCore.Result> ResetPasswordAsync(Core.Model.User model)
        {
            var userResult = await GetAsync(model.ID, "");
            if (!userResult.Success)
                return AppCore.Result.Failure(message: userResult.Message);
            var user = userResult.Data;

            if (user == null)
                return AppCore.Result.Failure(message: "کاربری با این مشخصات وجود ندارد");

            user.Password = user.NationalCode.HashText();
            var setPassResult = await _dataSource.SetPasswordAsync(user.ID, user.Password, DateTime.Now.AddMonths(-1), null);
            if (!setPassResult.Success)
                return setPassResult;

            var sendNotifyResult = await _SendUserNotificationsAsync(user, Core.Model.UserNotificationTemplate.PasswordChanged, "تغییر کلمه عبور");
            if (!sendNotifyResult.Success)
                return sendNotifyResult;

            return AppCore.Result.Successful();
        }

        public async Task<AppCore.Result> SetPasswordAsync(Core.Model.SetPasswordVM model)
        {
            var getPasswordBlackListResult = await _passwordBlackListDataSource.GetPasswordBlackListAsync(new PasswordBlackListVm { Password = model.NewPassword.HashText() });
            if (!getPasswordBlackListResult.Success)
                return getPasswordBlackListResult;
            var getPasswordData = getPasswordBlackListResult.Data;

            if (!_CheckPassword(model.NewPassword))
                return AppCore.Result.Failure(message: "رمز عبور باید بیش از 8 کاراکتر بوده و تر کیبی از حروف بزرگ، کوچک، اعداد وعلائم باشد");


            if (!(getPasswordData is null))
                return AppCore.Result.Failure(message: "رمز وارد شده مورد قبول نمیباشد.");

            if (_requestInfo.UserName == model.NewPassword)
                return AppCore.Result.Failure(message: "نام کاربری نباید با کلمه عبور یکسان باشد");

            if (model.NewPassword == model.OldPassword)
                return AppCore.Result.Failure(message: "کلمه عبور جدید نباید با کلمه عبور قبلی یکسان باشد");

            var oldPassword = model.OldPassword.HashText();

            var userResult = await GetAsync((Guid)_requestInfo.UserId, oldPassword);
            if (!userResult.Success)
                return AppCore.Result.Failure(message: userResult.Message);
            var user = userResult.Data;

            if (user == null)
                return AppCore.Result.Failure(message: "کلمه عبور فعلی اشتباه است");

            model.NewPassword = model.NewPassword.HashText();
            var setPassResult = await _dataSource.SetPasswordAsync((Guid)_requestInfo.UserId, model.NewPassword, null, null);
            if (!setPassResult.Success)
                return setPassResult;

            await _SendUserNotificationsAsync(user, Core.Model.UserNotificationTemplate.PasswordChanged);

            return AppCore.Result.Successful();
        }

        public async Task<AppCore.Result> SetPasswordWithSecuriyStampAsync(Core.Model.SetPasswordWithSecuriyStampVM model)
        {
            if (_requestInfo.UserName == model.Password)
                return AppCore.Result.Failure(message: "نام کاربری نباید با کلمه عبور یکسان باشد");

            if (model.SecurityStamp.Length > 20)
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    var getResult = await this.GetAsync(id: model.ID);
                    if (!getResult.Success)
                        return getResult;
                    model.Email = getResult.Data.Email;
                }

                //var stampResult = await _emailSecurityStampService.VerifyAsync(new Core.Model.EmailSecurityStamp { Email = model.Email, Stamp = model.SecurityStamp });
                //if (!stampResult.Success)
                //    return stampResult;
            }
            else
            {
                if (string.IsNullOrEmpty(model.CellPhone))
                {
                    var getResult = await this.GetAsync(id: model.ID);
                    if (!getResult.Success)
                        return getResult;
                    model.CellPhone = getResult.Data.CellPhone;
                }

                //var stampResult = await _smsSecurityStampService.VerifyAsync(new Core.Model.SmsSecurityStamp { CellPhone = model.CellPhone, Stamp = model.SecurityStamp });
                //if (!stampResult.Success)
                //    return stampResult;
            }

            model.Password = model.Password.HashText();

            var setPassResult = await _dataSource.SetPasswordAsync(model.ID, model.Password, null, null);
            if (!setPassResult.Success)
                return setPassResult;

            return await _dataSource.VerifyCellPhoneAsync(model.ID, true, null);    // verify cellphone
        }

        public async Task<AppCore.Result> SaveSettingAsync(Core.Model.UserSetting model)
        {
            return await _dataSource.ModifySettingAsync(model);
        }
        public Task<AppCore.Result<IEnumerable<Core.Model.User>>> ListAsync(Core.Model.UserListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.User>> GetAsync(Guid id)
        {
            return _dataSource.GetAsync(id, null, null, null, null);
        }

        public Task<AppCore.Result<Core.Model.User>> GetAsync(Guid id, string password)
        {
            return _dataSource.GetAsync(id, null, null, null, password);
        }

        public Task<AppCore.Result<Core.Model.User>> GetAsync(string userName)
        {
            return _dataSource.GetAsync(null, userName, null, null, null);
        }

        public Task<AppCore.Result<Core.Model.User>> GetAsync(string userName, string password, Guid? applicationId)
        {
            return _dataSource.GetAsync(null, userName, null, null, password, applicationId);
        }

        public Task<AppCore.Result<Core.Model.User>> GetByNationalCodeAsync(string nationalCode)
        {
            return _dataSource.GetAsync(null, null, nationalCode, null, null);
        }

        public Task<AppCore.Result<Core.Model.User>> GetByEmailAsync(string email)
        {
            return _dataSource.GetAsync(null, null, null, email, null);
        }

        public async Task<AppCore.Result<Core.Model.UserSetting>> GetSettingAsync()
        {
            var getSettings = await _dataSource.GetSettingAsync();
            if (!getSettings.Success)
                return getSettings;

            return getSettings;
        }

        // privates

        private async Task<AppCore.Result> _SendUserNotificationsAsync(Core.Model.User model, Core.Model.UserNotificationTemplate userNotificationTemplat, string emailSubject = "")
        {
            var Async = new
            {
                sendUserNotifyBySmsAsync = _SendUserNotificationBySmsAsync(model, userNotificationTemplat),
                sendUserNotifyByMailAsync = _SendUserNotificationByEmailAsync(model, userNotificationTemplat, emailSubject)
            };

            var sendUserNotifyBySmsResult = await Async.sendUserNotifyBySmsAsync;
            if (!sendUserNotifyBySmsResult.Success)
                return sendUserNotifyBySmsResult;

            var sendUserNotifyByMailResult = await Async.sendUserNotifyByMailAsync;
            if (!sendUserNotifyByMailResult.Success)
                return sendUserNotifyByMailResult;

            return AppCore.Result.Successful();
        }

        private async Task<AppCore.Result> _SendUserNotificationBySmsAsync(Core.Model.User model, Core.Model.UserNotificationTemplate userNotificationTemplat, bool mandatory = false)
        {
            var smsTemplateFilePath = UserNotificationHelper.GetTemplateFilePath($"{userNotificationTemplat.ToString()}.txt", _requestInfo);

            if (mandatory && !File.Exists(smsTemplateFilePath))
                return AppCore.Result.Failure(message: "قالب مورد نظر برای ارسال پیامک یافت نشد");

            //if (File.Exists(smsTemplateFilePath))
            //{
            //    await _smsService.SendAsync(
            //        new Kama.SmsService.Core.Model.Message
            //        {
            //            ReceiverNumbers = new List<string> { model.CellPhone },
            //            Content = UserNotificationHelper.RenderTemplateWithModel<Core.Model.User>(smsTemplateFilePath, model, _requestInfo),
            //            Priority = Kama.SmsService.Core.Model.Priority.VeryHigh
            //        }
            //    );
            //}

            return AppCore.Result.Successful();
        }

        private async Task<AppCore.Result> _SendUserNotificationByEmailAsync(Core.Model.User model, Core.Model.UserNotificationTemplate userNotificationTemplat, string subject, bool mandatory = false)
        {
            var mailTemplateFilePath = UserNotificationHelper.GetTemplateFilePath($"{userNotificationTemplat.ToString()}.html", _requestInfo);

            if (mandatory && !File.Exists(mailTemplateFilePath))
                return AppCore.Result.Failure(message: "قالب مورد نظر برای ارسال ایمیل یافت نشد");

            //if (File.Exists(mailTemplateFilePath))
            //{
            //    await _mailService.Send(
            //        new MailService.Core.Model.Mail()
            //        {
            //            Content = UserNotificationHelper.RenderTemplateWithModel<Core.Model.User>(mailTemplateFilePath, model, _requestInfo),
            //            SourceAccount = Kama.MailService.Core.Model.MailServiceAccounts.Azmoon,
            //            Priority = Kama.MailService.Core.Model.Priority.Normal,
            //            Subject = subject,
            //            EmailReceivers = new List<Kama.MailService.Core.Model.MailReceiverDetail> { new Kama.MailService.Core.Model.MailReceiverDetail { Email = model.Email } }
            //        }
            //    );
            //}

            return AppCore.Result.Successful();
        }

        private async Task<AppCore.Result> _ValidateForSaveAsync(Core.Model.User model)
        {
            var getModifyUserValidation = await _dataSource.GetModifyUserValidationAsync(model);
            if (!getModifyUserValidation.Success)
                return getModifyUserValidation;
            var validation = getModifyUserValidation.Data;

            List<string> errors = new List<string>();

            if (!string.IsNullOrEmpty(model.NationalCode))
            {
                model.NationalCode = model.NationalCode.Trim();

                if (!model.Foreigner)
                {
                    if (model.NationalCode.Length != 10          // کد ملی افراد حقیقی  
                        && model.NationalCode.Length != 11      // شناسه حقوقی افراد حقوقی
                        && model.NationalCode.Length != 18)     // شناسه حقوقی سازمان تامین اجتماعی و ... که علاوه بر شناسه حقوقی موارد دیگری به آنها اضافه می شود
                    {
                        if (_requestInfo.Application == Core.ApplicationEnum.سامانه_هیات_موضوع_ماده_251_مکرر_قانون_مالیاتهای_مستقیم
                            && model.NationalCode.Length > 10)
                            errors.Add("شناسه ملی وارد شده معتبر نیست");
                        else
                            errors.Add("کد ملی وارد شده معتبر نیست");
                    }

                    if (model.NationalCode.Length == 10)    // کد ملی افراد حقیقی
                    {
                        if (!model.NationalCode.IsValidNationalCode())
                            errors.Add("کد ملی وارد شده معتبر نیست");
                    }
                }
            }

            if (getModifyUserValidation.Data.IsUserNameRepeated)
                errors.Add("شناسه کاربری تکراری می باشد");

            if (getModifyUserValidation.Data.IsNationalCodeRepeated)
            {
                if (_requestInfo.Application == Core.ApplicationEnum.سامانه_هیات_موضوع_ماده_251_مکرر_قانون_مالیاتهای_مستقیم
                    && model.NationalCode.Length > 10)
                    errors.Add("شناسه ملی تکراری می باشد");
                else
                    errors.Add("کد ملی تکراری می باشد");
            }

            if (model.CellPhone == null)
                errors.Add("تلفن همراه ثبت نشده است");

            if (_requestInfo.Application == ApplicationEnum.سامانه_تشخیص_صلاحیت_حرفه_ای_حسابداران_رسمی)
            {
                if (getModifyUserValidation.Data.IsEmailRepeated)
                    errors.Add("ایمیل تکراری می باشد");

                if (getModifyUserValidation.Data.IsCellphoneRepeated)
                    errors.Add("تلفن همراه تکراری می باشد");
            }

            if (errors.Count > 0)
                return AppCore.Result.Failure(message: string.Join("&&", errors));

            return AppCore.Result.Successful();
        }

        private bool _CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)
                || password.Length < 7)
                return false;
            if (!Regex.Match(password, @"^(?=.*[^\da-zA-Z])", RegexOptions.ECMAScript).Success)
                return false;
            if (!Regex.Match(password, @"^(?=.*\d)", RegexOptions.ECMAScript).Success)
                return false;
            if (!Regex.Match(password, @"^(?=.*[A-Z])", RegexOptions.ECMAScript).Success)
                return false;
            if (!Regex.Match(password, @"^(?=.*[a-z])", RegexOptions.ECMAScript).Success)
                return false;
            return true;
        }
    }
}