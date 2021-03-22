using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Framework.Core.Collections
{
	/// <summary>
	/// Contains various extension methods for collections <see cref="IEnumerable{T}"/>
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Allows applying an <see cref="Action<typeparamref name="T"/> on a collection of item"/>
		/// </summary>
		/// <typeparam name="T">Generic type of the collection</typeparam>
		/// <param name="collection">Collection to operate upon</param>
		/// <param name="operation">Operation to perform on each item in the collection</param>
		/// <returns>Original collection, allowing chaining these calls</returns>
		public static IEnumerable<T> ForEach<T>(IEnumerable<T> collection, Action<T> operation)
		{
			Debug.Assert(operation is not null, $"{nameof(operation)} is null!");
			Debug.Assert(collection is not null, $"{nameof(collection)} is null!");

			if (collection is null)
				throw new ArgumentNullException(nameof(collection));
			if (operation is null) 
				throw new ArgumentNullException(nameof(operation));

			foreach (var item in collection)
				operation.Invoke(item);

			return collection;
		}

		/// <summary>
		/// Helper extension method for finding distinct items in a collection by a specific property in the collection item
		/// </summary>
		/// <typeparam name="T">Type of items in collection</typeparam>
		/// <typeparam name="Key">Type of property to bind to</typeparam>
		/// <param name="collection">The collection</param>
		/// <param name="selector">The selector helper, which selects the proper property to bind to</param>
		/// <returns>collection filtered by uniqueness according to given key</returns>
		public static IEnumerable<T> DistinctBy<T, Key>(IEnumerable<T> collection, Func<T, Key> selector)
		{
			// Store items in hash which doesn't allow duplicates
			var keys = new HashSet<Key>();

			foreach(var item in collection)
			{
				// If this item is already added, don't return it
				if (keys.Add(selector(item)))
					yield return item;
			}
		}
	}
}
