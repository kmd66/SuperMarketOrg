using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IFAQService : IService
    {
        Task<AppCore.Result<Model.FAQ>> AddAsync(Model.FAQ model);

        Task<AppCore.Result<Model.FAQ>> EditAsync(Model.FAQ model);

        Task<AppCore.Result<IEnumerable<Model.FAQ>>> ListAsync(Model.FAQListVM faqListVm);

        Task<AppCore.Result<Model.FAQ>> GetAsync(Guid Id);

        Task<AppCore.Result> DeleteAsync(Guid Id);

    }
}