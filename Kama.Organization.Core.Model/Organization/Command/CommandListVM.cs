
using System;

namespace Kama.Organization.Core.Model
{
    public class CommandListVM
    {
        public Guid? ParentID { get; set; }

        public Guid? RoleID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public CommandType Type { get; set; }

    }
}
