namespace Framework.DataModel.Core.Synchronize
{
	/// <summary>
	/// Attach to a data model object that needs to have original state maintained
	/// Requires the object implementing this interface must also be:
	/// <see cref="ICopyable{T}"/>
	/// <see cref="IEquates{T}"/>
	/// <see cref="IClonable{T}"/>
	/// </summary>
	/// <typeparam name="T">Internal type of the object being maintained</typeparam>
	public interface ISynchronizable<T> where T : class, ICopyable<T>, IEquates<T>, IClonable<T>, new()
	{
		/// <summary>
		/// The synchronize record of the last known state of the object
		/// </summary>
		Synchronizable<T> SynchronizeInformation { get; }
	}
}
