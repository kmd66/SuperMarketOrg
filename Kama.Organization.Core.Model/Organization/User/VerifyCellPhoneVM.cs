using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class VerifyCellPhoneVM
    {
        public Guid ID { get; set; }    // userId

        public string CellPhone { get; set; }

        public string SecurityStamp { get; set; }
    }
}