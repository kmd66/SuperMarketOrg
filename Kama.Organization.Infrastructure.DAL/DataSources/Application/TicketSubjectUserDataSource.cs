using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using Kama.AppCore;
using Kama.Organization.Core;
using Kama.Library.Helper;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL
{
    class TicketSubjectUserDataSource : DataSource, Core.DataSource.ITicketSubjectUserDataSource
    {
        public TicketSubjectUserDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<Result<TicketSubjectUser>> CreateAsync(TicketSubjectUser model, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(Guid id, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketSubjectUser>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<TicketSubjectUser>>> ListAsync(TicketSubjectUserListVM model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketSubjectUser>> UpdateAsync(TicketSubjectUser model, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        //private async Task<AppCore.Result<Core.Model.TicketSubjectUser>> ModifyAsync(bool isNewRecord, Core.Model.TicketSubjectUser model, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.ModifyTicketSubjectUserAsync(
        //            _id: model.ID,
        //            _isNewRecord: isNewRecord,
        //            _ticketSubjectID: model.TicketSubjectID,
        //            _userID: model.UserID,
        //            _log: log?.Value
        //            )).ToActionResult<Core.Model.TicketSubjectUser>();

        //        if (result.Success)
        //            return await this.GetAsync(model.ID);

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public Task<AppCore.Result<Core.Model.TicketSubjectUser>> CreateAsync(Core.Model.TicketSubjectUser model, AppCore.IActivityLog log)
        //    => ModifyAsync(true, model, log);

        //public Task<AppCore.Result<Core.Model.TicketSubjectUser>> UpdateAsync(Core.Model.TicketSubjectUser model, AppCore.IActivityLog log)
        //    => ModifyAsync(false, model, log);

        //public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.DeleteTicketSubjectUserAsync(
        //            _id: id,
        //            _log: log?.Value
        //            )).ToActionResult();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result<Core.Model.TicketSubjectUser>> GetAsync(Guid id)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.GetTicketSubjectUserAsync(
        //            _id: id
        //            )).ToActionResult<Core.Model.TicketSubjectUser>();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result<IEnumerable<Core.Model.TicketSubjectUser>>> ListAsync(Core.Model.TicketSubjectUserListVM model)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.GetTicketSubjectUsersAsync(
        //            _ticketSubjectID: model.TicketSubjectID,
        //            _pageIndex: model.PageIndex,
        //            _pageSize: model.PageSize,
        //            _sortExp: model.SortExp.ToSortExpString()
        //            )).ToListActionResult<Core.Model.TicketSubjectUser>();

        //        return result;

        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

    }
}
