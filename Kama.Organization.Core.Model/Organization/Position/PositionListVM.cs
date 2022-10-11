using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class PositionListVM : ListVM
    {
        public List<Guid> IDs { get; set; }

        public Guid? DepartmentId { get; set; }

        public PositionType Type { get; set; }

        public List<PositionType> Types { get; set; }

        public UserType UserType { get; set; }

        public Guid? UserID { get; set; }

        public string NationalCode { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string DepartmentName { get; set; }

        public EnableState EnableState { get; set; }

        public Guid? RoleID { get; set; }

        public bool FilterUserNull { get; set; }

        public Guid? ProvinceId { get; set; }

        public Guid? ApplicationID { get; set; }

    }
}