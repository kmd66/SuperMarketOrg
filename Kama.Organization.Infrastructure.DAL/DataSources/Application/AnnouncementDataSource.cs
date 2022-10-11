using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using Kama.Organization.Core;
using Kama.AppCore;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    class AnnouncementDataSource : DataSource, Core.DataSource.IAnnouncementDataSource
    {
        public AnnouncementDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {

        }

        private async Task<AppCore.Result<Core.Model.Announcement>> ModifyAsync(bool isNewRecord, Core.Model.Announcement model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyAnnouncementAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _applicationID: _requestInfo.ApplicationId,
                    _content: model.Content,
                    _dueDate: model.DueDate,
                    _releaseDate: model.ReleaseDate,
                    _enable: model.Enable,
                    _extendedContent: model.ExtendedContent,
                    _title: model.Title,
                    _type: (byte)model.Type,
                    _order: model.Order,
                    _allUsers: model.AllUsers,
                    _authorizedUsers: model.AuthorizedUsers,
                    _unAuthorizedUsers: model.UnAuthorizedUsers,
                    _pinned: model.Pinned,
                    _positionTypes: _objSerializer.Serialize(model.PositionTypes),
                    _userID: _requestInfo.UserId,
                    _expanded: model.Expanded,
                    _provinceID: model.ProvinceID,
                    _priority: (byte)model.Priority,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Announcement>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Announcement>> CreateAsync(Core.Model.Announcement model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Announcement>> UpdateAsync(Core.Model.Announcement model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteAnnouncementAsync(
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

        public async Task<AppCore.Result> SetOrdersAsync(IEnumerable<Core.Model.Announcement> models, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.SetAnnouncementOrdersAsync(
                    _orders: models == null ? null : _objSerializer.Serialize(models.Select(a => new { a.ID, a.Order })),
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Announcement>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetAnnouncementAsync(
                        _id: id)).ToActionResult<Core.Model.Announcement>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Announcement>>> ListAsync(Core.Model.AnnouncementListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetAnnouncementsAsync(
                        _currentUserProvinceID: _requestInfo.ProvinceId,
                        _title: model.Title,
                        _enable: (byte)model.Enable,
                        _type: (byte)model.Type,
                        _userID: _requestInfo.UserId,
                        _applicationID: _requestInfo.ApplicationId,
                        _pageIndex: model.PageIndex,
                        _pageSize: model.PageSize,
                        _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.Announcement>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Announcement>>> ListForBulletinAsync(Core.Model.AnnouncementListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetAnnouncementsForBulletinAsync(
                    _currentUserProvinceID: _requestInfo.ProvinceId,
                    _positionID: _requestInfo.PositionId,
                    _applicationID: _requestInfo.ApplicationId,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize
                )).ToListActionResult<Core.Model.Announcement>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.AnnouncementPositionType>>> ListPositionTypesAsync(Guid announcementId)
        {
            try
            {
                var result = (await _dbAPP.GetAnnouncementPositionTypesAsync(
                        _announcementID: announcementId
                    )).ToListActionResult<Core.Model.AnnouncementPositionType>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
