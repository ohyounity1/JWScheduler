namespace Framework.DataModel.Core.Synchronize
{
	public interface IClonable<T> where T: ICopyable<T>, new()
	{
		T Current { get; }

		T Clone()
		{
			var clone = new T();
			clone.Copy(Current);
			return clone;
		}
	}
}
