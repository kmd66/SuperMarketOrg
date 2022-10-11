using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.Hosting;

namespace Kama.Organization.API.Tools
{
    public class AppSetting : Core.IAppSetting
    {
        public Guid ApplicationID => Guid.Parse(GetValue<string>("ApplicationID"));

        public AppCore.DeploymentMode DeploymentMode => (AppCore.DeploymentMode)GetValue<byte>("DeploymentMode");

        public string MailServiceHost => GetValue<string>("MailServiceHost");

        public string SmsServiceHost => GetValue<string>("SmsServiceHost");

        public string SecurityStampValidTime => GetValue<string>("SecurityStampValidTime");

        public string AesEncryptionPassword => GetValue<string>("AesEncryptionPassword");

        public string EncryptionSalt => GetValue<string>("EncryptionSalt");

        public int AccessTokenExpireTimeSpan => GetValue<int>("AccessTokenExpireTimeSpan");

        public Core.Model.ZoneType Zone => (Core.Model.ZoneType)GetValue<byte>("Zone");

        private static T GetValue<T>(string key)
        {
            var value = (object)ConfigurationManager.AppSettings[key];

            if (value is T)
                return (T)value;

            try
            {
                if (Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}