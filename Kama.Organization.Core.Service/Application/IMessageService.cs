using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IMessageService : IService
    {
        Task<AppCore.Result<Model.Message>> AddAsync(Model.Message model);

        Task<AppCore.Result<Model.Message>> EditAsync(Model.Message model);

        Task<AppCore.Result> DeleteAsync(Guid id);

        Task<AppCore.Result> PermanentDeleteAsync(Guid id);

        Task<AppCore.Result> SendAsync(Guid id);

        Task<AppCore.Result> SeenAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListInBoxAsync(Model.InboxMessageListVM model);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListOutBoxAsync(Model.OutboxMessageListVM model);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListDraftAsync(Model.DraftMessageListVM model);

        Task<AppCore.Result<Model.Message>> GetAsync(Guid id);

    }
}