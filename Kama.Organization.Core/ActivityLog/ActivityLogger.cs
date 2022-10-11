using System;
using System.Collections.Generic;
using System.Text;

namespace Kama.Organization.Core
{
    public class ActivityLogger : IActivityLogger
    {
        public ActivityLogger(Guid userId, Guid? positionId, string remoteIP)
        {
            _userId = userId;
            _positionId = positionId;
            _remoteIP = remoteIP;
        }

        readonly Guid _userId;
        readonly Guid? _positionId;
        readonly string _remoteIP;
        readonly IList<IActivityLogItem> _items = new List<IActivityLogItem>();

        private string QuoteStr(string s)
            => "\"" + s + "\"";

        private string Map(string key, string value)
            => $"{QuoteStr(key)}:{value}, ";

        public string Value
        {
            get
            {
                var lines = new StringBuilder();
                for (int i = 0; i < _items.Count; i++)
                {
                    var item = _items[i];
                    lines.Append("{");
                    lines.Append(Map("ID", QuoteStr(item.ID.ToString())));
                    lines.Append(Map("UserId", QuoteStr(item.UserId.ToString())));
                    lines.Append(Map("PositionId", QuoteStr(item.PositionId.ToString())));
                    lines.Append(Map("Station", QuoteStr(item.Station)));
                    lines.Append(Map("CommandId", QuoteStr(item.CommandId.ToString())));
                    lines.Append(Map("Description", QuoteStr(item.Description)).TrimEnd(' ', ','));
                    lines.Append("}, ");
                }

                return "[" + lines.ToString().TrimEnd(' ', ',') + "]";
            }
        }

        public IEnumerable<IActivityLogItem> Items => _items;

        public void Add(Guid commandId, string description)
            => _items.Add(new OperationLoggItem { Station = _remoteIP, UserId = _userId, PositionId = _positionId, CommandId = commandId, Description = description });

        class OperationLoggItem : IActivityLogItem
        {
            public override string ToString()
                => Description;

            readonly Guid _id = Guid.NewGuid();

            public Guid ID => _id;

            public Guid UserId { get; set; }

            public Guid? PositionId { get; set; }

            public string Station { get; set; }

            public Guid CommandId { get; set; }

            public string Description { get; set; }
        }
    }
}
