using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyAnswer : Model
    {
        public Guid? QuestionID { get; set; }

        public string FullName { get; set; }

        public string SurveyName { get; set; }

        public SurveyAnswerType Type { get; set; }

        public string ChoiceTitle { get; set; }

        public int Total { get; set; }

        public int Count{ get; set; }

        public int Percent { get; set; }


    }
}