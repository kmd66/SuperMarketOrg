using System;
using System.Collections.Generic;

namespace Kama.Organization.Core
{
    public interface IActivityLogger : AppCore.IActivityLog
    {
        IEnumerable<IActivityLogItem> Items { get; }

        void Add(Guid commandId, string description);
    }
}
