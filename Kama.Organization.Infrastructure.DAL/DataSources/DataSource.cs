using Kama.Organization.Core;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Kama.Organization.Infrastructure.DAL
{
    internal abstract class DataSource
    {
        public DataSource(AppCore.IOC.IContainer container)
        {
            _container = container;
            _xmlProvider = new XmlProvider();
            //_logger = _container?.TryResolve<Core.IEventLogger>();
            _objSerializer = _container?.TryResolve<AppCore.IObjectSerializer>();
            _requestInfo = _container.TryResolve<Core.IRequestInfo>();
            _messageProvider = _container?.TryResolve<Core.IResultMessageProvider>();

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OrganizationConnectionString"].ConnectionString;
            _dbORG = new ORG(connectionString);
            _dbPBL = new PBL(connectionString);
            _dbAPP = new APP(connectionString);
        }

        protected readonly Core.IResultMessageProvider _messageProvider;
        protected readonly AppCore.IOC.IContainer _container;
        protected readonly AppCore.IObjectSerializer _objSerializer;
        protected readonly Core.IRequestInfo _requestInfo;
        //protected readonly Core.IEventLogger _logger;
        protected readonly ORG _dbORG;
        protected readonly PBL _dbPBL;
        protected readonly APP _dbAPP;
        protected readonly XmlProvider _xmlProvider;

    }
}