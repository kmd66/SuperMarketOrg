//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Config = System.Configuration.ConfigurationManager;
//using System.Linq;
//using Kama.Library.Helper;
//using Kama.Library.Helper.Security;

//namespace Kama.Organization.Domain.Services
//{
//    class EmailSecurityStampService : Service<Core.DataSource.ISecurityStampDataSource>, Core.Service.IEmailSecurityStampService
//    {
//        public EmailSecurityStampService(AppCore.IOC.IContainer container)
//            : base(container)
//        {
//            _mailService = mailService;
//        }

//        private readonly MailService.ApiClient.Interface.IMailService _mailService;

//        public async Task<AppCore.Result> SendAsync(Core.Model.EmailSecurityStamp model)
//        {
//            model.Stamp = Guid.NewGuid().ToString();
//            var result = await _dataSource.SetByEmailAsync(model);
//            if (!result.Success)
//                return result;

//            string aesEncryptionPass = Config.AppSettings["AesEncryptionPassword"];
//            model.Stamp = model.Stamp.EncryptText(aesEncryptionPass);

//            // send message to user
//            var sendNotifyResult = await _SendUserNotificationAsync(model, Core.Model.UserNotificationTemplate.SendForgotPasswordLinkByEmail, "لینک بازنشانی کلمه عبور", true);
//            if (!sendNotifyResult.Success)
//                return sendNotifyResult;

//            return result;
//        }

//        public async Task<AppCore.Result> VerifyAsync(Core.Model.EmailSecurityStamp model)
//        {
//            int validTime = Int32.Parse(Config.AppSettings["SecurityStampValidTime"]);

//            var result = await _dataSource.GetByEmailAsync(model.Email);
//            if (!result.Success)
//                return result;
//            var persistedModel = result.Data;

//            string aesEncryptionPass = Config.AppSettings["AesEncryptionPassword"];
//            var stamp = persistedModel.Stamp.EncryptText(aesEncryptionPass);

//            if (persistedModel == null || stamp != model.Stamp)
//                return AppCore.Result.Failure(message: "کد امنیتی ارسال شده معتبر نیست");

//            // check for valid time
//            if (persistedModel.CreationDate.AddSeconds(validTime) < DateTime.Now)
//                return AppCore.Result.Failure(message: "کد امنیتی ارسال شده منقضی شده است");

//            return AppCore.Result.Successful();
//        }

//        // private 

//        private async Task<AppCore.Result> _SendUserNotificationAsync(Core.Model.EmailSecurityStamp model, Core.Model.UserNotificationTemplate userNotificationTemplat, string subject, bool mandatory = false)
//        {
//            var mailTemplateFilePath = UserNotificationHelper.GetTemplateFilePath($"{userNotificationTemplat.ToString()}.html", _requestInfo);

//            if (mandatory && !File.Exists(mailTemplateFilePath))
//                return AppCore.Result.Failure(message: "قالب مورد نظر برای ارسال ایمیل یافت نشد");

//            if (string.IsNullOrEmpty(model.Email))   // ??? verify cellphone
//                return AppCore.Result.Failure(message: "ایمیل وارد شده معتبر نیست.");

//            //if (File.Exists(mailTemplateFilePath))
//            //{
//            //    await _mailService.Send(
//            //        new Kama.MailService.Core.Model.Mail()
//            //        {
//            //            Content = UserNotificationHelper.RenderTemplateWithModel<Core.Model.EmailSecurityStamp>(mailTemplateFilePath, model, _requestInfo),
//            //            SourceAccount = Kama.MailService.Core.Model.MailServiceAccounts.Azmoon,
//            //            Priority = Kama.MailService.Core.Model.Priority.Normal,
//            //            Subject = subject,
//            //            EmailReceivers = new List<Kama.MailService.Core.Model.MailReceiverDetail> { new MailService.Core.Model.MailReceiverDetail { Email = model.Email } }
//            //        }
//            //    );
//            //}

//            return AppCore.Result.Successful();
//        }


//    }
//}