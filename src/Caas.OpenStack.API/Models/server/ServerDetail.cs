using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class ServerDetail : BaseServer
	{
		[DataMember(Name = "accessIPv4")]
		public string AccessIPv4 { get; set; }

		[DataMember(Name = "accessIPv6")]
		public string AccessIPv6 { get; set; }

		[DataMember(Name = "addresses")]
		public IPAddressCollection IpAddressCollection { get; set; }

		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }

		[DataMember(Name = "hostId")]
		public string HostId { get; set; }

		[DataMember(Name = "image")]
		public image.ServerImage Image { get; set; }

		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }

        // Workaround for a bug in libcloud that tries to lowercase a boolean! https://github.com/apache/libcloud/commit/c3522251163208f975b478ce632ac09b8af411d6
        // This field isn't in the API documentation.
        [DataMember(Name = "config_drive")]
        public string ConfigDrive = "false";

        [DataMember(Name = "flavor")]
        public Flavor Flavor { get; set; }

		[DataMember(Name = "progress")]
		public int Progress { get; set; }

		[DataMember(Name = "status")]
		public string ServerStatusString
		{
			get { return Status.ToString().ToUpper(); }
			set
			{
				ServerStatus status;
				if (Enum.TryParse(value, out status))
				{
					Status = status;
				}
			}
		}

		public ServerStatus Status { get; set; }

		[DataMember(Name = "tenant_id")]
		public string TenantId { get; set; }

		[DataMember(Name = "user_id")]
		public string UserId { get; set; }
	}
}