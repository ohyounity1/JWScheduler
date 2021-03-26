namespace JWScheduler.Main
{
    /// <summary>
    /// Shell class allows constructing in XAML so the empty constructor kicks off the showing of the main window
    /// </summary>
    internal class Shell
    {
        /// <summary>
        /// Empty constructor invoked in XAML
        /// </summary>
        public Shell()
        {
            // Show the main window
            var mainWindow = CommonServiceLocator.ServiceLocator.Current.GetInstance<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
