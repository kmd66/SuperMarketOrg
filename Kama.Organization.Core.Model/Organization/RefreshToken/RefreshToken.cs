using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class RefreshToken : Model
    {
        public Guid UserID { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public string ProtectedTicket { get; set; }

        public bool Expired => DateTime.Now > ExpireDate;
    }
}
