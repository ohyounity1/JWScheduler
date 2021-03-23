using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Represents an abstract operation between the value and parameter values in an <see cref="IValueConverter"/>
	/// The operation is done between these two and the result is used to determine the true or false value
	/// </summary>
	/// <typeparam name="SourceType">Type of the source binding</typeparam>
	/// <typeparam name="DestType">Type of the destination binding</typeparam>
	/// <typeparam name="OP">Represents the operation class</typeparam>
	public abstract class OperationValueConverter<SourceType, DestType, OP> : ValueConverterBase<DestType>, IValueConverter where OP : IConverterBinaryOperation<SourceType>, new()
	{
		private readonly OP _op = new ();

		/// <inheritdoc/>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Only evaluate if the types are correct
			if(value is SourceType castValue && parameter is SourceType castParameter)
			{
				// If the operation is true, use the True value, else use the False value
				return _op.Operation(castValue, castParameter) ? True : False;
			}
			return DependencyProperty.UnsetValue;
		}

		/// <inheritdoc/>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// In this case, value should be the destination type
			if (value is DestType destValue)
			{
				// If this destination value was set to the true value, use parameter as the return.
				if (Equals(destValue, True))
					return parameter;
			}
			return DependencyProperty.UnsetValue;
		}
	}
}
