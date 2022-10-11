using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class Token
    {
        public Guid client_id { get; set; }

        public string client_secret { get; set; }

        public string grant_type { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public LoginType LoginType { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string SecurityStamp { get; set; }
    }
}
