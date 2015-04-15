using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	A subnet detail response. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class SubnetDetailResponse
	{
		/// <summary>	Gets or sets the subnet. </summary>
		/// <value>	The subnet. </value>
		[DataMember(Name = "subnet")]
		public SubnetDetail Subnet { get; set; }
	}
}