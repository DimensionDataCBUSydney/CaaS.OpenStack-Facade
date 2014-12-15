using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class ServerImageListResponse
	{
		[DataMember(Name = "images")]
		public ServerImage[] Images { get; set; }
	}
}