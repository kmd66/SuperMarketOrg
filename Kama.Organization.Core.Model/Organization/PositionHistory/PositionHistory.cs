using System;

namespace Kama.Organization.Core.Model
{
    public class PositionHistory : PositionHistory<PositionType>
    {
    }
    public class PositionHistory<TPositionType> : Model
    {
        public int Total { get; set; }

        public Guid PositionID { get; set; }

        public Guid UserID { get; set; }

        public string LetterNumber { get; set; }

        public DateTime? Date { get; set; }

        public string Comment { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string Username { get; set; }

        public string CellPhone { get; set; }

        public bool IsEndUser { get; set; }

        public string CreatorUserFirstName { get; set; }

        public string CreatorUserLastName { get; set; }

        public string CreatorUserNationalCode { get; set; }

        public string CreatorUserUsername { get; set; }

        public string CreatorUserCellPhone { get; set; }

        public TPositionType CreatorPositionType { get; set; }

        public Guid CreatorPositionDepartmentID { get; set; }

        public string CreatorPositionDepartmentName { get; set; }
    }
}