using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using SimpleInjector;

namespace Ui
{
    public sealed class SimpleInjectorModuleCatalog : INancyModuleCatalog
    {
        private readonly Container _container;

        public SimpleInjectorModuleCatalog(Container container)
        {
            _container = container;
        }

        public INancyModule GetModule(Type moduleType, NancyContext context)
        {
            return (INancyModule) _container.GetInstance(moduleType);
        }

        public IEnumerable<INancyModule> GetAllModules(NancyContext context)
        {
            return from r in _container.GetCurrentRegistrations()
                where typeof (INancyModule).IsAssignableFrom(r.ServiceType)
                select (INancyModule) r.GetInstance();
        }
    }
}
