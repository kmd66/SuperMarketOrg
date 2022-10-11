using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using model = Core.Model;

    class FAQGroupDataSource : DataSource, Core.DataSource.IFAQGroupDataSource
    {
        public FAQGroupDataSource(AppCore.IOC.IContainer container
                                , Core.DataSource.IFAQDataSource faqDataSource)
            : base(container)
        {
            _faqDataSource = faqDataSource;
        }
        Core.DataSource.IFAQDataSource _faqDataSource;
        private async Task<AppCore.Result<model.FAQGroup>> ModifyAsync(bool isNewRecord, model.FAQGroup faqGroup, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyFAQGroupAsync(
                    _isNewRecord: isNewRecord
                    , _id: faqGroup.ID
                    , _applicationID: _requestInfo.ApplicationId
                    , _title: faqGroup.Title
                    , _userID: _requestInfo.UserId
                    , _log: log?.Value
                    )).ToActionResult<model.FAQGroup>();

                if (result.Success)
                    return await GetAsync(faqGroup.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<model.FAQGroup>> CreateAsync(model.FAQGroup faq, AppCore.IActivityLog log)
            => ModifyAsync(true, faq, log);

        public Task<AppCore.Result<model.FAQGroup>> UpdateAsync(model.FAQGroup faq, AppCore.IActivityLog log)
            => ModifyAsync(false, faq, log);

        public async Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListAsync(model.FAQGroupListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetFAQGroupsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize,
                    _sortExp: model.SortExp.ToSortExpString()
                    )).ToListActionResult<model.FAQGroup>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.FAQGroup>> GetAsync(Guid Id)
        {
            try
            {
                var result = (await _dbAPP.GetFAQGroupAsync(_id: Id)).ToActionResult<model.FAQGroup>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListWithFAQsAsync(model.FAQGroupListVM faqGroupListVM)
        {
            try
            {
                var listAsync = ListAsync(faqGroupListVM);
                var listFaqAsync = _faqDataSource.ListAsync(new model.FAQListVM());

                var list = await listAsync;
                if (!list.Success)
                    return list;

                var listFaq = await listFaqAsync;
                if (!listFaq.Success)
                    return AppCore.Result<IEnumerable<model.FAQGroup>>.Failure(message: listFaq.Message);

                list.Data.ToList().ForEach(f => f.FAQs = listFaq.Data.Where(w => w.FAQGroupID == f.ID).ToList());

                return list;
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
                var result = (await _dbAPP.DeleteFAQGroupAsync(_id: id, _log: log?.Value)).ToActionResult<model.FAQGroup>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

