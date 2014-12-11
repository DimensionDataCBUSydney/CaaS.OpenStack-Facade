using System.Runtime.Serialization;
using Caas.OpenStack.API.Models.serviceCatalog;

namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class AccessToken
	{
		[DataMember(Name = "token")]
		public Token Token { get; set; }

		[DataMember(Name = "serviceCatalog")]
		public ServiceCatalogEntry[] Catalog { get; set; }

		[DataMember(Name = "user")]
		public User User { get; set; }

		[DataContract]
		public class Metadata
		{
			[DataMember(Name = "is_admin")]
			public int IsAdmin { get; set; }

			[DataMember(Name = "roles")]
			public string[] Roles { get; set; }
		}
	}
}