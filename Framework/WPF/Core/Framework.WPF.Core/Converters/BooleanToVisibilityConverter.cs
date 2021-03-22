using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Implements <see cref="IValueConverter"/> by converting from a source of <see cref="bool"/> to
	/// destination of type <see cref="Visibility"/>
	/// </summary>
	public class BooleanToVisibilityConverter : ValueConverterBase<Visibility>, IValueConverter
	{
		/// <inheritdoc/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is bool boolValue)
			{
				return boolValue ? True : False;
			}
			return DependencyProperty.UnsetValue;
		}

		/// <inheritdoc/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is Visibility visibilityValue)
			{
				return (visibilityValue == True);
			}
			return DependencyProperty.UnsetValue;
		}
	}
}
