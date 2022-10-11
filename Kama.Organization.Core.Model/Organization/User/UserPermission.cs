using System;

namespace Kama.Organization.Core.Model
{
    public class UserPermission
    {
        public string Role { get; set; }

        //public Guid ScopeID { get; set; }

       // public AppScopes Scope => (AppScopes)ScopeID;

        public Guid CommandID { get; set; }

       // public AppCommands Command => (AppCommands)CommandID;
    }
}
