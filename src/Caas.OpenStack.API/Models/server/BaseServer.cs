using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class BaseServer
	{
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}