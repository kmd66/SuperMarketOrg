using System;

namespace Kama.Organization.Core.Model
{
    public class WebServiceUserListVM : ListVM
    {
        public string UserName { get; set; }

        public Guid? OrganID { get; set; }

        public string OrganName { get; set; }

        public EnableState EnableState { get; set; }

        public string Comment { get; set; }


    }
}