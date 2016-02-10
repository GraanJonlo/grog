using System.Reflection;
using Akka.Actor;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace Ui
{
    public class SimpleInjectorConfig
    {
        public static void InitialiseContainer(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterTypes(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();
        }

        public static void InitialiseContainerForTest(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterTypes(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            // container.RegisterMvcIntegratedFilterProvider();

            container.Verify();
        }

        private static void RegisterTypes(Container container)
        {
            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            var actorSystem = ActorSystem.Create("grog");
            var domainModels = actorSystem.ActorOf(Props.Create(() => new DomainModels()), "hello");
            var systemActors = new SystemActors(domainModels);

            container.RegisterSingleton<ActorSystem>(actorSystem);
            container.RegisterSingleton<SystemActors>(systemActors);
        }
    }
}
