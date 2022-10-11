using System;

namespace Kama.Organization.Core.Model
{
    public class RoleListVM : ListVM
    {
        public string Name { get; set; }

        public PositionType PositionType { get; set; }

        public Guid? PositionID { get; set; }

        public Guid? UserID { get; set; }

    }
}