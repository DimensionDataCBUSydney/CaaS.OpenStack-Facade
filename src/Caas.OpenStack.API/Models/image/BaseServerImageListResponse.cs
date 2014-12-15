using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class BaseServerImageListResponse
	{
		[DataMember(Name = "images")]
		public BaseServerImage[] Images { get; set; }
	}
}