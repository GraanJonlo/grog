using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Ui
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer nancy, IPipelines pipelines)
        {
            // Create Simple Injector container
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            // Register application components here, e.g.:
            //container.Register(typeof (ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());

            // Register Nancy modules.
            foreach (var nancyModule in Modules) container.Register(nancyModule.ModuleType);

            // Cross-wire Nancy abstractions that application components require (if any). e.g.:
            //container.Register(nancy.Resolve<IModelValidator>);

            // Check the container.
            container.Verify();

            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof (INancyModuleCatalog), new SimpleInjectorModuleCatalog(container));
            nancy.Register(typeof (INancyContextFactory),
                new SimpleInjectorScopedContextFactory(container, nancy.Resolve<INancyContextFactory>()));
        }
    }
}
