using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{

    public class NotificationCondition : Model
    {
        public Guid NotificationID  { get; set; }

        public NotificationState State { get; set; }

        public Guid? DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public Guid? ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public Guid? PositionID { get; set; }

        public byte PositionType { get; set; }

        public string FullName { get; set; }

        public int Total { get; set; }

    }
}