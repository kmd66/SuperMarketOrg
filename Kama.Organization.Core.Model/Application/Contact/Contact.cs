using System;

namespace Kama.Organization.Core.Model
{
    public class Contact : Model
    {
        public int Total { get; set; }
        
        public string Email { get; set; }

        public string Tel { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public string NationalCode { get; set; }

        public bool Archived { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
