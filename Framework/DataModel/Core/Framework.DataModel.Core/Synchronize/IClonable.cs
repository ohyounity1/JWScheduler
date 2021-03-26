namespace Framework.DataModel.Core.Synchronize
{
	/// <summary>
	/// Implement to make the class able to clone, or, copy itself
	/// As a result, the underlying type must also be <see cref="ICopyable{T}"/>
	/// </summary>
	/// <typeparam name="T">Underlying type to copy</typeparam>
	public interface IClonable<T> where T: ICopyable<T>, new()
	{
		/// <summary>
		/// Current value
		/// </summary>
		T Current { get; }

		/// <summary>
		/// Clone self
		/// </summary>
		/// <returns>A brand new copy to clone</returns>
		T Clone()
		{
			var clone = new T();
			clone.Copy(Current);
			return clone;
		}
	}
}
