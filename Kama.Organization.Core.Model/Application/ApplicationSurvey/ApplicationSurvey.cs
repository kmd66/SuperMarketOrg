using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurvey : Model
    {
        public int Total { get; set; }

        public Guid ApplicationID { get; set; }

        public string Name { get; set; }

        public bool Enable { get; set; }
    }
}
