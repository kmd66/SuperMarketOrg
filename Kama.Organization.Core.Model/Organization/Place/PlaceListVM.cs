using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class PlaceListVM : ListVM
    {
        public List<Guid> IDs { get; set; }

        public Guid? ParentID { get; set; }

        public PlaceType Type { get; set; }

        public int AncestorLevel { get; set; }

        public string Name { get; set; }

    }
}