namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Helper converter operation for <see cref="OperationValueConverter{SourceType, DestType, OP}"/>
	/// </summary>
	/// <typeparam name="T">Type of value being evaluated</typeparam>
	public interface IConverterBinaryOperation<T>
	{
		/// <summary>
		/// Simple method to override to perform a given binary operation
		/// </summary>
		/// <param name="left">left side of binary operation</param>
		/// <param name="right">right side of binary operation</param>
		/// <returns>true if operation is true</returns>
		public bool Operation(T left, T right);
	}

	/// <summary>
	/// Implementation of <see cref="IConverterBinaryOperation{T}{T}"/> that implements the binary operation of ==
	/// </summary>
	/// <typeparam name="T">Type that is being compared</typeparam>
	public class EqualityConverterBinaryOpertion<T> : IConverterBinaryOperation<T>
	{
		/// <inheritdoc/>
		public bool Operation(T left, T right) => Equals(left, right);
	}
}
