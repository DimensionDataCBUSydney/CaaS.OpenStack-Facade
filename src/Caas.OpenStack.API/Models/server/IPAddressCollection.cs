using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	Collection of IP address. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class IpAddressCollection
	{
		/// <summary>	Gets or sets the private addresses. </summary>
		/// <value>	The private addresses. </value>
		[DataMember(Name = "private")]
		public IpAddress[] PrivateAddresses { get; set; }

		/// <summary>	Gets or sets the public addresses. </summary>
		/// <value>	The public addresses. </value>
		[DataMember(Name = "public")]
		public IpAddress[] PublicAddresses { get; set; }
	}
}