using System;

namespace Kama.Organization.Core.Model
{
    public class Place : Model
    {
        public override string ToString() => Name;

        public string Node { get; set; }

        public string ParentNode { get; set; }

        public PlaceType Type { get; set; }

        public string Name { get; set; }

        public string LatinName { get; set; }

        public string Code { get; set; }

        public Guid? ParentID { get; set; }

    }
}