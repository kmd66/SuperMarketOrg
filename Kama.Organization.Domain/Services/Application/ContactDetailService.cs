using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    class ContactDetailService:Service<Core.DataSource.IContactDetailDataSource>, Core.Service.IContactDetailService
    {
        public ContactDetailService(AppCore.IOC.IContainer container)
            :base(container)
        {
        }

        public Task<AppCore.Result<model.ContactDetail>> AddAsync(model.ContactDetail model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.ContactDetail>.FailureAsync(message: validation.Result.Message);

            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.ContactDetail>> EditAsync(model.ContactDetail model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.ContactDetail>.FailureAsync(message: validation.Result.Message);

            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id, null);

        private Task<AppCore.Result> _ValidateForSave(model.ContactDetail attachment)
        {
            return AppCore.Result.SuccessfulAsync();
        }
    }
}
