using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class ServerImage
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }
	}
}