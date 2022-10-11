using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPositionDepartmentMappingDataSource : IDataSource
    {
        Task<AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>> MapDepartmentsToPosition(Model.PositionType PositionType, IEnumerable<Model.PositionDepartmentMapping> list, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Core.Model.PositionDepartmentMapping>>> MapPositionsToDepartment(Model.DepartmentType departmentType, IEnumerable<Model.PositionDepartmentMapping> list, AppCore.IActivityLog log);

        Task<AppCore.Result<IEnumerable<Model.PositionDepartmentMapping>>> ListAsync(Model.PositionDepartmentMappingListVM place);

    }
}

