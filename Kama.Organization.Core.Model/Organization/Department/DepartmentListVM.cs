using System;

namespace Kama.Organization.Core.Model
{
    public class DepartmentListVM : ListVM
    {
        public Guid? ParentID { get; set; }

        public Guid? ProvinceID { get; set; }

        public DepartmentType Type { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool SearchWithHierarchy { get; set; }
    }
}