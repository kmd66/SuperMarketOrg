using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kama.Organization.Domain
{
    internal abstract class Service
    {
        public Service(AppCore.IOC.IContainer container)
        {
            _container = container;
        }

        protected readonly AppCore.IOC.IContainer _container;
    }

    internal abstract class Service<TDataSource> : Service
        where TDataSource : Core.DataSource.IDataSource
    {
        public Service(AppCore.IOC.IContainer container)
            : base(container)
        {
            try
            {
                _dataSource = _container.Resolve<TDataSource>();
                _requestInfo = _container.Resolve<Core.IRequestInfo>();
            }
            catch (Exception ex)
            {
            }
        }

        protected readonly TDataSource _dataSource;
        protected readonly Core.IRequestInfo _requestInfo;

    }
}