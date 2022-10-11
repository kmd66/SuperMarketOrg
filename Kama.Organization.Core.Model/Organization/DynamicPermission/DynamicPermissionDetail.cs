using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class DynamicPermissionDetail: Model
    {
        public Guid DynamicPermissionID { get; set; }

        public DynamicPermissionDetailType Type { get; set; }

        public Guid GuidValue { get; set; }

        public byte ByteValue { get; set; }

        public string DepartmentName { get; set; }

        public string ProvinceName { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }
    }
}
