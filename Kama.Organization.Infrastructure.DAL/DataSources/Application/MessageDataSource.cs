using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kama.AppCore;
using Kama.Organization.Core.Model;
using Kama.Organization.Core;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class MessageDataSource : DataSource, Core.DataSource.IMessageDataSource
    {
        public MessageDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {

        }

        private async Task<AppCore.Result<Core.Model.Message>> ModifyAsync(bool isNewRecord, Core.Model.Message model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyMessageAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _applicationID: _requestInfo.ApplicationId,
                    _senderUserID: _requestInfo.UserId,
                    _content: model.Content,
                    _title: model.Title,
                    _parentID: model.ParentID,
                    _receiverUserIDs: model.ReceiverUsers == null ? null: _objSerializer.Serialize(model.ReceiverUsers.Select(m => m.ReceiverUserID)),
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Message>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Message>> CreateAsync(Core.Model.Message model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Message>> UpdateAsync(Core.Model.Message model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteMessageAsync(
                    _currentUserID: _requestInfo.UserId,
                    _messageID: id
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> PermanentDeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.PermanentDeleteMessageAsync(
                    _currentUserID: _requestInfo.UserId,
                    _messageID: id
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> SendAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.SendMessageAsync(
                    _messageID: id
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> SeenAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.SetMessageAsSeenAsync(
                    _currentUserID: _requestInfo.UserId,
                    _messageID: id
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Message>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetMessageAsync(
                    _id: id
                    )).ToActionResult<Core.Model.Message>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.MessageReceiver>>> GetReceiversAsync(Guid? messageId, List<Guid> messageIds)
        {
            try
            {
                var result = (await _dbAPP.GetMessageReceiversAsync(
                    _messageID: messageId,
                    _messageIDs: _objSerializer.Serialize(messageIds)
                    )).ToListActionResult<Core.Model.MessageReceiver>(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Message>>> ListInBoxAsync(InboxMessageListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetInboxMessagesAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _currentUserID: _requestInfo.UserId,
                    _title: model.Title,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.Message>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Message>>> ListOutBoxAsync(OutboxMessageListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetOutboxMessagesAsync(
                    _currentUserID: _requestInfo.UserId,
                    _applicationID: _requestInfo.ApplicationId,
                    _title: model.Title,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Message>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Message>>> ListDraftAsync(DraftMessageListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetDraftMessagesAsync(
                    _currentUserID: _requestInfo.UserId,
                    _applicationID: _requestInfo.ApplicationId,
                    _title: model.Title,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Message>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
