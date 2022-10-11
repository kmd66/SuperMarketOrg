using System;
using System.ComponentModel.DataAnnotations;
using Kama.Library.Helper;

namespace Kama.Organization.Core.Model
{
    public class User : Model   
    {
        public override string ToString()
            => $"{FirstName} {LastName}({Username})";

        public string Name
            => $"{FirstName} {LastName}";

        public int Total { get; set; }

        public bool Enabled { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? PasswordExpireDate { get; set; }

        public UserType Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        //[Required(ErrorMessage = "تلفن همراه را وارد کنید.")]
        [RegularExpression(pattern: @"(\+98|0)?9\d{9}", ErrorMessage = "تلفن همراه وارد شده اشتباه است.")]
        public string CellPhone { get; set; }

        public bool CellPhoneVerified { get; set; }

        public bool Foreigner { get; set; }
    }
}