using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m = Kama.Organization.Core.Model;

namespace Kama.Organization.Infrastructure.DAL
{
    class QueueMessageDataSource : DataSource, Core.DataSource.IQueueMessageDataSource
    {
        public QueueMessageDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result> CreateAsync(AppCore.IActivityLog log)
        {
            try
            {
                return AppCore.Result.Successful();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
