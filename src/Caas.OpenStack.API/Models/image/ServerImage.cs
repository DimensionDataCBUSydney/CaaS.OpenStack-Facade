using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class ServerImage
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }

		[DataMember(Name = "minDisk")]
		public int MinDisk { get; set; }

		[DataMember(Name = "minRam")]
		public int MinRam { get; set; }

		[DataMember(Name = "progress")] public int Progress = 100; // This has no related attribute.

		[DataMember(Name = "status")] public string Status = "ACTIVE"; // No related status

		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }
	}
}