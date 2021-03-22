using System;
using System.Diagnostics;
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
			Break(value);
			return value;
		}

		/// <inheritdoc/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Break(value);
			return value;
		}

		[Conditional("DEBUG")]
		private void Break(object value)
		{
			System.Diagnostics.Debugger.Break();
		}
	}
}
