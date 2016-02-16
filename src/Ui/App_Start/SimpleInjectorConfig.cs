using System.Reflection;
using Akka.Actor;
using Core.Actors;
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

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();
        }

        public static void InitialiseContainerForTest(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterTypes(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Options.AllowOverridingRegistrations = true;

            container.Verify();
        }

        private static void RegisterTypes(Container container)
        {
            var actorSystem = ActorSystem.Create("grog");
            var domainModels = actorSystem.ActorOf(Props.Create(() => new DomainModels()), "hello");
            var systemActors = new SystemActors(domainModels);

            container.RegisterSingleton<ActorSystem>(actorSystem);
            container.RegisterSingleton<SystemActors>(systemActors);
        }
    }
}
