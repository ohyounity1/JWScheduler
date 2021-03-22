using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace Framework.WPF.Core.UserControls
{
	/// <summary>
	/// Interaction logic for FolderPathEditor.xaml
	/// </summary>
	public partial class FolderPathEditor : UserControl
	{
		public FolderPathEditor()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty FolderPathProperty = 
			Create(nameof(FolderPath), string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);

		public string FolderPath
		{
			get { return (string)GetValue(FolderPathProperty); }
			set { SetValue(FolderPathProperty, value); }
		}

		public static readonly DependencyProperty OpenFolderTitleProperty =
			Create(nameof(OpenFolderTitle), string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);

		public string OpenFolderTitle
		{
			get { return (string)GetValue(OpenFolderTitleProperty); }
			set { SetValue(OpenFolderTitleProperty, value); }
		}

		private void TextBox_PreviewMouseLeftButtonUp(object sender,
		  MouseButtonEventArgs e)
		{
			if (((TextBox)sender).SelectedText.Length == 0 &&
			  e.GetPosition(this).X <= ((TextBox)sender).ActualWidth -
			  SystemParameters.VerticalScrollBarWidth)
				ShowFolderPathEditWindow();
		}

		private void ShowFolderPathEditWindow()
		{
			string defaultFolderPath = string.IsNullOrEmpty(FolderPath) ?
			  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			  : FolderPath;
			string folderPath = ShowFolderBrowserDialog(defaultFolderPath);
			if (string.IsNullOrEmpty(folderPath)) return;
			FolderPath = folderPath;
		}

		private string ShowFolderBrowserDialog(string defaultFolderPath)
		{
			using (FolderBrowserDialog folderBrowserDialog =
			  new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = OpenFolderTitle;
				folderBrowserDialog.ShowNewFolderButton = true;
				folderBrowserDialog.SelectedPath = defaultFolderPath;
				folderBrowserDialog.ShowDialog();
				return folderBrowserDialog.SelectedPath;
			}
		}

		private static DependencyProperty Create<T>(string name, T initialValue, FrameworkPropertyMetadataOptions options) =>
			DependencyProperty.Register(name + "Property", typeof(T), typeof(FolderPathEditor), new FrameworkPropertyMetadata(initialValue, options));
	}
}
