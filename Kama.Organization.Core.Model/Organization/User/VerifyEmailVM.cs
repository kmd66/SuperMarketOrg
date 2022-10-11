using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class VerifyEmailVM
    {
        public Guid ID { get; set; }    // userId

        public string Email { get; set; }

        public string SecurityStamp { get; set; }
    }
}