using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Organization.Core.DataSource;

namespace Kama.Organization.Domain
{
    internal class DepartmentService : Service<Core.DataSource.IDepartmentDataSource>, Core.Service.IDepartmentService
    {
        public DepartmentService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }



        public async Task<AppCore.Result<Core.Model.Department>> AddAsync(Core.Model.Department model)
        {
            var validateResult = await _ValidateAsync(model);
            if (!validateResult.Success)
                return validateResult;

            model.ID = Guid.NewGuid();
            return await _dataSource.CreateAsync(model, null);
        }

        public async Task<AppCore.Result<Core.Model.Department>> EditAsync(Core.Model.Department model)
        {
            var validateResult = await _ValidateAsync(model);
            if (!validateResult.Success)
                return validateResult;

            if (model.ID == null)
                return AppCore.Result<Core.Model.Department>.Failure(message: "");

            return await _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Core.Model.Department model)
        {
            if (model.ID == null)
                return AppCore.Result.FailureAsync(message: "آی دی مشخص نشده است.");

            return _dataSource.DeleteAsync(model.ID, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.Department>>> ListAsync(Core.Model.DepartmentListVM department)
            => _dataSource.ListAsync(department);

        public async Task<AppCore.Result<Core.Model.Department>> GetAsync(Guid id)
            => await _dataSource.GetAsync(id);

        private async Task<AppCore.Result<Core.Model.Department>> _ValidateAsync(Core.Model.Department model)
        {
            if (model.ParentID != Guid.Empty && model.ParentID == model.ID)
                return AppCore.Result<Core.Model.Department>.Failure(message: "مقدار وارد شده در فیلد «محل کار بالاتر» مورد قبول نیست");

            if (model.ID != Guid.Empty)
            {
                var departmentListVM = new Core.Model.DepartmentListVM();
                departmentListVM.ParentID = model.ID;
                var listResult = await ListAsync(departmentListVM);
                if (!listResult.Success)
                    return AppCore.Result<Core.Model.Department>.Failure(message: "خطا در بازیابی اطلاعات");
                if (listResult.Data.Count(x => x.ID == model.ParentID) > 0)
                    return AppCore.Result<Core.Model.Department>.Failure(message: "مقدار وارد شده در فیلد «محل کار بالاتر» مورد قبول نیست");
            }

            return AppCore.Result<Core.Model.Department>.Successful();
        }
    }
}