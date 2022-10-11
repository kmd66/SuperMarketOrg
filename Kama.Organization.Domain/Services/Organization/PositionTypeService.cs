using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using Kama.AppCore;
    using Kama.Organization.Core.Model;
    using model = Core.Model;

    class PositionTypeService : Service<Core.DataSource.IPositionTypeDataSource>, Core.Service.IPositionTypeService
    {
        public PositionTypeService(
            AppCore.IOC.IContainer container,
            Core.DataSource.IPositionDepartmentMappingDataSource positionDepartmentMappingDataSource
            )
            : base(container)
        {
            _positionDepartmentMappingDataSource = positionDepartmentMappingDataSource;
        }

        readonly Core.DataSource.IPositionDepartmentMappingDataSource _positionDepartmentMappingDataSource;

        public Task<Result<PositionTypeModel>> AddAsync(PositionTypeModel model)
        {
            return _dataSource.CreateAsync(model, null);
        }

        public Task<Result<PositionTypeModel>> EditAsync(PositionTypeModel model)
        {
            return _dataSource.UpdateAsync(model, null);
        }

        public Task<Result> SetRolesAsync(model.PositionTypeModel model)
            => _dataSource.SetRolesAsync(model, null);

        public Task<AppCore.Result<IEnumerable<model.PositionTypeModel>>> ListAsync()
            => _dataSource.ListAsync();

        public Task<Result<IEnumerable<Role>>> GetRolesAsync(PositionType positionType)
            => _dataSource.GetRolesAsync(positionType);

        public Task<Result<PositionTypeModel>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

    }
}
