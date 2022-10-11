using System;

namespace Kama.Organization.Core.Model
{
    public class ContactDetail : Model
    {
        public override string ToString() => $"{Type.ToString().Replace("_"," ")} - {Name} - {Value}";

        public Guid ContactInfoID { get; set; }

        public ContactDetailType Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}