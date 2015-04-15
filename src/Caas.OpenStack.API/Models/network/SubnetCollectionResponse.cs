using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	A subnet collection response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public class SubnetCollectionResponse
	{
		/// <summary>	Gets or sets the subnets. </summary>
		/// <value>	The subnets. </value>
		[DataMember(Name = "subnets")]
		public SubnetDetail[] Subnets { get; set; }
	}
}