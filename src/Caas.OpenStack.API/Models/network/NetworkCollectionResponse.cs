using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	A network collection response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class NetworkCollectionResponse
	{
		/// <summary>	Gets or sets the networks. </summary>
		/// <value>	The networks. </value>
		[DataMember(Name = "networks")]
		public Network[] Networks { get; set; }
	}
}