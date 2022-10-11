using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ContactInfo : Model
    {
        public override string ToString() => $"{Name}";

        public Guid ParentID { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public List<ContactDetail> ContactDetails { get; set; }
    }
}