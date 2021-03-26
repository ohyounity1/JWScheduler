using System.Windows;

namespace JWScheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Invoked by the framework when application starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // This causes the Launcher constructor to fire, and all the items bound to it in the StaticResources
            // have their constructors launched, in the order listed
            Current.TryFindResource("Launcher");
        }
    }
}
