//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Kama.AppCore;
//using Kama.SmsService.Core.Model;
//using model = Kama.Organization.Core.Model;

//namespace Kama.Organization.Domain
//{
//    class SmsService : Service, Core.Service.ISmsService
//    {
//        public SmsService(AppCore.IOC.IContainer container,
//            Core.IRequestInfo requestInfo,
//            Kama.SmsService.ApiClient.Interface.IMessageService messageService)
//            :base(container)
//        {
//            _requestInfo = requestInfo;
//            _messageService = messageService;
//        }

//        private readonly Core.IRequestInfo _requestInfo;
//        private readonly Kama.SmsService.ApiClient.Interface.IMessageService _messageService;

//        public Task<Result<Message>> SendAsync(Message model)
//        {
//            switch(_requestInfo.Application)
//            {
//                case Core.ApplicationEnum.سامانه_تشخیص_صلاحیت_حرفه_ای_حسابداران_رسمی:
//                    model.AccountTitle = SmsServiceAccounts.MefaAzmoon.ToString();
//                    break;
//                default:
//                    model.AccountTitle = SmsServiceAccounts.MefaDaadkhahi.ToString();
//                    break;
//            }

//            return _messageService.Send(model);
//        }

//    }
//}
