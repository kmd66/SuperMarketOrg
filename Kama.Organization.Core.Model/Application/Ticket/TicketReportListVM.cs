using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketReportListVM : ListVM
    {
        public Guid? SubjectID { get; set; }

        public string TrackingCode { get; set; }

        public Guid? DepartmentID { get; set; }

        public byte State { get; set; }

        public byte Score { get; set; }

        public string Title { get; set; }

        public byte Priority { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
