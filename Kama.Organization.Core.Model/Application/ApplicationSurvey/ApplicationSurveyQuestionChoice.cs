using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Kama.Organization.Core.Model
{
    public class ApplicationSurveyQuestionChoice : Model
    {
        public Guid? RemoverPositionID { get; set; }

        public Guid QuestionID { get; set; }

        public string Name { get; set; }

        public DateTime? RemoveDate { get; set; }

        public bool Enable { get; set; }

        public int Total { get; set; }

    }
}