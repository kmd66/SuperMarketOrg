using System;

namespace Kama.Organization.Core.Model
{
    public class Application:Model
    {
        public override string ToString() 
            => Name;
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public bool Enabled { get; set; }
        public string Code { get; set; }
    }
}
