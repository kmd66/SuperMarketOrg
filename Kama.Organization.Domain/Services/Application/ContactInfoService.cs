using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    class ContactInfoService : Service<Core.DataSource.IContactInfoDataSource>, Core.Service.IContactInfoService
    {
        public ContactInfoService(
            AppCore.IOC.IContainer container,
            Core.DataSource.IContactDetailDataSource contactDetailDataSource
            )
            : base(container)
        {
            _contactDetailDataSource = contactDetailDataSource;
        }
        private Core.DataSource.IContactDetailDataSource _contactDetailDataSource;

        public Task<AppCore.Result<model.ContactInfo>> AddAsync(model.ContactInfo model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.ContactInfo>.FailureAsync(message: validation.Result.Message);

            model.ID = Guid.NewGuid();
            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<model.ContactInfo>> EditAsync(model.ContactInfo model)
        {
            var validation = _ValidateForSave(model);
            if (!validation.Result.Success)
                return AppCore.Result<model.ContactInfo>.FailureAsync(message: validation.Result.Message);

            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
            => _dataSource.DeleteAsync(id, null);

        public async Task<AppCore.Result<model.ContactInfo>> GetAsync(Guid id)
        {
            var result = await _dataSource.GetAsync(id);
            if (!result.Success || result.Data == null)
                return result;

            var contactInfoList = new List<model.ContactInfo>();
            contactInfoList.Add(result.Data);

            var detailResult = await _contactDetailDataSource.ListAsync(contactInfoList);
            if (!detailResult.Success)
                return AppCore.Result<model.ContactInfo>.Failure(message: detailResult.Message);

            result.Data.ContactDetails = detailResult.Data.ToList();

            return result;
        }

        public async Task<AppCore.Result<IEnumerable<model.ContactInfo>>> ListAsync(Guid parentId)
        {
            var result = await _dataSource.ListAsync(parentId);
            if (!result.Success)
                return result;

            var detailResult = await _contactDetailDataSource.ListAsync(result.Data);
            if (!detailResult.Success)
                return AppCore.Result<IEnumerable<model.ContactInfo>>.Failure(message: detailResult.Message);

            result.Data.ToList().ForEach(
                    ci => ci.ContactDetails = detailResult.Data.Where(cd => cd.ContactInfoID == ci.ID).ToList()
                );

            return result;
        }

        private Task<AppCore.Result> _ValidateForSave(model.ContactInfo model)
        {
            return AppCore.Result.SuccessfulAsync();
        }

    }
}
