using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IMessageDataSource : IDataSource
    {
        Task<AppCore.Result<Model.Message>> CreateAsync(Model.Message model, AppCore.IActivityLog log);

        Task<AppCore.Result<Model.Message>> UpdateAsync(Model.Message model, AppCore.IActivityLog log);

        Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> PermanentDeleteAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> SendAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result> SeenAsync(Guid id, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListInBoxAsync(Core.Model.InboxMessageListVM model);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListOutBoxAsync(Core.Model.OutboxMessageListVM model);

        Task<AppCore.Result<IEnumerable<Model.Message>>> ListDraftAsync(Core.Model.DraftMessageListVM model);

        Task<AppCore.Result<Model.Message>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Core.Model.MessageReceiver>>> GetReceiversAsync(Guid? messageId , List<Guid> messageIds);

    }
}
