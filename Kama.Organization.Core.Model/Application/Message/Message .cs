using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Model
{
    public class Message : Model
    {
        public Guid ApplicationID { get; set; }

        public Guid SenderUserID { get; set; }

        public string SenderUserFullName { get; set; }

        public Guid CurrentUserID { get; set; }

        public Guid MessageID { get; set; }

        public Guid ParentID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsSent {get; set;}

        public List<MessageReceiver> ReceiverUsers { get; set; } 

        public bool Seen { get; set; }

        public int Total { get; set; }

    }
}
