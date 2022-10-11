using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class FAQ : Model
    {
        public int Total { get; set; }

        public Guid FAQGroupID { get; set; }

        public Guid ApplicationID { get; set; }

        public string Title { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public Guid CreatorID { get; set; }

        public DateTime CreationDate { get; set; }
    }

}
