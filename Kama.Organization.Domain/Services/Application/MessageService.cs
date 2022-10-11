using Kama.Organization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class MessageService : Service<Core.DataSource.IMessageDataSource>, Core.Service.IMessageService
    {
        public MessageService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<AppCore.Result<model.Message>> AddAsync(model.Message model)
        {
            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.Message>> EditAsync(model.Message model)
        {
            return _dataSource.UpdateAsync(model, null);
        }
        public Task<AppCore.Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id, null);

        public Task<AppCore.Result> SeenAsync(Guid id)
            => _dataSource.SeenAsync(id, null);

        public async Task<AppCore.Result> SendAsync(Guid id)
        {
            var getResult = await this.GetAsync(id);
            if (!getResult.Success)
                return AppCore.Result.Failure(message: getResult.Message);
            var message = getResult.Data;

            if (string.IsNullOrEmpty(message.Title))
                return AppCore.Result.Failure(message: "عنوان وارد نشده است");

            if (message.ReceiverUsers == null || message.ReceiverUsers.Count() == 0)
                return AppCore.Result.Failure(message: "گیرنده(ها) مشخص نشده است");

            return await _dataSource.SendAsync(id, null);
        }

        public async Task<AppCore.Result<model.Message>> GetAsync(Guid id)
        {
            var async = new
            {
                get = _dataSource.GetAsync(id),
                listReceivers = _dataSource.GetReceiversAsync(id, null)
            };

            var result = await async.get;
            if (!result.Success)
                return result;
            var message = result.Data;

            var receiversResult = await async.listReceivers;
            if (!receiversResult.Success)
                return AppCore.Result<model.Message>.Failure(message: receiversResult.Message);
            message.ReceiverUsers = receiversResult.Data.ToList();

            return AppCore.Result<model.Message>.Successful(data: message);
        }

        public Task<AppCore.Result<IEnumerable<model.Message>>> ListInBoxAsync(model.InboxMessageListVM model)
        {
            return _dataSource.ListInBoxAsync(model);
        }

        public async Task<AppCore.Result<IEnumerable<model.Message>>> ListOutBoxAsync(model.OutboxMessageListVM model)
        {
            var listResult = await _dataSource.ListOutBoxAsync(model);
            if (!listResult.Success)
                return listResult;

            var receiversResult = await _dataSource.GetReceiversAsync(null, listResult.Data.ToList().Select(m => m.ID).ToList());
            if (!receiversResult.Success)
                return AppCore.Result<IEnumerable<model.Message>>.Failure(message: receiversResult.Message);

            foreach (var message in listResult.Data)
                message.ReceiverUsers = receiversResult.Data.Where(r => r.MessageID == message.ID).ToList();

            return listResult;
        }

        public Task<AppCore.Result<IEnumerable<model.Message>>> ListDraftAsync(model.DraftMessageListVM model)
        {
            return _dataSource.ListDraftAsync(model);
        }

        public Task<AppCore.Result> PermanentDeleteAsync(Guid id)
            => _dataSource.PermanentDeleteAsync(id, null);


    }
}
