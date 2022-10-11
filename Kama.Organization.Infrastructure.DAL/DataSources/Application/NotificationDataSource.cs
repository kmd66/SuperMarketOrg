using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kama.AppCore;
using Kama.Organization.Core;
using System.Data.SqlClient;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class NotificationDataSource : DataSource, Core.DataSource.INotificationDataSource
    {
        public NotificationDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Notification>> ModifyAsync(bool isNewRecord, Core.Model.Notification model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyNotificationAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _senderPositionID: model.SenderPositionID,
                    _applicationID: _requestInfo.ApplicationId,
                    _content: model.Content,
                    _state: (byte)Core.Model.NotificationState.ارسال_نشده,
                    _title: model.Title,
                    _priority: (byte)model.Priority,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Notification>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Notification>> CreateAsync(Core.Model.Notification model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Notification>> UpdateAsync(Core.Model.Notification model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteNotificationAsync(
                    _id: id,
                    _log: log?.Value
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
                var commands = new List<SqlCommand>();

                var conditionsResult = (await _dbAPP.GetNotificationConditionsAsync(
                    _notificationID: id,
                    _pageSize: null,
                    _pageIndex: 0,
                    _sortExp: ""
                    )).ToListActionResult<Core.Model.NotificationCondition>();
                var conditions = conditionsResult.Data.ToList();

                if(conditions == null || conditions.Count() == 0)
                {
                    conditions = new List<Core.Model.NotificationCondition>();
                    conditions.Add(new Core.Model.NotificationCondition { NotificationID = id});
                }

                foreach(var condition in conditions)
                {
                    commands.Add(_dbAPP.GetCommand_SetNotificationPositionFromCondition(
                        _applicationID: _requestInfo.ApplicationId,
                        _conditionID: condition.ID
                        ));
                }

                commands.Add(_dbAPP.GetCommand_SendNotification(
                    _notificationID: id,
                    _log: log?.Value
                    ));

                await _dbAPP.BatchExcuteAsync(commands.ToArray());

                return AppCore.Result.Successful();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> ArchiveAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ArchiveNotificationAsync(
                    _notificationID: id,
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Notification>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationAsync(
                    _id: id
                    )).ToActionResult<Core.Model.Notification>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Notification>>> ListAsync(Core.Model.NotificationsListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _priority: (byte)model.Priority,
                    _state: (byte)model.State,
                    _title: model.Title,
                    _content: model.Content,
                    _creationDateFrom: model.CreationDateFrom,
                    _creationDateTo: model.CreationDateTo,
                    _senderType: (byte)model.SenderType,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.Notification>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Notification>>> ListByPositionAsync(Core.Model.NotificationListByPositionVM model)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationsByPositionAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _currentUserPositionID: _requestInfo.PositionId
                    )).ToListActionResult<Core.Model.Notification>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.NotificationPosition>>> ListPositionsAsync(Core.Model.NotificationPositionsListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationPositionsAsync(
                    _notificationID: model.NotificationID,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                )).ToListActionResult<Core.Model.NotificationPosition>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
