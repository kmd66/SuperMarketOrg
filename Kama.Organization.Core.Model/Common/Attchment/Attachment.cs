using Kama.Organization.Core.Model;
using System;

namespace Kama.Organization.Core.Model
{
    public class Attachment : FileModel
    {
        public Guid? ParentID { get; set; }

        public OrganizationAttachmentType Type { get; set; }

        public bool? IsUnique { get; set; }
    }
}
