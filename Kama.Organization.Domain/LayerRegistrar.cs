using Kama.AppCore.IOC;
using Kama.Organization.Core.Service;
using System;
using System.Linq;

[assembly: Registrar(typeof(Kama.Organization.Domain.LayerRegistrar),Order = 1)]

namespace Kama.Organization.Domain
{
    using asm = System.Reflection.Assembly;
    using svc = Core.Service;

    internal class LayerRegistrar : IRegistrar
    {
        private readonly Guid _layerId = Guid.NewGuid();

        public Guid ID => _layerId;

        public void Start(IContainer container)
        {
            asm svcAsm = asm.GetAssembly(typeof(svc.IService)),
                classAsm = asm.GetAssembly(this.GetType());

            container.RegisterFromAssembly(
                servicesAssembly: svcAsm,
                implementationsAssembly: classAsm,
                isService: t => t.IsInterface && !t.IsClass && typeof(svc.IService).IsAssignableFrom(t),
                isServiceImplementation: t => t.IsClass && !t.IsInterface && t.IsSubclassOf(typeof(Service))
                );

            container.RegisterInstance<Core.IResultMessageProvider>(new ResultMessageProvider(container));
            container.RegisterType<IAutomationTimerService, AutomationTimerService>();

            //start automation timer
            StartTimers(container);
        }

        private void StartTimers(IContainer container)
        {
            var automationTimer = container.Resolve<IAutomationTimerService>();
            automationTimer.Start();
        }
    }
}