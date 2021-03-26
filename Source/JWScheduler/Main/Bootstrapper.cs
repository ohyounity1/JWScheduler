using Autofac;
using Autofac.Extras.CommonServiceLocator;
using System.Collections.Generic;
using System.Reflection;

namespace JWScheduler.Main
{
    /// <summary>
    /// Bootstrapper that kicks off the component registry into Autofac
    /// </summary>
    internal class Bootstrapper
    {
        public Bootstrapper()
        {
            
        }

        private IList<string> _assemblies = new List<string>();

        public IList<string> Assemblies 
        {
            get => _assemblies;
            set
            {
                _assemblies = value;

                // Create auto fac container
                var builder = new ContainerBuilder();

                var thisAssembly = GetType().Assembly;

                // Register all assemblies that have a module defined
                builder.RegisterAssemblyModules(thisAssembly);

                foreach (var assembly in GetAssemblyByName(_assemblies))
                {
                    builder.RegisterAssemblyModules(assembly);
                }

                // Build everything
                var container = builder.Build();
                // Needed for the view model locator pattern (otherwise, everything is done through pure DI)
                CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            }
        }

        private static IEnumerable<Assembly> GetAssemblyByName(IEnumerable<string> names)
        {
            foreach(var name in names)
                yield return Assembly.LoadFrom(name + ".dll");
        }
    }
}
