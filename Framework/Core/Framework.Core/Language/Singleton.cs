using System;

namespace Framework.Core.Language
{
	public abstract class Singleton<T>
	{
		private static readonly Lazy<T> _instance = new(() => Activator.CreateInstance<T>());

		public static T Instance => _instance.Value;
	}
}
