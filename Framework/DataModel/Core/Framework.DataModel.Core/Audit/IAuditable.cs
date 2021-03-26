namespace Framework.DataModel.Core.Audit
{
	/// <summary>
	/// Attach this interface to a data model that needs to be audited
	/// </summary>
	public interface IAuditable
	{
		/// <summary>
		/// The audit tracking information
		/// </summary>
		Auditable AuditInformation { get; }
	}
}
