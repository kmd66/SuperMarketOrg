using System;

namespace Kama.Organization.Core.Model
{
    public class UserModifyValidation : Model
    {
        public string NationalCode { get; set; }
        public string Username { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }

        public bool IsNationalCodeRepeated { get; set; }
        public bool IsUserNameRepeated { get; set; }
        public bool IsEmailRepeated { get; set; }
        public bool IsCellphoneRepeated { get; set; }
        public bool IsCellPhoneChanged { get; set; }
        public bool IsEmailChanged { get; set; }
    }
}