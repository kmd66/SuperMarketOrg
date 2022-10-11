
using System;
using System.Collections.Generic;

namespace Kama.Organization.ApiClient
{
    
    class OrganizationClient : Library.ApiClient.Client, Interface.IOrganizationClient
    {
        public OrganizationClient(AppCore.IObjectSerializer objectSerializer, string host)
            :base(objectSerializer, host)
        {
            _host = host;
        }

        public OrganizationClient(AppCore.IObjectSerializer objectSerializer, string host, Func<IDictionary<string, string>> defaultHeaders)
            :base(objectSerializer, host, defaultHeaders)
        {
            _host = host;
        }

        readonly string _host;

        public string Host => _host;
    }
}
