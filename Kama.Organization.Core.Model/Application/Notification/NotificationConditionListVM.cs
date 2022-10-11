using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class NotificationConditionsListVM : ListVM
    {
        public Guid NotificationID { get; set; }

        public Guid? DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public Guid? ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public byte PositionType { get; set; }

        public string FullName { get; set; }

    }
}