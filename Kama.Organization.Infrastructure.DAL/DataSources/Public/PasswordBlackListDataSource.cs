using Kama.AppCore;
using Kama.Organization.Core.DataSource;
using Kama.Organization.Core.Model;
using System;
using System.Threading.Tasks;


namespace Kama.Organization.Infrastructure.DAL.DataSources
{

    class PasswordBlackListDataSource : DataSource, IPasswordBlackListDataSource
    {
        public PasswordBlackListDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result> ExecutePasswordBlackListAsync(PasswordBlackList model, AppCore.IActivityLog log)
        {
            try
            {
                var result = await _dbPBL.ExecPasswordBlackListAsync(
                    _repeatCount: model.RepeatCount,
                    _log: log?.Value
                    );

                return Result.Successful();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<PasswordBlackList>> GetPasswordBlackListAsync(PasswordBlackListVm listVm)
        {
            try
            {
                var result = (await _dbPBL.GetPasswordBlackListAsync(
                    _password: listVm.Password
                    )).ToActionResult<PasswordBlackList>();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
