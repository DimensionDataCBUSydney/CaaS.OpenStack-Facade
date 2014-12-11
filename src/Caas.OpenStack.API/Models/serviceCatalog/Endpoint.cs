using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.serviceCatalog
{
	[DataContract]
	public class Endpoint
	{
		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "region")]
		public string Region { get; set; }

		[DataMember(Name = "internalURL")]
		public string InternalURL { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "publicURL")]
		public string PublicURL { get; set; }
	}
}