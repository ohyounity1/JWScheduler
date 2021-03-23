using GalaSoft.MvvmLight;

namespace Framework.WPF.MVVMLight.Extensions
{
	/// <summary>
	/// Some extensions around the MVVM light library
	/// </summary>
	public static class ViewModeBaseExtensions
	{
		/// <summary>
		/// Adds an extension method to <see cref="ViewModelBase"/> for updating multiple properties at once
		/// </summary>
		/// <param name="viewModel">Original MVVM light bound view model</param>
		/// <param name="property1">First property to update</param>
		/// <param name="property2">Second property to update</param>
		public static void NotifyPropertyChanged(this ViewModelBase viewModel, string property1, string property2)
		{
			// Update property one
			viewModel.RaisePropertyChanged(property1);
			// Update property two
			viewModel.RaisePropertyChanged(property2);
		}
	}
}
