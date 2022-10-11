using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class FAQService : Service<Core.DataSource.IFAQDataSource>, Core.Service.IFAQService
    {
        public FAQService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.FAQ>> AddAsync(model.FAQ model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.FAQ>> EditAsync(model.FAQ model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<model.FAQ>>> ListAsync(model.FAQListVM faqListVm)
            => _dataSource.ListAsync(faqListVm);

        public async Task<AppCore.Result<model.FAQ>> GetAsync(Guid Id)
        {
            var result = await _dataSource.GetAsync(Id);
            if (!result.Success)
                return AppCore.Result<model.FAQ>.Failure(code: result.Code, message: result.Message);

            return AppCore.Result<model.FAQ>.Successful(code: result.Code, data: result.Data);
        }

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);

    }
}
