using System.Windows;

namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Implementation of <see cref="OperationValueConverter{SourceType, DestType, OP}"/> that converts from a given enum of type <see cref="TEnum"/>
	/// with the provided equality operation, and if equal, returns the correct visibility
	/// This class needs to be concretely defined for each possible enum type
	/// </summary>
	/// <typeparam name="TEnum">The enum type to use</typeparam>
	public abstract class EnumToVisibilityConverter<TEnum> : OperationValueConverter<TEnum, Visibility, EqualityConverterBinaryOpertion<TEnum>>
	{
	}
}
