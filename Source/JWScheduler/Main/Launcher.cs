namespace JWScheduler.Main
{
    /// <summary>
    /// Helper class that sets an instance of <see cref="Bootstrapper"/> and <see cref="Shell"/> to allow
    /// kicking off their constructors through XAML
    /// </summary>
    internal class Launcher
    {
        /// <summary>
        /// Empty constructor (required by XAML)
        /// </summary>
        public Launcher()
        {

        }

        /// <summary>
        /// Set the <see cref="Bootstrapper"/> in XAML
        /// </summary>
        public Bootstrapper Bootstrapper { get; set; }

        /// <summary>
        /// Set the <see cref="Shell"/> in XAML
        /// </summary>
        public Shell Shell { get; set; }
    }
}
