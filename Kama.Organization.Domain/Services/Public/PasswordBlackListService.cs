using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Config = System.Configuration.ConfigurationManager;
using Kama.AppCore;
using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Service;
using Kama.Organization.Core.Model;

namespace Kama.Organization.Domain
{
    class PasswordBlackListService : Service<IPasswordBlackListDataSource>, IPasswordBlackListService
    {
        public PasswordBlackListService(AppCore.IOC.IContainer container) : base(container)
        {
        }

        public Task<Result> ExecutePasswordBlackListAsync(PasswordBlackList model)
            => _dataSource.ExecutePasswordBlackListAsync(model, null);

        //Works by timer
        public async Task<Result> UpdatePasswordBlackList()
        {
            var model = new PasswordBlackList
            {
                RepeatCount = Convert.ToInt32(Config.AppSettings["PasswordRepeatCount"])
            };
            return await ExecutePasswordBlackListAsync(model);
        }
    }
}
