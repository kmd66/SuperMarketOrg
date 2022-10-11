using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xml = System.Xml;

namespace Kama.Organization.Domain
{

    class ResultMessageProvider : Core.IResultMessageProvider
    {
        public ResultMessageProvider(AppCore.IOC.IContainer container)
        {
            _container = container;
        }

        readonly AppCore.IOC.IContainer _container;

        public string Get(string key, int code)
        {
            var dictionary = _container.TryResolve<IDictionary<int, string>>(key);
            string message = string.Empty;
            dictionary?.TryGetValue(code, out message);
            return message;
        }

        public string Get(string error)
        {
            var splited = error.Split(':');
            var key = splited[0];
            int code = -1;
            int.TryParse(splited[1], out code);

            return Get(key, code);
        }

        public void Init(string filename)
        {
            var xmlDoc = new xml.XmlDocument();
            xmlDoc.Load(filename);

            var errorElements = xmlDoc.DocumentElement.ChildNodes
                                  .OfType<xml.XmlElement>();

            foreach (var errorElement in errorElements)
            {
                var errorSets = errorElement.ChildNodes.OfType<xml.XmlElement>()
                                            .Where(e => e.Name.Equals("Action", StringComparison.OrdinalIgnoreCase));

                foreach (var errorSet in errorSets)
                {
                    var key = $"{errorElement.Name}_{errorSet.Attributes["name"]?.Value}".ToLower();

                    var errors = errorSet.ChildNodes
                                         .OfType<xml.XmlElement>()
                                         .Where(e => e.Name.Equals("error", StringComparison.OrdinalIgnoreCase));

                    var dictionary = new Dictionary<int, string>();

                    foreach (var error in errors)
                    {
                        int code = 0;
                        int.TryParse(error.Attributes["code"]?.Value, out code);
                        dictionary.Add(code, error.InnerText);
                    }

                    _container.RegisterInstance<IDictionary<int, string>>(key, dictionary);

                }
            }

            //xmlDoc.InnerText = string.Empty;
            xmlDoc = null;
        }
    }
}
