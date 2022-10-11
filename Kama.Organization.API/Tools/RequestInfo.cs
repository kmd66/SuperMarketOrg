using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kama.Organization.Core;

namespace Kama.Organization.API.Tools
{
    public class RequestInfo : AppCore.RequestInfo, Core.IRequestInfo
    {
        public Core.Model.UserType UserType
        {
            get
            {
                byte val = 0;
                byte.TryParse(GetValueFromToken(AppCore.Claims.UserType), out val);
                return (Organization.Core.Model.UserType)val;
            }
        }

        public Core.Model.PositionType PositionType
        {
            get
            {
                byte val = 0;
                byte.TryParse(GetValueFromToken(AppCore.Claims.PositionType), out val);
                return (Organization.Core.Model.PositionType)val;
            }
        }

        public Core.Model.DepartmentType DepartmentType
        {
            get
            {
                byte val = 0;
                byte.TryParse(GetValueFromToken(AppCore.Claims.DepartmentType), out val);
                return (Organization.Core.Model.DepartmentType)val;
            }
        }

        public ApplicationEnum Application => Core.ApplicationHelper.GetApplicationEnum((Guid)this.ApplicationId);
    }
}