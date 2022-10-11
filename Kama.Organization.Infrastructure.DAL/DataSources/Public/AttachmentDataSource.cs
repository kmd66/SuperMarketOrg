using Kama.Organization.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kama.Library.Helper;
using m = Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    class AttachmentDataSource : DataSource, Core.DataSource.IAttachmentDataSource
    {
        public AttachmentDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<m.Attachment>> ModifyAsync(bool isNewRecord, m.Attachment model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbPBL.ModifyAttachmentAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _type: (byte)model.Type,
                    _fileName: model.FileName,
                    _comment: model.Comment,
                    _data: model.Data,
                    _isUnique: model.IsUnique,
                    _log: log?.Value
                    )).ToActionResult<m.Attachment>();

                if (result.Success)
                    return await this.GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<m.Attachment>> CreateAsync(m.Attachment model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<m.Attachment>> UpdateAsync(m.Attachment model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbPBL.DeleteAttachmentAsync(
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

        public async Task<AppCore.Result<m.Attachment>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbPBL.GetAttachmentAsync(
                        _id: id
                    )).ToActionResult<m.Attachment>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<m.Attachment>>> ListAsync(Guid parentId)
        {
            try
            {

                var result = (await _dbPBL.GetAttachmentsAsync(
                    _parentID: parentId
                    )).ToListActionResult<m.Attachment>();

                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<m.Attachment>>> GetAttachmentsByParentIDsAsync(List<Guid> parentIDs)
        {
            try
            {
                var result = (await _dbPBL.GetAttachmentsByParentIDsAsync(
                        _parentIDs: _objSerializer.Serialize(parentIDs)
                    )).ToListActionResult<m.Attachment>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
