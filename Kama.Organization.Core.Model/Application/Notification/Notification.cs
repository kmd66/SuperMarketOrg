using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{

    public class Notification : Model
    {
        public Guid? SenderPositionID { get; set; }

        public string SenderName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public NotificationPriority Priority { get; set; }

        public NotificationState State { get; set; }

        public List<Position> Positions { get; set; }

        public List<NotificationPosition> ReceiverPositions { get; set; }

        public int Total { get; set; }

    }
}