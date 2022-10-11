//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Config = System.Configuration.ConfigurationManager;
//using Kama.Library.Helper.Security;

//namespace Kama.Organization.Domain.Services
//{
//    class SmsSecurityStampService : Service<Core.DataSource.ISecurityStampDataSource>, Core.Service.ISmsSecurityStampService
//    {
//        public SmsSecurityStampService(AppCore.IOC.IContainer container,
//            Core.Service.ISmsService smsService)
//            : base(container)
//        {
//            _smsService = smsService;
//        }

//        private readonly Core.Service.ISmsService _smsService;

//        public async Task<AppCore.Result> SendAsync(Core.Model.SmsSecurityStamp model)
//        {
//            model.Stamp = Guid.NewGuid().ToString();
//            var result = await _dataSource.SetByCellPhoneAsync(model);
//            if (!result.Success)
//                return result;

//            model.Stamp = model.Stamp.GetDigitsFromString(0, 6);

//            // send message to user
//            var sendNotifyResult = await _SendUserNotificationAsync(model, Core.Model.UserNotificationTemplate.ResetPassword, true);
//            if (!sendNotifyResult.Success)
//                return sendNotifyResult;

//            return result;
//        }

//        public async Task<AppCore.Result> VerifyAsync(Core.Model.SmsSecurityStamp model)
//        {
//            int validTime = Int32.Parse(Config.AppSettings["SecurityStampValidTime"]);

//            var result = await _dataSource.GetByCellPhoneAsync(model.CellPhone);
//            if (!result.Success)
//                return result;
//            var persistedModel = result.Data;

//            string aesEncryptionPass = Config.AppSettings["AesEncryptionPassword"];
//            var stamp = persistedModel.Stamp.GetDigitsFromString(0, 6);

//            if (persistedModel == null || stamp != model.Stamp)
//                return AppCore.Result.Failure(message: "کد امنیتی ارسال شده معتبر نیست");

//            // check for valid time
//            if (persistedModel.CreationDate.AddSeconds(validTime) < DateTime.Now)
//                return AppCore.Result.Failure(message: "کد امنیتی ارسال شده منقضی شده است");

//            return AppCore.Result.Successful();
//        }

//        // private 
//        private async Task<AppCore.Result> _SendUserNotificationAsync(Core.Model.SmsSecurityStamp model, Core.Model.UserNotificationTemplate userNotificationTemplat, bool mandatory = false)
//        {
//            var smsTemplateFilePath = UserNotificationHelper.GetTemplateFilePath($"{userNotificationTemplat.ToString()}.txt", _requestInfo);

//            if (mandatory && !File.Exists(smsTemplateFilePath))
//                return AppCore.Result.Failure(message: "قالب مورد نظر برای ارسال پیامک یافت نشد");

//            if(string.IsNullOrEmpty(model.CellPhone))   // ??? verify cellphone
//                return AppCore.Result.Failure(message: "شماره تلفن همراه مورد نظر معتبر نیست.");

//            if (File.Exists(smsTemplateFilePath))
//            {
//                var message = new Kama.SmsService.Core.Model.Message
//                {
//                    ReceiverNumbers = new List<string> { model.CellPhone },
//                    Content = UserNotificationHelper.RenderTemplateWithModel(smsTemplateFilePath, model, _requestInfo),
//                    Priority = Kama.SmsService.Core.Model.Priority.VeryHigh
//                };

//                await _smsService.SendAsync(message);
//            }

//            return AppCore.Result.Successful();
//        }

//    }
//}