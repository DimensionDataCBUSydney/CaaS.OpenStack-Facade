using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class IPAddress
	{
		public IPAddress(string address)
		{
			Address = address;
			Version = 4;
		}

		[DataMember(Name = "addr")]
		public string Address { get; set; }

		[DataMember(Name = "version")]
		public int Version { get; set; }
	}
}