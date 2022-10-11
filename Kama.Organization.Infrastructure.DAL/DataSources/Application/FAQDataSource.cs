using Kama.AppCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using model = Core.Model;

    class FAQDataSource : DataSource, Core.DataSource.IFAQDataSource
    {
        public FAQDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<model.FAQ>> ModifyAsync(bool isNewRecord, model.FAQ faq, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyFAQAsync(
                    _isNewRecord: isNewRecord
                    , _id: faq.ID
                    , _answer: faq.Answer
                    , _question: faq.Question
                    , _fAQGroupID: faq.FAQGroupID
                    , _userID: _requestInfo.UserId
                    , _log: log?.Value
                    )).ToActionResult<model.FAQ>();

                if (result.Success)
                    return await GetAsync(faq.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<model.FAQ>> CreateAsync(model.FAQ faq, AppCore.IActivityLog log)
            => ModifyAsync(true, faq, log);

        public Task<AppCore.Result<model.FAQ>> UpdateAsync(model.FAQ faq, AppCore.IActivityLog log)
            => ModifyAsync(false, faq, log);

        public async Task<AppCore.Result<IEnumerable<model.FAQ>>> ListAsync(model.FAQListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetFAQsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _fAQGroupID: model.faqGroupId,
                    _pageSize: model.PageSize,
                    _pageIndex: model.PageIndex,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<model.FAQ>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.FAQ>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetFAQAsync(
                        _id: Id
                    )).ToActionResult<model.FAQ>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteFAQAsync(
                        _id: id, 
                        _log: log?.Value
                    )).ToActionResult<model.FAQ>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

