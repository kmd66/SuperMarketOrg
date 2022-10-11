
using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class Command : Model
    {
        Dictionary<CommandType, string> prefixDictionary = new Dictionary<CommandType, string>();

        public Command()
        {
            prefixDictionary.Add(Core.Model.CommandType.Unknown, "Unknown");
            prefixDictionary.Add(Core.Model.CommandType.App, "app");
            prefixDictionary.Add(Core.Model.CommandType.Menu, "mnu");
            prefixDictionary.Add(Core.Model.CommandType.Page, "pge");
            prefixDictionary.Add(Core.Model.CommandType.State, "stt");
            prefixDictionary.Add(Core.Model.CommandType.Tab, "tab");
            prefixDictionary.Add(Core.Model.CommandType.Element, "elm");
        }

        public override string ToString()
            => Title;

        //public Guid ApplicationID { get; set; }

        public Guid ParentID { get; set; }

        public string Node { get; set; }

        public string ParentNode { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public CommandType Type { get; set; }

        public string PermissionName
        {
            get
            {
                if(prefixDictionary.ContainsKey(Type))
                    return prefixDictionary[Type] + FullName;
                else
                    return "unknown" + FullName;
            }
        }
    }
}
