using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyQuestion : Model
    {
        public int Total { get; set; }

        public string Name { get; set; }

        public ApplicationSurveyQuestionType Type { get; set; }

        public Guid GroupID { get; set; }

        public string GroupName { get; set; }

        public Guid ApplicationSurveyID { get; set; }

        public string ApplicationSurveyName { get; set; }

        public List<ApplicationSurveyQuestionChoice> Choice { get; set; }

        public List<ApplicationSurveyAnswer> Answers { get; set; }

        public SurveyAnswerType ChoiceSelected { get; set; }
    }
}
