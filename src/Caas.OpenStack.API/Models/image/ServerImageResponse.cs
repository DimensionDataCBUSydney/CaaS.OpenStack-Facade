using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class ServerImageResponse
	{
		[DataMember(Name = "image")]
		public ServerImage Image { get; set; }
	}
}