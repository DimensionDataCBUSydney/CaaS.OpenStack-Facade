using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Caas.OpenStack.API.Models.server
{
	[DataContract]
	public class ServerActionRequest
	{
		[DataMember(IsRequired = false, Name = "changePassword")]
		public ChangePasswordRequest ChangePassword { get; set; }

		[DataMember(IsRequired = false, Name = "reboot")]
		public RebootServerRequest RebootServer { get; set; }

		[DataMember(IsRequired = false, Name = "resize")]
		public ResizeServerRequest ResizeServer { get; set; }

		[DataMember(IsRequired = false, Name = "createImage")]
		public CreateImageRequest CreateImage { get; set; }

		[DataContract]
		public class ChangePasswordRequest
		{
			[DataMember(Name = "adminPass")]
			public string AdministratorPassword { get; set; }
		}

		[DataContract]
		public class RebootServerRequest
		{
			[DataMember(Name = "type")]
			public string Type { get; set; }
		}

		[DataContract]
		public class ResizeServerRequest
		{
			[DataMember(Name = "flavorRef")]
			public int FlavorReference { get; set; }
		}

		[DataContract]
		public class CreateImageRequest
		{
			[DataMember(Name = "name")]
			public string Name { get; set; }

			[DataMember(Name = "metadata")]
			public KeyValuePair<string, string>[] Metadata { get; set; } 
		}
	}
}