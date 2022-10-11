using System;
using System.ComponentModel.DataAnnotations;
using Kama.Library.Helper;

namespace Kama.Organization.Core.Model
{
    public class WebServiceUser : Model   
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid OrganID { get; set; }

        public bool Enabled { get; set; }

        public DateTime? PasswordExpireDate { get; set; }

        public string Comment { get; set; }
    }
}