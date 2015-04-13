using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	List of server details. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerDetailList
	{
		/// <summary>	Gets or sets the servers. </summary>
		/// <value>	The servers. </value>
		[DataMember(Name = "servers")]
		public ServerDetail[] Servers { get; set; }
	}
}