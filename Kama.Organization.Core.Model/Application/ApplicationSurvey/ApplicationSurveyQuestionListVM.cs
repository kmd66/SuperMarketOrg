using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyQuestionListVM : ListVM
    {
        public Guid? GroupID { get; set; }

        public List<Guid> GroupIDs { get; set; }

        public string Name { get; set; }

        public ApplicationSurveyQuestionType Type { get; set; }
    }
}
