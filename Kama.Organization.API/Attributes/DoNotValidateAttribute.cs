using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kama.Organization.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class DoNotValidateAttribute : Attribute
    {
    }
}