using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class NotificationsListVM : ListVM
    {
        public NotificationSenderType SenderType { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public NotificationPriority Priority { get; set; }

        public NotificationState State { get; set; }

        public DateTime? CreationDateFrom { get; set; }

        public DateTime? CreationDateTo { get; set; }

    }
}
