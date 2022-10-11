namespace Kama.Organization.Core.Model
{
    using System;
    using System.Collections.Generic;

    public class MessageReceiver : Model
    {
        public Guid MessageID { get; set; }

        public Guid ReceiverUserID { get; set; }

        public string ReceiverUserFullName { get; set; }

        public bool IsRemoved { get; set; }

        public bool Seen { get; set; }

    }
}
