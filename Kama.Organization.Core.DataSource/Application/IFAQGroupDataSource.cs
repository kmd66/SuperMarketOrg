using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IFAQGroupDataSource : IDataSource
    {
        Task<AppCore.Result<Model.FAQGroup>> CreateAsync(Model.FAQGroup faqGroup, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.FAQGroup>> UpdateAsync(Model.FAQGroup faqGroup, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.FAQGroup>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.FAQGroup>>> ListAsync(Model.FAQGroupListVM faqGroupListVM);

        Task<AppCore.Result<IEnumerable<Model.FAQGroup>>> ListWithFAQsAsync(Model.FAQGroupListVM faqGroupListVM);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);
    }
}
