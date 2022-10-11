using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class Role : Model
    {
        public override string ToString() => Name;

        public int Total { get; set; }

        public Guid ApplicationID { get; set; }

        public string Name { get; set; }

        public List<Command> Permissions { get; set; }
    }
}