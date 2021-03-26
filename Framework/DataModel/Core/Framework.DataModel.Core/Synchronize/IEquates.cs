namespace Framework.DataModel.Core.Synchronize
{
	/// <summary>
	/// Implement interface to define what equals means on an object
	/// Note, this is defined as a deep equals, by data checking and not by reference!
	/// </summary>
	/// <typeparam name="T">Underlying type defining equal for</typeparam>
	public interface IEquates<T>
	{
		/// <summary>
		/// Is this instance the same as the passed in instance?
		/// </summary>
		/// <param name="other">Other object to test</param>
		/// <returns>true if equal, false otherwise</returns>
		bool IsEqual(T other);
	}
}
