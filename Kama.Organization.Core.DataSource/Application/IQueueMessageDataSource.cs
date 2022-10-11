using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IQueueMessageDataSource : IDataSource
    {
        Task<AppCore.Result> CreateAsync(AppCore.IActivityLog log);
    }
}
