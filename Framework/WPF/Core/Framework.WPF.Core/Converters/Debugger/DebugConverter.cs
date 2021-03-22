using System;
using System.Globalization;
using System.Windows.Data;

namespace Framework.WPF.Core.Converters.Debugger
{
	/// <summary>
	/// Implementation of <see cref="IValueConverter"/> which can be helpful in debugging binding values
	/// </summary>
	public class DebugConverter : IValueConverter
	{
		/// <inheritdoc/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (System.Diagnostics.Debugger.IsAttached)
				System.Diagnostics.Debugger.Break();
			return value;
		}

		/// <inheritdoc/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (System.Diagnostics.Debugger.IsAttached)
				System.Diagnostics.Debugger.Break();
			return value;
		}
	}
}
