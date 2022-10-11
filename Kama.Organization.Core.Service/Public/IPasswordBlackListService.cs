using Kama.AppCore;
using Kama.Organization.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IPasswordBlackListService : IService
    {
        Task<Result> ExecutePasswordBlackListAsync(PasswordBlackList model);

        //Works by timer
        Task<Result> UpdatePasswordBlackList();
    }
}
