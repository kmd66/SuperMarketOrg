using System;
using System.Collections.Generic;
using xml = System.Xml;

namespace Kama.Organization.Infrastructure.DAL
{
    class XmlProvider
    {
        public string RolePermissions(Guid roleId, IEnumerable<Core.Model.Command> commands)
        {
            var doc = new xml.XmlDocument();
            var root = doc.CreateElement("Permissions");
            root.SetAttribute("RoleID", roleId.ToString());
            foreach (var item in commands)
            {
                var element = doc.CreateElement("Command");
                element.SetAttribute("ID", item.ID.ToString());
                root.AppendChild(element);
            }
            var xmlValue = root.OuterXml;
            doc = null;
            return xmlValue;
        }

        public string UserRoles(Guid userId, IEnumerable<Core.Model.Role> roles)
        {
            var doc = new xml.XmlDocument();
            var root = doc.CreateElement("Roles");
            root.SetAttribute("UserID", userId.ToString());
            foreach (var item in roles)
            {
                var element = doc.CreateElement("Role");
                element.SetAttribute("ID", item.ID.ToString());
                root.AppendChild(element);
            }
            var xmlValue = root.OuterXml;
            doc = null;
            return xmlValue;
        }
    }
}
