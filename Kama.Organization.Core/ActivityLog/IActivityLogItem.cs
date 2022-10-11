using System;

namespace Kama.Organization.Core
{
    public interface IActivityLogItem
    {
        Guid ID { get; }

        Guid UserId { get; }

        Guid? PositionId { get; }

        string Station { get; }

        Guid CommandId { get; }

        string Description { get; }
    }
}
