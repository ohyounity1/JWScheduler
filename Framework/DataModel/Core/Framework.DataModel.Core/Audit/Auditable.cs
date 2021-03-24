using System;
using System.Collections.Generic;

namespace Framework.DataModel.Core.Audit
{
	public record Audit(string UserName, DateTime Time)
	{
	}

	public class Auditable
	{
		public Auditable(Audit created) => Created = created;

		public Audit Created { get; }

		public Audit LastUpdate { get; private set; }

		public IList<Audit> AllAudits { get; }

		public void Update(Audit newAudit)
		{
			LastUpdate = newAudit;
			AllAudits.Add(newAudit);
		}
	}
}
