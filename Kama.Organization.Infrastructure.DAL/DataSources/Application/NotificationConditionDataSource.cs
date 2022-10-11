using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using Kama.AppCore;
using Kama.Organization.Core;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class NotificationConditionDataSource : DataSource, Core.DataSource.INotificationConditionDataSource
    {
        public NotificationConditionDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.NotificationCondition>> ModifyAsync(bool isNewRecord, Core.Model.NotificationCondition model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyNotificationConditionAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _departmentID: model.DepartmentID,
                    _notificationID: model.NotificationID,
                    _positionID: model.PositionID,
                    _positionType: model.PositionType,
                    _provinceID: model.ProvinceID,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.NotificationCondition>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.NotificationCondition>> CreateAsync(Core.Model.NotificationCondition model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.NotificationCondition>> UpdateAsync(Core.Model.NotificationCondition model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteNotificationConditionAsync(
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

        public async Task<AppCore.Result<Core.Model.NotificationCondition>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationConditionAsync(
                    _id: id
                    )).ToActionResult<Core.Model.NotificationCondition>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.NotificationCondition>>> ListAsync(Core.Model.NotificationConditionsListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetNotificationConditionsAsync(
                    _notificationID: model.NotificationID,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.NotificationCondition>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
