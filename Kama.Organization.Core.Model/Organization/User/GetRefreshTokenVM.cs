﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class GetRefreshTokenVM
    {
        public Guid client_id { get; set; }

        public string client_secret { get; set; }

        public string grant_type { get; set; }

        public string refresh_token { get; set; }

    }
}
