//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Kama.Organization.Core.DataSource
//{
//    public interface ISecurityStampDataSource : IDataSource
//    {
//        Task<AppCore.Result<Core.Model.SmsSecurityStamp>> GetByCellPhoneAsync(string cellPhone);

//        Task<AppCore.Result<Core.Model.EmailSecurityStamp>> GetByEmailAsync(string email);

//        Task<AppCore.Result> SetByCellPhoneAsync(Core.Model.SmsSecurityStamp model);

//        Task<AppCore.Result> SetByEmailAsync(Core.Model.EmailSecurityStamp model);

//    }
//}