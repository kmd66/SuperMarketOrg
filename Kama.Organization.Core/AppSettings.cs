using Kama.AppCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Kama.Organization.Core
{
    public static class AppSettings
    {
        public static Guid ApplicationID => Guid.Parse(ConfigurationManager.AppSettings["ApplicationID"] ?? Guid.Empty.ToString());

        public static AppCore.DeploymentMode DeploymentMode => (AppCore.DeploymentMode)byte.Parse(ConfigurationManager.AppSettings["DeploymentMode"]);

        public static bool BypassAuthorization => (ConfigurationManager.AppSettings["BypassAuthorization"] ?? "0") == "1";

        public static string MailServiceHost => ConfigurationManager.AppSettings["MailServiceHost"];

        public static string MailServiceHostHeaders => ConfigurationManager.AppSettings["MailServiceHostHeaders"];

        public static string SmsServiceHost => ConfigurationManager.AppSettings["SmsServiceHost"];

        public static string SmsServiceHostHeaders => ConfigurationManager.AppSettings["SmsServiceHostHeaders"];

    }
}