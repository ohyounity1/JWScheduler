using Framework.Core.Language;
using System.ComponentModel;
using System.Windows;

namespace Framework.WPF.Core.ViewModel
{
	public abstract class ViewModelLocator<TViewModel>
	{
		protected bool IsDesignTime => DesignerProperties.GetIsInDesignMode(DependencyObjectSingle.Instance);

		protected TViewModel RuntimeViewModel { get; }

		protected TViewModel DesignTimeViewModel { get; }

		protected ViewModelLocator(TViewModel designTimeViewModel)
		{
			DesignTimeViewModel = designTimeViewModel;
			RuntimeViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<TViewModel>();
		}

		private class DependencyObjectSingle : Singleton<DependencyObject>
		{ 
		}
	}
}
