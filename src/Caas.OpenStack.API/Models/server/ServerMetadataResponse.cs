using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server metadata response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerMetadataResponse
	{
		/// <summary>	Gets or sets the metadata. </summary>
		/// <value>	The metadata. </value>
		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }
	}
}