﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class DraftMessageListVM : ListVM
    {
        public Guid ReceiverUserID { get; set; }

        public string Title { get; set; }

    }
}
