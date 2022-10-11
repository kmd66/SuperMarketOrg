using System;

namespace Kama.Organization.Core.Model
{
    public class UserListVM : ListVM
    {
        public string Name { get; set; }

        public string NationalCode { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public EnableState EnableOrDisable { get; set; }

    }
}