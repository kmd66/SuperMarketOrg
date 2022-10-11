using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class Ticket : Model
    {
        public Guid ApplicationID { get; set; }

        public Guid SubjectID { get; set; }

        public Guid CreatorUserID { get; set; }

        public byte State { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime? LastReadDate { get; set; }

        public string TrackingCode { get; set; }

        public string Title { get; set; }

        public string SubjectTitle { get; set; }

        public byte Priority { get; set; }

        public byte Score { get; set; }

        public byte PositionType { get; set; }

        public Guid CreatorPositionID { get; set; }

        public Guid? LastTicketSequenceUserID { get; set; }

        public Guid? OwnerID { get; set; }

        public Guid? DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public string OwnerPositionName { get; set; }

        public string CreatorUserName { get; set; }

        public bool IsRead { get; set; }

        public int Total { get; set; }

        public UserType Type { get; set; }

    }
}
