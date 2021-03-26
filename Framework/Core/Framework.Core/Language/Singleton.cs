using System;

namespace Framework.Core.Language
{
	/// <summary>
	/// Singleton pattern implementation
	/// </summary>
	/// <typeparam name="T">Type of the object that is the singleton object</typeparam>
	public abstract class Singleton<T>
	{
		/// <summary>
		/// Implementation of the singleton is a <see cref="Lazy{T}"/>
		/// </summary>
		private static readonly Lazy<T> _instance = new(() => Activator.CreateInstance<T>());

		/// <summary>
		/// Gain access to the singleton instance
		/// </summary>
		public static T Instance => _instance.Value;
	}
}
