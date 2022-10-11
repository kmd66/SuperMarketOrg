using Kama.Organization.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m = Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    class ContactInfoDataSource : DataSource, Core.DataSource.IContactInfoDataSource
    {
        public ContactInfoDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<m.ContactInfo>> ModifyAsync(bool isNewRecord, m.ContactInfo model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyContactInfoAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _name: model.Name,
                    _order: model.Order,
                    _log: log?.Value
                    )).ToActionResult<m.ContactInfo>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<m.ContactInfo>> CreateAsync(m.ContactInfo model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<m.ContactInfo>> UpdateAsync(m.ContactInfo model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteContactInfoAsync(
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

        public async Task<AppCore.Result<m.ContactInfo>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetContactInfoAsync(
                        _id: id
                    )).ToActionResult<m.ContactInfo>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<m.ContactInfo>>> ListAsync(Guid parentId)
        {
            try
            {

                var result = (await _dbAPP.GetContactInfosAsync(
                        _parentID: parentId
                    )).ToListActionResult<m.ContactInfo>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
