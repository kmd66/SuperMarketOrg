using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kama.Organization.Domain
{
    public static class UserNotificationHelper
    {
        public static string GetTemplateFilePath(string fileName, Core.IRequestInfo _requestInfo)
            => Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, $@"Files\MessageTemplates\{_requestInfo.ApplicationId}\{fileName}");

        public static string RenderTemplateWithModel<T>(string templateFilePath, T model, Core.IRequestInfo _requestInfo)
        {
            var template = File.ReadAllText(templateFilePath);

            foreach (var prop in model.GetType().GetProperties())
            {
                template = template.Replace($"[{prop.Name}]", prop.GetValue(model)?.ToString() ?? string.Empty);
            }

            if (_requestInfo.AppURL != null)
                template = template.Replace("[App-URL]", _requestInfo.AppURL);

            return template;
        }
    }
}
