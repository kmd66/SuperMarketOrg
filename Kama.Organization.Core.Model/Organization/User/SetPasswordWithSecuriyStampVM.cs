using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class SetPasswordWithSecuriyStampVM
    {
        public Guid ID { get; set; }    // userId

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public string SecurityStamp { get; set; }

        public string Password { get; set; }

    }
}