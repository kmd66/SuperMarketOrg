using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class FAQGroupService : Service<Core.DataSource.IFAQGroupDataSource>, Core.Service.IFAQGroupService
    {
        public FAQGroupService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.FAQGroup>> AddAsync(model.FAQGroup model)
        {
            //Todo: validation
            model.ID = Guid.NewGuid();

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.FAQGroup>> EditAsync(model.FAQGroup model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListAsync(model.FAQGroupListVM faqGroupListVM)
            => _dataSource.ListAsync(faqGroupListVM);

        public Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListWithFAQsAsync(model.FAQGroupListVM faqGroupListVM)
            => _dataSource.ListWithFAQsAsync(faqGroupListVM);

        public Task<AppCore.Result<model.FAQGroup>> GetAsync(Guid Id)
            => _dataSource.GetAsync(Id);

        public Task<AppCore.Result> DeleteAsync(Guid Id)
            => _dataSource.DeleteAsync(Id, null);

    }
}
