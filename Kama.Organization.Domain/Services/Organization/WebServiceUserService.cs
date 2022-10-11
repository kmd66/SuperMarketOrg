using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kama.Library.Helper.Security;
using Kama.AppCore;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Domain.Services
{
    class WebServiceUserService : Service<Core.DataSource.IWebServiceUserDataSource>, Core.Service.IWebServiceUserService
    {
        public WebServiceUserService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result<WebServiceUser>> AddAsync(WebServiceUser model)
        {
            var validationResult = await _ValidateForSaveAsync(model);
            if (!validationResult.Success)
                return AppCore.Result<WebServiceUser>.Failure(message: validationResult.Message);

            model.ID = Guid.NewGuid();

            model.Password = model.Password.HashText();
            if(model.PasswordExpireDate == null)
                model.PasswordExpireDate = DateTime.Now.AddMonths(12);

            return await _dataSource.CreateAsync(model);
        }

        public async Task<Result<WebServiceUser>> EditAsync(WebServiceUser model)
        {
            var validationResult = await _ValidateForSaveAsync(model);
            if (!validationResult.Success)
                return AppCore.Result<WebServiceUser>.Failure(message: validationResult.Message);

            if(model.Password != null)
                model.Password = model.Password.HashText();

            return await _dataSource.UpdateAsync(model);
        }

        public Task<Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id);

        public async Task<AppCore.Result<Core.Model.WebServiceUser>> GetAsync(Core.Model.WebServiceUserGetVM model)
        {
            model.Password = model.Password.HashText();

            var result = await _dataSource.GetAsync(model);
            if (!result.Success)
                return result;

            if (result.Data == null)
                return AppCore.Result<Core.Model.WebServiceUser>.Failure(message: "نام کاربری یا کلمه عبور اشتباه است");

            if (result.Data.Enabled)
                return AppCore.Result<Core.Model.WebServiceUser>.Failure(message: "کاربر غیرفعال است");

            if (result.Data.PasswordExpireDate < DateTime.Now)
                return AppCore.Result<Core.Model.WebServiceUser>.Failure(message: "زمان استفاده از وب سرویس منقضی شده است");

            return result;
        }

        public Task<Result<WebServiceUser>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<Result<IEnumerable<WebServiceUser>>> ListAsync(WebServiceUserListVM model)
            => _dataSource.ListAsync(model);

        private async Task<AppCore.Result> _ValidateForSaveAsync(WebServiceUser model)
        {
            return AppCore.Result.Successful();
        }
    }
}