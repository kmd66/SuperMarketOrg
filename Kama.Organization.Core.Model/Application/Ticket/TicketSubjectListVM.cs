using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSubjectListVM : ListVM
    {
        public Guid ApplicationID { get; set; }

        public string Name { get; set; }

        public EnableState Enable { get; set; }

    }
}
