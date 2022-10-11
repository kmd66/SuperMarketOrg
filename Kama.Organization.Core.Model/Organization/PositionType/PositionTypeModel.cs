using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class PositionTypeModel : Model
    {
        public Guid? ParentID { get; set; }

        public Guid ApplicationID { get; set; }

        public string ApplicationName { get; set; }

        public PositionType PositionType { get; set; }

        public UserType UserType { get; set; }

        public List<Role> Roles { get; set; }

        public List<PositionDepartmentMapping> PositionDepartmentMappings { get; set; }
    }
}