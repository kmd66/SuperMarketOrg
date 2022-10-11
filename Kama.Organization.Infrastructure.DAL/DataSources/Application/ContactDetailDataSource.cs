using Kama.Organization.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kama.Library.Helper;
using m = Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    class ContactDetailDataSource : DataSource, Core.DataSource.IContactDetailDataSource
    {
        public ContactDetailDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<m.ContactDetail>> ModifyAsync(bool isNewRecord, m.ContactDetail model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyContactDetailAsync(
                        _isNewRecord: isNewRecord,
                        _id: model.ID,
                        _contactInfoID: model.ContactInfoID,
                        _type: (byte)model.Type,
                        _name: model.Name,
                        _value: model.Value,
                        _log: log?.Value
                    )).ToActionResult<m.ContactDetail>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<m.ContactDetail>> CreateAsync(m.ContactDetail model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<m.ContactDetail>> UpdateAsync(m.ContactDetail model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.DeleteContactDetailAsync(
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

        public async Task<AppCore.Result<m.ContactDetail>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbAPP.GetContactDetailAsync(
                        _id: id
                    )).ToActionResult<m.ContactDetail>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<m.ContactDetail>>> ListAsync(IEnumerable<m.ContactInfo> contactInfoIds)
        {
            try
            {

                var result = (await _dbAPP.GetContactDetailsAsync(
                        _contactInfoIDs: contactInfoIds == null ? null : _objSerializer.Serialize(contactInfoIds.Select(c => c.ID))
                    )).ToListActionResult<m.ContactDetail>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
