using Autofac;
using Autofac.Extras.CommonServiceLocator;

namespace JWScheduler.Main
{
    /// <summary>
    /// Bootstrapper that kicks off the component registry into Autofac
    /// </summary>
    internal class Bootstrapper
    {
        public Bootstrapper()
        {
            // Create auto fac container
            var builder = new ContainerBuilder();

            var thisAssembly = GetType().Assembly;

            // Register all assemblies that have a module defined
            builder.RegisterAssemblyModules(thisAssembly);

            // Build everything
            var container = builder.Build();
            // Needed for the view model locator pattern (otherwise, everything is done through pure DI)
            CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}
