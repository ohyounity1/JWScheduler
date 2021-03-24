namespace Framework.DataModel.Core.Synchronize
{
	public interface IEquates<T>
	{
		bool IsEqual(T other);
	}
}
