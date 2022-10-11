using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    class AttachmentService:Service<Core.DataSource.IAttachmentDataSource>, Core.Service.IAttachmentService
    {
        public AttachmentService(AppCore.IOC.IContainer container)
            :base(container)
        {
        }

        public Task<AppCore.Result<model.Attachment>> AddAsync(model.Attachment model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.Attachment>.FailureAsync(message: validation.Result.Message);

            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.Attachment>> EditAsync(model.Attachment model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.Attachment>.FailureAsync(message: validation.Result.Message);

            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(model.Attachment model)
            => _dataSource.DeleteAsync(model.ID, null);

        public Task<AppCore.Result<model.Attachment>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        public Task<AppCore.Result<IEnumerable<model.Attachment>>> ListAsync(Guid parentId)
            => _dataSource.ListAsync(parentId);

        private Task<AppCore.Result<model.Attachment>> _ValidateForSave(model.Attachment attachment)
        {
            //var validation = ValidateModel(attachment);
            //if (!validation.Success)
            //    return AppCore.Result<model.Attachment>.FailureAsync(message: validation.Message);

            return AppCore.Result<model.Attachment>.SuccessfulAsync();
        }
    }
}
