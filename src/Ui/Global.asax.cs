using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Akka.Actor;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Ui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Container _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            var container = new Container();
            _container = container;

            SimpleInjectorConfig.InitialiseContainer(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        protected void Application_End()
        {
            var actorSystem = _container.GetInstance<ActorSystem>();

            actorSystem.Terminate();

            //wait up to two seconds for a clean shutdown
            actorSystem.AwaitTermination(TimeSpan.FromSeconds(2));
        }
    }
}
