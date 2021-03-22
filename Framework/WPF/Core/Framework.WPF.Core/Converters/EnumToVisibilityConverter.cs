using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Framework.WPF.Core.Converters
{
	public interface IEqualsPolicy<T>
	{
		public bool IsEqual(T left, T right) => Equals(left, right);
	}

	public abstract class EnumToVisibilityConverter<TEnum, EP> : ValueConverterBase<Visibility>, IValueConverter where EP : IEqualsPolicy<TEnum>, new()
	{
		private readonly IEqualsPolicy<TEnum> _ep = new EP();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is TEnum sourceValue && parameter is TEnum parameterValue)
			{
				if (_ep.IsEqual(sourceValue, parameterValue))
					return True;
				return False;
			}
			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is Visibility visibilityValue)
			{
				if (visibilityValue == True)
					return parameter;
			}
			return DependencyProperty.UnsetValue;
		}
	}
}
