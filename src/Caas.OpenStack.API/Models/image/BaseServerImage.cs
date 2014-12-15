using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class BaseServerImage
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}