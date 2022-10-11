using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IFAQDataSource : IDataSource
    {
        Task<AppCore.Result<Model.FAQ>> CreateAsync(Model.FAQ faq, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.FAQ>> UpdateAsync(Model.FAQ faq, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.FAQ>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.FAQ>>> ListAsync(Model.FAQListVM faqListVm);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
