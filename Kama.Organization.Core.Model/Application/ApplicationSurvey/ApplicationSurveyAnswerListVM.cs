using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyAnswerListVM : ListVM
    {
        public Guid? ParticipantID { get; set; }

        public Guid? QuestionID { get; set; }

        public SurveyAnswerType Type { get; set; }

        public string Text { get; set; }

        public string FullName { get; set; }

        public string SurveyName { get; set; }

        public string ChoiceTitle{ get; set; }
    }
}
