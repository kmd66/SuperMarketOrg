using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyGroupListVM : ListVM
    {
        public int Total { get; set; }

        public Guid? ApplicationSurveyID { get; set; }

        public string Name { get; set; }

        public bool ShowRemov { get; set; }
    }
}
