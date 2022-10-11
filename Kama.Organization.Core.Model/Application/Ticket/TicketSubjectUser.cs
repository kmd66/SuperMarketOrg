using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSubjectUser : Model
    {
        public Guid ApplicationID { get; set; }

        public Guid TicketSubjectID { get; set; }

        public string SubjectName { get; set; }

        public string UserName { get; set; }

        public Guid UserID { get; set; }

        public int Total { get; set; }

    }
}
