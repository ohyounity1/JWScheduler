namespace Framework.DataModel.Core.Synchronize
{
	/// <summary>
	/// Implement interface to define how to copy an object
	/// </summary>
	/// <typeparam name="T">Underlying type to copy</typeparam>
	public interface ICopyable<T>
	{
		/// <summary>
		/// Copy from the source
		/// </summary>
		/// <param name="source">Source to copy from</param>
		void Copy(T source);
	}
}
