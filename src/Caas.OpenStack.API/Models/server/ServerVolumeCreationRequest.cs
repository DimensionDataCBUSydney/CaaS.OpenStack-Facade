using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server volume creation request. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	public class ServerVolumeCreationRequest
	{
		/// <summary>	Gets or sets the volume. </summary>
		/// <value>	The volume. </value>
		[DataMember(Name = "volume")]
		ServerVolume Volume { get; set; }
	}
}