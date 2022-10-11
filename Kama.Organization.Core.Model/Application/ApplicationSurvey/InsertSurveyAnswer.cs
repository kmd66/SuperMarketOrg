using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class InsertSurveyAnswer : Model
    {
        public List<ApplicationSurveyAnswer> SurveyAnswer { get; set; }
    }
}