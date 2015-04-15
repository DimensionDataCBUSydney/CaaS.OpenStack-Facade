using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	A network detail response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class NetworkDetailResponse
	{
		/// <summary>	Gets or sets the network. </summary>
		/// <value>	The network. </value>
		[DataMember(Name = "network")]
		public Network Network { get; set; }
	}
}