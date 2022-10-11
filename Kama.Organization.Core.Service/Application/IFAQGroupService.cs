using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IFAQGroupService : IService
    {
        Task<AppCore.Result<Model.FAQGroup>> AddAsync(Model.FAQGroup model);

        Task<AppCore.Result<Model.FAQGroup>> EditAsync(Model.FAQGroup model);

        Task<AppCore.Result<IEnumerable<Model.FAQGroup>>> ListAsync(Model.FAQGroupListVM faqGroupListVM);

        Task<AppCore.Result<IEnumerable<Model.FAQGroup>>> ListWithFAQsAsync(Model.FAQGroupListVM faqGroupListVM);

        Task<AppCore.Result<Model.FAQGroup>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}