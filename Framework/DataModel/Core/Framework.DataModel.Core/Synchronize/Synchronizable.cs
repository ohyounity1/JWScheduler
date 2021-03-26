using System.Diagnostics;

namespace Framework.DataModel.Core.Synchronize
{
	/// <summary>
	/// Added to a class to track the original state of an object before changes were made
	/// Requires the object must also be:
	/// <see cref="ICopyable{T}"/>
	/// <see cref="IEquates{T}"/>
	/// <see cref="IClonable{T}"/>
	/// </summary>
	/// <typeparam name="T">Type of the object being saved</typeparam>
	public class Synchronizable<T> where T: class, ICopyable<T>, IEquates<T>, IClonable<T>, new()
	{
		// Current value of the object
		private T _currentState;
		// State of the object before changes
		private T _originalState;

		/// <summary>
		/// Initializes a new instance of <see cref="Synchronizable{T}"/>
		/// </summary>
		/// <param name="currentState">Seed the initial state</param>
		public Synchronizable(T currentState)
		{
			_currentState = currentState;
			// Past state is just the current state (must be ICloneable)
			_originalState = _currentState.Clone();
		}

		/// <summary>
		/// Does this object have any changes?
		/// </summary>
		public bool HasChanges
		{
			// Has changes if not equal anymore to original state
			get { return _originalState != null && _originalState.IsEqual(_currentState); }
		}

		/// <summary>
		/// Set the last known saved state to the current state
		/// </summary>
		public void Synchronize()
		{
			// Clone and save current state
			_originalState = _currentState.Clone();
		}

		/// <summary>
		/// Go back to a previous state
		/// </summary>
		public void RevertState()
		{
			Debug.Assert(_originalState != null, "Object not yet synchronized.");
			// Copy from the original back to the current state
			_currentState.Copy(_originalState);
			// Resets the saved state back to this state
			Synchronize();
		}
	}
}
