using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class Announcement : FileModel
    {
        public int Total { get; set; }

        public AnnouncementType Type { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ExtendedContent { get; set; }

        public bool HasExtendedContent { get; set; }

        public bool Enable { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Order { get; set; }

        public bool AllUsers { get; set; }

        public bool AuthorizedUsers { get; set; }

        public bool UnAuthorizedUsers { get; set; }

        public int VisitCount { get; set; }

        public List<AnnouncementPositionType> PositionTypes { get; set; }

        public bool Pinned { get; set; }

        public Guid AttachmentID { get; set; }

        public bool Expanded { get; set; }

        public Guid? ProvinceID { get; set; }

        public AnnouncementPriorityType Priority { get; set; }
}
}
