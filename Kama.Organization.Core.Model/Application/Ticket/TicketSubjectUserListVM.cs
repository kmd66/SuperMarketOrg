﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class TicketSubjectUserListVM : ListVM
    {
        public Guid UserID { get; set; }

        public Guid TicketSubjectID { get; set; }

    }
}
