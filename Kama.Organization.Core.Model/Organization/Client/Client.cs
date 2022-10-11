using System;

namespace Kama.Organization.Core.Model
{
    public class Client : Model
    {
        public override string ToString()
            => Name;

        public Guid ApplicationID { get; set; }

        public string ApplicationName { get; set; }

        public string ApplicationCode { get; set; }

        public bool ApplicationEnabled { get; set; }

        public string Name { get; set; }

        public string Secret { get; set; }

        public ClientType Type { get; set; }

        public bool Enabled { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        public string AllowedOrigin { get; set; }

    }
}