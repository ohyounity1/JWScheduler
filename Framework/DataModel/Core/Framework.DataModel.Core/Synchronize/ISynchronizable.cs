namespace Framework.DataModel.Core.Synchronize
{
	public interface ISynchronizable<T> where T : class, ICopyable<T>, IEquates<T>, IClonable<T>, new()
	{
		Synchronizable<T> SynchronizeInformation { get; }
	}
}
