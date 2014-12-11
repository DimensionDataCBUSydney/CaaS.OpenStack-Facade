using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class Token
	{
		public Token(string tenantName, string tenantId, string token)
		{
			this.issuedAt = DateTime.Now;
			this.expires = issuedAt.AddMinutes(60);
			this.Id = token;
			this.Tenant = new Tenant(null, tenantName, tenantId);
		}

		[DataMember(Name = "issued_at")]
		public string IssuedAtDate { get { return issuedAt.ToString("s"); } }

		private DateTime issuedAt;

		[DataMember(Name = "expires")]
		public string ExpiresDate { get { return expires.ToString("s"); } }

		private DateTime expires;

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "tenant")]
		public Tenant Tenant { get; set; }
	}
}