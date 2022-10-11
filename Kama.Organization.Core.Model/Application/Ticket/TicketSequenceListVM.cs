using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSequenceListVM : ListVM
    {
        public Guid TicketID { get; set; }

        public Guid UserID { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ReadDate { get; set; }

    }
}
