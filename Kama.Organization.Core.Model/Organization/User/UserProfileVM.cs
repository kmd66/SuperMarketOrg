using System;
using System.ComponentModel.DataAnnotations;
using Kama.Library.Helper;

namespace Kama.Organization.Core.Model
{
    public class UserProfileVM   
    {
        public override string ToString()
            => $"{FirstName} {LastName}({Username})";

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //[Required(ErrorMessage = "تلفن همراه را وارد کنید.")]
        [RegularExpression(pattern: @"(\+98|0)?9\d{9}", ErrorMessage = "تلفن همراه وارد شده اشتباه است.")]
        public string CellPhone { get; set; }

    }
}