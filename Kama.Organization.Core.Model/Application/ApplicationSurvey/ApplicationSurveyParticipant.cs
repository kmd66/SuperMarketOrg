using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyParticipant : Model
    {
        public Guid UserID { get; set; }

        public Guid SurveyID { get; set; }

        public DateTime Date { get; set; }

        public string FullName { get; set;}

        public string SurveyName { get; set;}



        public int Total { get; set; }
    }
}