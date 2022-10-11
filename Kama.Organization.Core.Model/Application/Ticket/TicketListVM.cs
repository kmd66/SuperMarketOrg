using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketListVM : ListVM
    {
        public Guid? SubjectID { get; set; }

        public string TrackingCode { get; set; }

        public Guid? DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public byte Score { get; set; }

        public DateTime? ReadDate { get; set; }

        public Guid? CreatorPositionID { get; set; }

        public Guid? OwnerID { get; set; }

        public byte State { get; set; }

        public string Title { get; set; }

        public string SubjectTitle { get; set; }

        public byte Priority { get; set; }

        public DateTime CreationDate { get; set; }

        public TicketAnswerState TicketAnswerState { get; set; }

        public bool IsCreated { get; set; }
    }
}
