using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class DynamicPermission : Model
    {
        public Guid ObjectID { get; set; }

        public int Order { get; set; }

        public List<Department> ParentDepartments { get; set; }

        public List<Department> Departments { get; set; }

        public List<Place> Provinces { get; set; }
        
        public List<DepartmentType> DepartmentTypes { get; set; }

        public List<PositionType> PositionTypes { get; set; }

        public List<Position> Positions { get; set; }

    }
}
