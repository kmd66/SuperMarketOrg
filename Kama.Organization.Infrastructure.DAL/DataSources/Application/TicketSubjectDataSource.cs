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
    class TicketSubjectDataSource : DataSource, Core.DataSource.ITicketSubjectDataSource
    {
        public TicketSubjectDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.TicketSubject>> ModifyAsync(bool isNewRecord, Core.Model.TicketSubject model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyTicketSubjectAsync(
                    _isNewRecord: isNewRecord,
                    _applicationID: _requestInfo.ApplicationId,
                    _id: model.ID,
                    _name: model.Name,
                    _enable: model.Enable,
                    //_type: (byte)model.Type,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.TicketSubject>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.TicketSubject>> CreateAsync(Core.Model.TicketSubject model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.TicketSubject>> UpdateAsync(Core.Model.TicketSubject model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteTicketSubjectAsync(
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

        public async Task<AppCore.Result<Core.Model.TicketSubject>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetTicketSubjectAsync(
                    _id: id
                    )).ToActionResult<Core.Model.TicketSubject>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.TicketSubject>>> ListAsync(Core.Model.TicketSubjectListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetTicketSubjectsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _name: model.Name,
                     _enable: (byte)model.Enable,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.TicketSubject>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
