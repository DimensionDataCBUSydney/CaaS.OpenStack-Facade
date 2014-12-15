using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	[DataContract]
	public class ServerImage : BaseServerImage
	{
		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }

		[DataMember(Name = "minDisk")]
		public int MinDisk { get; set; }

		[DataMember(Name = "minRam")]
		public int MinRam { get; set; }

		[DataMember(Name = "progress")] 
		public int Progress = 100; // This has no related attribute.

		[DataMember(Name = "status")] 
		public string Status = "ACTIVE"; // No related status

		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }
	}
}