using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kama.Organization.Domain
{
    public static class Extensions
    {
        /// <summary>
        /// Render string of row template with default convention '[MODELPROPERTYNAME]'
        /// </summary>
        /// <param name="template">Row Template</param>
        /// <param name="model">Object of Template Model</param>
        /// <returns>Rendered Template</returns>
        public static string RenderTemplateWithModel(this string template, object model)
        {
            foreach (var prop in model.GetType().GetProperties())
            {
                template = template.Replace($"[{prop.Name}]", prop.GetValue(model)?.ToString() ?? string.Empty);
            }

            return template;
        }

    }
}
