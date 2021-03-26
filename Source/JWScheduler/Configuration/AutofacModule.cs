using Autofac;
using JWScheduler.ViewModels;

namespace JWScheduler.Configuration
{
    /// <summary>
    /// Registry module for this assembly
    /// </summary>
    public class AutofacModule : Module
    {
        /// <inheritdoc/>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            RegisterViewModels(builder);
            RegisterViews(builder);
        }

        /// <summary>
        /// Register the views in this assembly
        /// </summary>
        /// <param name="builder"></param>
        private void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().SingleInstance();
        }

        /// <summary>
        /// Register the view models in this assembly
        /// </summary>
        /// <param name="builder"></param>
        private void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().SingleInstance();
        }
    }
}
