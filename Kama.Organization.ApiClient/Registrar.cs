using System;
using System.Linq;
using Kama.AppCore.IOC;

[assembly: Registrar(typeof(Kama.Organization.ApiClient.Registrar))]
namespace Kama.Organization.ApiClient
{
    using asm = System.Reflection.Assembly;

    class Registrar : IRegistrar
    {
        readonly Guid _id = Guid.NewGuid();
        public Guid ID => _id;

        public void Start(IContainer container)
        {
            var clientAssembly = asm.GetAssembly(this.GetType());

            container.RegisterFromAssembly(
                servicesAssembly: clientAssembly,
                implementationsAssembly: clientAssembly,
                isService: t => t.IsInterface && t != typeof(Interface.IService) && typeof(Interface.IService).IsAssignableFrom(t),
                isServiceImplementation: t => !t.IsInterface && t.IsClass && t.IsSubclassOf(typeof(Service))
                );

            var hostInfo = container.TryResolve<Interface.IOrganizationHostInfo>();
            var objectSerializer = container.TryResolve<AppCore.IObjectSerializer>();
            
            container.RegisterInstance<Interface.IOrganizationClient>(new OrganizationClient(objectSerializer, hostInfo.Host, hostInfo.GetDefaultHeaders));
        }
    }
}
