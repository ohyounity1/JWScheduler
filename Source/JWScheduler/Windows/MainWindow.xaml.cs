using JWScheduler.ViewModels;
using System.Windows;

namespace JWScheduler
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainViewModel _mainViewModel;

		/// <summary>
		/// Initializes a new instance of <see cref="MainWindow"/>
		/// </summary>
		/// <param name="viewModel">The only instance where the view model can be dependency injected, due to 
		///							window itself put into container.  Usually controls are created inline in XAML and thus
		///							cannot have their view models DI and use the service locator pattern</param>
		public MainWindow(MainViewModel viewModel)
		{
			_mainViewModel = viewModel;
			InitializeComponent();
		}
	}
}
