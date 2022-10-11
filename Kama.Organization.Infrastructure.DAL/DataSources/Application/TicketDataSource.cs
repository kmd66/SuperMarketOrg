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
    class TicketDataSource : DataSource, Core.DataSource.ITicketDataSource
    {
        public TicketDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Ticket>> ModifyAsync(bool isNewRecord, Core.Model.Ticket model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyTicketAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _applicationID: _requestInfo.ApplicationId,
                    _positionID: _requestInfo.PositionId,
                    _ownerID: model.OwnerID,
                    _priority: model.Priority,
                    _state: model.State,
                    _trackingCode: model.TrackingCode,
                    _subjectID: model.SubjectID,
                    _title: model.Title,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Ticket>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Ticket>> CreateAsync(Core.Model.Ticket model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Ticket>> UpdateAsync(Core.Model.Ticket model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteTicketAsync(
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
        public async Task<AppCore.Result<Core.Model.Ticket>> SetTicketOwnerAsync(Core.Model.Ticket model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.SetTicketOwnerAsync(
                    _ownerID: model.OwnerID,
                    _id : model.ID
                    )).ToActionResult<Core.Model.Ticket>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<AppCore.Result<Core.Model.Ticket>> RatingAsync(Core.Model.Ticket model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.RatingTicketAsync(
                    _ticketID: model.ID,
                    _score: model.Score
                    )).ToActionResult<Core.Model.Ticket>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Ticket>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetTicketAsync(
                    _id: id
                    )).ToActionResult<Core.Model.Ticket>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Ticket>>> ListAsync(Core.Model.TicketListVM model)
        {
            try
            {
                
                return null;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<AppCore.Result<IEnumerable<Core.Model.Ticket>>> ReportAsync(Core.Model.TicketReportListVM model)
        {
            try
            {
                var result = (await _dbAPP.TicketReportAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _subjectID: model.SubjectID,
                    _departmentID: model.DepartmentID,
                    _state: model.State,
                    _score: model.Score,
                    _priority: model.Priority,
                    _trackingCode: model.TrackingCode,
                    _title: model.Title,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString(),
                    _currentUserID: _requestInfo.UserId
                    )).ToListActionResult<Core.Model.Ticket>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
