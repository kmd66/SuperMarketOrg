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
    class TicketSequenceDataSource : DataSource, Core.DataSource.ITicketSequenceDataSource
    {
        public TicketSequenceDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public Task<Result<TicketSequence>> CreateAsync(TicketSequence model, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(Guid id, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketSequence>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<TicketSequence>>> ListAsync(TicketSequenceListVM model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketSequence>> SetReadDateAsync(TicketSequence model, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketSequence>> UpdateAsync(TicketSequence model, IActivityLog log)
        {
            throw new NotImplementedException();
        }

        //private async Task<AppCore.Result<Core.Model.TicketSequence>> ModifyAsync(bool isNewRecord, Core.Model.TicketSequence model, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.ModifyTicketSequenceAsync(
        //            _isNewRecord: isNewRecord,
        //            _id: model.ID,
        //            _positionID: _requestInfo.PositionId,
        //            _content: model.Content,
        //            _ticketID: model.TicketID,
        //            _userID: _requestInfo.UserId,
        //            _log: log?.Value
        //            )).ToActionResult<Core.Model.TicketSequence>();

        //        if (result.Success)
        //            return await this.GetAsync(model.ID);

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public Task<AppCore.Result<Core.Model.TicketSequence>> CreateAsync(Core.Model.TicketSequence model, AppCore.IActivityLog log)
        //    => ModifyAsync(true, model, log);

        //public Task<AppCore.Result<Core.Model.TicketSequence>> UpdateAsync(Core.Model.TicketSequence model, AppCore.IActivityLog log)
        //    => ModifyAsync(false, model, log);

        //public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.DeleteTicketSequenceAsync(
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

        //public async Task<AppCore.Result<Core.Model.TicketSequence>> GetAsync(Guid id)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.GetTicketSequenceAsync(
        //            _id: id
        //            )).ToActionResult<Core.Model.TicketSequence>();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result<IEnumerable<Core.Model.TicketSequence>>> ListAsync(Core.Model.TicketSequenceListVM model)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.GetTicketSequencesAsync(
        //            _userID: _requestInfo.UserId,
        //            _ticketID: model.TicketID,
        //            _currentPositionID: _requestInfo.PositionId,
        //            _content: model.Content,
        //            _pageIndex: model.PageIndex,
        //            _pageSize: model.PageSize,
        //            _sortExp: model.SortExp.ToSortExpString()
        //            )).ToListActionResult<Core.Model.TicketSequence>();

        //        return result;

        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<AppCore.Result<Core.Model.TicketSequence>> SetReadDateAsync(Core.Model.TicketSequence model, AppCore.IActivityLog log)
        //{
        //    try
        //    {
        //        var result = (await _dbAPP.SetTicketSequenceReadDateAsync(
        //            _id: model.ID,
        //            _currentUserPositionID: _requestInfo.PositionId,
        //            _readDate: model.ReadDate,
        //            _log: log?.Value
        //            )).ToActionResult<Core.Model.TicketSequence>();

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

    }
}
