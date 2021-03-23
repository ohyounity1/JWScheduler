using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Functional
{
	/// <summary>
	/// Various delegate extension methods
	/// </summary>
	public static class DelegateExtensions
	{
		/// <summary>
		/// Curries a <see cref="Func{T1, T2, TResult}"/> to <see cref="Func{T2, TResult}"/> by storing the first given argument
		/// as a lambda capture.  Another lambda requiring the second parameter is returned which has this capture, and the operation
		/// is completed by calling this new lambda with the second argument.
		/// This is called partial function in functional programming languages
		/// </summary>
		/// <typeparam name="T1">Type of first argument</typeparam>
		/// <typeparam name="T2">Type of second argument</typeparam>
		/// <typeparam name="TR">Type of the return argument</typeparam>
		/// <param name="thisDelegate">The delegate to curry</param>
		/// <param name="arg1">The first argument to capture</param>
		/// <returns></returns>
		public static Func<T2, TR> Curry<T1, T2, TR>(this Func<T1, T2, TR> thisDelegate, T1 arg1)
			=> (t2) => thisDelegate(arg1, t2); 
	}
}
