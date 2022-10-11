using System;

namespace Kama.Organization.Core.Model
{
    public class ContactListVM : ListVM
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreationDateFrom { get; set; }

        public DateTime? CreationDateTo { get; set; }

        public ArchivedType ArchivedType { get; set; }

        public string Note { get; set; }
    }
}
