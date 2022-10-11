using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class PositionDepartmentMapping : Model
    {
        public PositionType PositionType { get; set; }

        public DepartmentType DepartmentType { get; set; }

        public int? MaxUsersCount { get; set; }

        public Guid CreatorUserID { get; set; }

        public string CreatorFirstName { get; set; }

        public string CreatorLastName { get; set; }

    }
}