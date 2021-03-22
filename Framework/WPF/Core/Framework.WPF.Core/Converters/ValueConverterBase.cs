namespace Framework.WPF.Core.Converters
{
	/// <summary>
	/// Helper class to be able to set true/false values in XAML when declaring your XAML converters
	/// </summary>
	/// <typeparam name="TValue">Underlying type of the converter destination</typeparam>
	public abstract class ValueConverterBase<TValue>
	{
		/// <summary>
		/// The value to return when an expression evaluates to true
		/// </summary>
		public TValue True { get; set; }
		/// <summary>
		/// The value to return when an expression evaluates to false
		/// </summary>
		public TValue False { get; set; }
	}
}
