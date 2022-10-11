using Kama.Organization.Core.Service;
using System;
using System.Timers;
using Config = System.Configuration.ConfigurationManager;

namespace Kama.Organization.Domain
{
    class AutomationTimerService : IAutomationTimerService
    {
        #region Ctor and Props
        private Timer _timer;

        private readonly IPasswordBlackListService _passwordBlackListService;

        public AutomationTimerService(AppCore.IOC.IContainer container
                                , IPasswordBlackListService passwordBlackListService)
        {
            _timer = new Timer();
            _timer.Interval = GetTimerInterval();
            _timer.Elapsed += _timer_Elapsed;

            _passwordBlackListService = passwordBlackListService;
        }
        #endregion

        #region Timer Config
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Stop();
            DoWork();
            Start();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop() => _timer.Stop();

        private int GetTimerInterval()
        {
            try
            {
                var interval = Convert.ToInt32(Config.AppSettings["AutomationTimerInterval"]);
                if (interval != 0)
                    return Convert.ToInt32(Config.AppSettings["AutomationTimerInterval"]) * 60000;
                else
                    return 3600000;
            }
            catch (Exception)
            {
                return 3600000;
            }
        }
        #endregion

        private void DoWork()
        {
            var interval = Convert.ToInt32(Config.AppSettings["AutomationTimerInterval"]);
            if (interval == 0)
                return;

            _passwordBlackListService.UpdatePasswordBlackList();
        }
    }
}
