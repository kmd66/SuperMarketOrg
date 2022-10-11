using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    
    public interface IAutomationTimerService : IService
    {
        /// <summary>
        /// این متد تایمر اتوماسیون را فعال می کند
        /// </summary>
        void Start();

        /// <summary>
        /// این متد تایمر اتوماسیون را غیر فعال می کند
        /// </summary>
        void Stop();
    }
}
