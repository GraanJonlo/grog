using System.Reflection;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace Ui
{
    public class SimpleInjectorConfig
    {
        public static Container BuildContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            return container;
        }
    }
}
