using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class FAQGroup : Model
    {
        public int Total { get; set; }

        public Guid ApplicationID { get; set; }

        public string Title { get; set; }

        public Guid CreatorID { get; set; }

        public DateTime CreationDate { get; set; }

        public List<FAQ> FAQs { get; set; }
    }
}
