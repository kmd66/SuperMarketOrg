using System;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class Position : Position<PositionType>
    {
    }

    public class Position<TPositionType> : Model
    {
        public override string ToString() => $"{FirstName} {LastName} - {Type.ToString()} {DepartmentName}";

        public int Total { get; set; }

        public Guid ApplicationID { get; set; }

        public Guid DepartmentID { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public DepartmentType DepartmentType { get; set; }

        public Guid? UserID { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string CellPhone { get; set; }

        public bool CellPhoneVerified { get; set; }

        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        public bool Enabled { get; set; }

        public bool UserEnabled { get; set; }

        public bool PasswordExpired { get; set; }


        public TPositionType Type { get; set; }

        public UserType UserType { get; set; }

        public Guid ParentID { get; set; }

        public bool Default { get; set; }

        public Guid? ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public string RoleName { get; set; }

        public List<Role> Roles { get; set; }

        public bool Foreigner { get; set; }

        public Guid? RemoverID { get; set; }

        public DateTime? RemoveDate { get; set; }

    }

}