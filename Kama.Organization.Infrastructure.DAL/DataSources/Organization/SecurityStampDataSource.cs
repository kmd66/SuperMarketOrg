//using Kama.Organization.Core;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using @Model = Kama.Organization.Core.Model;
//using Kama.AppCore;

//namespace Kama.Organization.Infrastructure.DAL.DataSources
//{
//    internal class SecurityStampDataSource : DataSource, Core.DataSource.ISecurityStampDataSource
//    {
//        public SecurityStampDataSource(AppCore.IOC.IContainer container)
//            : base(container)
//        {
//        }

//        public async Task<AppCore.Result<Model.SmsSecurityStamp>> GetByCellPhoneAsync(string cellPhone)
//        {
//            try
//            {
//                var result = (await _dbORG.GetSecurityStampByCellPhoneAsync(
//                    _cellPhone: cellPhone
//                )).ToActionResult<Core.Model.SmsSecurityStamp>();

//                return result;
//            }
//            catch (Exception e)
//            {
//                throw;
//            }
//        }

//        public async Task<AppCore.Result<Model.EmailSecurityStamp>> GetByEmailAsync(string email)
//        {
//            try
//            {
//                var result = (await _dbORG.GetSecurityStampByEmailAsync(
//                    _email: email
//                )).ToActionResult<Core.Model.EmailSecurityStamp>();

//                return result;
//            }
//            catch (Exception e)
//            {
//                throw;
//            }
//        }

//        public async Task<AppCore.Result> SetByCellPhoneAsync(Core.Model.SmsSecurityStamp model)
//        {
//            try
//            {
//                var result = (await _dbORG.SetSecurityStampByCellPhoneAsync(
//                    _cellPhone: model.CellPhone,
//                    _stamp: model.Stamp
//                )).ToActionResult();

//                return result;
//            }
//            catch (Exception e)
//            {
//                throw;
//            }
//        }

//        public async Task<AppCore.Result> SetByEmailAsync(Core.Model.EmailSecurityStamp model)
//        {
//            try
//            {
//                var result = (await _dbORG.SetSecurityStampByEmailAsync(
//                    _email: model.Email,
//                    _stamp: model.Stamp
//                )).ToActionResult();

//                return result;
//            }
//            catch (Exception e)
//            {
//                throw;
//            }
//        }

//    }
//}