using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyQuestionChoiceListVM : ListVM
    {
        public Guid? QuestionID { get; set; }

        public List<Guid> QuestionIDs { get; set; }

        public string Name { get; set; }

        public string QuestionName { get; set; }
    }
}