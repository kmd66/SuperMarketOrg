using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class AnnouncementPositionType<TPositionType> : Model
    {
        public TPositionType PositionType { get; set; }

    }

    public class AnnouncementPositionType : AnnouncementPositionType<PositionType>
    {
    }

    public class AzmoonAnnouncementPositionType : AnnouncementPositionType<AgreementPositionType>
    {
    }
}
