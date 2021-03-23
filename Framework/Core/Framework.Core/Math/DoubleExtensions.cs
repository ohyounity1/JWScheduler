using SystemMath = System.Math;

namespace Framework.Core.Math
{
	/// <summary>
	/// Some core math extension helpers
	/// </summary>
	public static class DoubleExtensions
	{
		/// <summary>
		/// Compares two doubles to a given precision,
		/// Default is <see cref="double.Epsilon"/>
		/// </summary>
		/// <param name="doubleValue">Double on the left</param>
		/// <param name="compareTo">Double on the right</param>
		/// <param name="epsilon">How close to compare to</param>
		/// <returns></returns>
		public static bool IsClose(this double doubleValue, double compareTo, double epsilon = double.Epsilon)
		{
			// Allows left/right side to be less, greater than the other
			return SystemMath.Abs(doubleValue - compareTo) < epsilon;
		}
	}
}
