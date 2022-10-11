using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Library.Helper;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class PositionHistoryDataSource : DataSource, Core.DataSource.IPositionHistoryDataSource
    {
        public PositionHistoryDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.PositionHistory>> ModifyAsync(bool isNewRecord, Core.Model.PositionHistory model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyPositionHistoryAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _positionID: model.PositionID,
                    _userID: model.UserID,
                    _letterNumber: model.LetterNumber,
                    _date: model.Date,
                    _comment: model.Comment,
                    _creatorUserID: _requestInfo.UserId,
                    _creatorPositionID: _requestInfo.PositionId,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.PositionHistory>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.PositionHistory>> CreateAsync(Core.Model.PositionHistory model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.PositionHistory>> UpdateAsync(Core.Model.PositionHistory model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeletePositionHistoryAsync(
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

        public async Task<AppCore.Result<IEnumerable<Core.Model.PositionHistory>>> ListAsync(Core.Model.PositionHistoryListVM model)
        {
            try
            {
                var result = (await _dbORG.GetPositionHistorysAsync(
                        _positionID: model.PositionID,
                        _pageSize: model.PageSize,
                        _pageIndex: model.PageIndex,
                        _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<Core.Model.PositionHistory>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }        
        
        public async Task<AppCore.Result<Core.Model.PositionHistory>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetPositionHistoryAsync(
                        _id: id
                    )).ToActionResult<Core.Model.PositionHistory>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}