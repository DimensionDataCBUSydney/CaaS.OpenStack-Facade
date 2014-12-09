using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class IPAddressCollection
	{
		[DataMember(Name="private")]
		public IPAddress[] PrivateAddresses { get; set; }

		[DataMember(Name = "public")]
		public IPAddress[] PublicAddresses { get; set; }
	}
}