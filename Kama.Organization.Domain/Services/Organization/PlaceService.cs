using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class PlaceService : Service<Core.DataSource.IPlaceDataSource>, Core.Service.IPlaceService
    {
        public PlaceService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }
        

        public Task<AppCore.Result<Core.Model.Place>> AddAsync(Core.Model.Place model)
        {
            model.ID = Guid.NewGuid();

            //var logger = Core.RequestInfo.CreateActivityLogger();
            //logger.Add(commandId: Guid.Empty, description: "افزودن مکان جدید با نام: " + model.Name);

            return _dataSource.CreateAsync(model, null);
        }

        public Task<AppCore.Result<Core.Model.Place>> EditAsync(Core.Model.Place model)
        {
            if (model.ID == null)
                return AppCore.Result<Core.Model.Place>.FailureAsync(message: "آی دی مشخص نشده است");

            return _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Core.Model.Place model)
        {
            if (model.ID == null)
                return AppCore.Result.FailureAsync(message: "آی دی مشخص نشده است");

            return _dataSource.DeleteAsync(model.ID, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.Place>>> ListAsync(Core.Model.PlaceListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.Place>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);
    }
}