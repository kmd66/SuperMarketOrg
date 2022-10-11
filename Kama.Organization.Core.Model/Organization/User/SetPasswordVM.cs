using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class SetPasswordVM
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}