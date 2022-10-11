using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSequence : Model
    {
        public Guid UserID { get; set; }  

        public Guid TicketID { get; set; }

        public Guid? AttachmentID { get; set; }

        public string Content { get; set; }

        public DateTime? ReadDate { get; set; }

        public string TicketSequenceUserName { get; set; }

        public string DepartmentName { get; set; }

        public byte PositionType { get; set; }

        public string TimePart { get; set; }

        public int Total { get; set; }

    }
}
