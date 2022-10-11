using Kama.AppCore;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.DataSource
{
    public interface IPasswordBlackListDataSource : IDataSource
    {
        Task<Result> ExecutePasswordBlackListAsync(PasswordBlackList model, AppCore.IActivityLog log);

        Task<Result<PasswordBlackList>> GetPasswordBlackListAsync(PasswordBlackListVm listVm);
    }
}
