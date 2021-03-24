namespace Framework.DataModel.Core.Synchronize
{
	public interface ICopyable<T>
	{
		void Copy(T source);
	}
}
