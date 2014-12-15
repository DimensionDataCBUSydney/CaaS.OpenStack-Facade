using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class BaseServerResponse
	{
		[DataMember(Name = "servers")]
		public BaseServer[] Servers { get; set; }
	}
}