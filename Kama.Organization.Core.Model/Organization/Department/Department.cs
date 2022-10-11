using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class Department : Model
    {
        public override string ToString() => Name;

        public int Total { get; set; }

        public Guid? ParentID { get; set; }

        public string Node { get; set; }

        public string ParentNode { get; set; }

        public string ParentName { get; set; }

        public DepartmentType Type { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public Guid? ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public Guid? RemoverID { get; set; }

        public DateTime? RemoverDate { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
    }
}