using System;
using System.Collections.Generic;

namespace Framework.DataModel.Core.Audit
{
	/// <summary>
	/// Audit record, containing user who made the change and at what time they made the change
	/// </summary>
	public record Audit(string UserName, DateTime Time)
	{
	}

	/// <summary>
	/// A record containing audit traces for a particular data type
	/// </summary>
	public class Auditable
	{
		/// <summary>
		/// Initializes a new instance of <see cref="Auditable"/>
		/// </summary>
		/// <param name="created">The creation record</param>
		public Auditable(Audit created) => Created = created;

		/// <summary>
		/// Access to the creation record
		/// </summary>
		public Audit Created { get; }

		/// <summary>
		/// The last known update
		/// </summary>
		public Audit LastUpdate { get; private set; }

		/// <summary>
		/// All audits on this item
		/// </summary>
		public IList<Audit> AllAudits { get; }

		/// <summary>
		/// Update the audit for this item
		/// </summary>
		/// <param name="newAudit"></param>
		public void Update(Audit newAudit)
		{
			LastUpdate = newAudit;
			AllAudits.Add(newAudit);
		}
	}
}
