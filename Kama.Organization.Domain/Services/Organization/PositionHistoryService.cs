using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    internal class PositionHistoryService : Service<Core.DataSource.IPositionHistoryDataSource>, Core.Service.IPositionHistoryService
    {
        public PositionHistoryService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Core.Model.PositionHistory>> AddAsync(Core.Model.PositionHistory model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Core.Model.PositionHistory>.Failure(message: validation.Message);

            model.ID = Guid.NewGuid();
            return await _dataSource.CreateAsync(model, null);
        }

        public async Task<AppCore.Result<Core.Model.PositionHistory>> EditAsync(Core.Model.PositionHistory model)
        {
            var validation = await _ValidateForSave(model);
            if (!validation.Success)
                return AppCore.Result<Core.Model.PositionHistory>.Failure(message: validation.Message);

            return await _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Core.Model.PositionHistory model)
        {
            return _dataSource.DeleteAsync(model.ID, null);
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.PositionHistory>>> ListAsync(Core.Model.PositionHistoryListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<Core.Model.PositionHistory>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        private Task<AppCore.Result> _ValidateForSave(Core.Model.PositionHistory model)
        {
            List<string> errors = new List<string>();


            if (errors.Count > 0)
                return AppCore.Result.FailureAsync(message: string.Join("&&", errors));

            return AppCore.Result.SuccessfulAsync();
        }
    }
}