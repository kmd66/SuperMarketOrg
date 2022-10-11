namespace Kama.Organization.Core.Model
{
    using System;
    using System.Collections.Generic;
    public class AnnouncementListVM : ListVM
    {
        public string Title { get; set; }

        public EnableState Enable { get; set; }

        public AnnouncementType Type { get; set; }
    }
}
