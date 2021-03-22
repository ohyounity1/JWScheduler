using System;
using System.Globalization;
using System.Windows.Data;

namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Composes two <see cref="IValueConverter"/>.  These can be chained together many times
	/// </summary>
	public class ComposedConverter : IValueConverter
	{
		/// <summary>
		/// The outer converter, which will manipulate the result of the inner converter.
		/// This converter will return the final result
		/// </summary>
		public IValueConverter Outer { get; set; }
		/// <summary>
		/// The inner converter, which will run on the input first.  This result will be manipulated by
		/// the outer converter.  The final result is returned from this item
		/// </summary>
		public IValueConverter Inner { get; set; }

		/// <inheritdoc/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var result = Inner.Convert(value, targetType, parameter, culture);
			return Outer.Convert(result, targetType, parameter, culture);
		}

		/// <inheritdoc/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var result = Inner.ConvertBack(value, targetType, parameter, culture);
			return Outer.ConvertBack(result, targetType, parameter, culture);
		}
	}
}
