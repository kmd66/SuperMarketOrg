using System;

namespace Kama.Organization.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CheckPermissionAttribute : Attribute
    {
        public Core.CommandEnum Command { get; set; }

        public CheckPermissionAttribute(Core.CommandEnum command)
        {
            this.Command = command;
        }
    }
}