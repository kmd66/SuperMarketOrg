using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSubject : Model
    {
        public string Name { get; set; }

        public int Total { get; set; }

        public bool Enable { get; set; }

        public UserType Type { get; set; }

    }
}
