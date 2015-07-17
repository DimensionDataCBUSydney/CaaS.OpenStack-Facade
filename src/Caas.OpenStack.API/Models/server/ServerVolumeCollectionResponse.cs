using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server volume collection response. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	[DataContract]
	public class ServerVolumeCollectionResponse
	{
		/// <summary>	Gets or sets the volumes. </summary>
		/// <value>	The volumes. </value>
		[DataMember(Name = "volumes")]
		public List<ServerVolume> Volumes { get; set; }
	}
}