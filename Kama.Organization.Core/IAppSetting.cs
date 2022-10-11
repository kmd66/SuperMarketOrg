using System;

namespace Kama.Organization.Core
{
    public interface IAppSetting
    {
        Guid ApplicationID { get; }

        AppCore.DeploymentMode DeploymentMode { get; }

        string MailServiceHost { get; }

        string SmsServiceHost { get; }

        string SecurityStampValidTime { get; }

        string AesEncryptionPassword { get; }

        string EncryptionSalt { get; }

        Core.Model.ZoneType Zone { get; }
        int AccessTokenExpireTimeSpan { get; }

    }
}
