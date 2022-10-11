namespace Kama.Organization.Core.Model
{
    using System;
    using System.Collections.Generic;

    public class NotificationPosition
    {
        public string FullName { get; set; }

        public PositionType PositionType { get; set; }

        public string DepartmentName { get; set; }

        public int Total { get; set; }
    }
}
