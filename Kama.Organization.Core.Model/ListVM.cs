using System;
using System.Collections.Generic;
using Kama.AppCore;

namespace Kama.Organization.Core.Model
{
    public class ListVM
    {
        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

        public List<SortExp> SortExp { get; set; }
    }
}