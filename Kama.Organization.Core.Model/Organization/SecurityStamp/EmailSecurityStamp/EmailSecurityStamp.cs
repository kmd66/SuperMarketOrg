using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class EmailSecurityStamp : Model
    {
        public string Email { get; set; }

        public string Stamp  { get; set; }
    }
}