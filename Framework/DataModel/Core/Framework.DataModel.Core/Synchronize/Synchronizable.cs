using System.Diagnostics;

namespace Framework.DataModel.Core.Synchronize
{
	public class Synchronizable<T> where T: class, ICopyable<T>, IEquates<T>, IClonable<T>, new()
	{
		private T _currentState;
		private T _originalState;

		public Synchronizable(T currentState)
		{
			_currentState = currentState;
			_originalState = _currentState.Clone();
		}

		public bool HasChanges
		{
			get { return _originalState != null && _originalState.IsEqual(_currentState); }
		}

		public void Synchronize()
		{
			_originalState = _currentState.Clone();
		}

		public void RevertState()
		{
			Debug.Assert(_originalState != null, "Object not yet synchronized.");
			_currentState.Copy(_originalState);
			Synchronize();
		}
	}
}
