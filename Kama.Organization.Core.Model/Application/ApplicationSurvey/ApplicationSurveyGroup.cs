using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyGroup : Model
    {
        public int Total { get; set; }

        public Guid ApplicationSurveyID { get; set; }

        public Guid? RemoverPositionID { get; set; }

        public List<ApplicationSurveyQuestion> Questions { get; set; }

        public string Name { get; set; }
    }
}
