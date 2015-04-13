using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server action request. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerActionRequest
	{
		/// <summary>	Gets or sets the change password. </summary>
		/// <value>	The change password. </value>
		[DataMember(IsRequired = false, Name = "changePassword")]
		public ChangePasswordRequest ChangePassword { get; set; }

		/// <summary>	Gets or sets the reboot server. </summary>
		/// <value>	The reboot server. </value>
		[DataMember(IsRequired = false, Name = "reboot")]
		public RebootServerRequest RebootServer { get; set; }

		/// <summary>	Gets or sets the resize server. </summary>
		/// <value>	The resize server. </value>
		[DataMember(IsRequired = false, Name = "resize")]
		public ResizeServerRequest ResizeServer { get; set; }

		/// <summary>	Gets or sets the create image. </summary>
		/// <value>	The create image. </value>
		[DataMember(IsRequired = false, Name = "createImage")]
		public CreateImageRequest CreateImage { get; set; }

		/// <summary>	A change password request. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class ChangePasswordRequest
		{
			/// <summary>	Gets or sets the administrator password. </summary>
			/// <value>	The administrator password. </value>
			[DataMember(Name = "adminPass")]
			public string AdministratorPassword { get; set; }
		}

		/// <summary>	A reboot server request. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class RebootServerRequest
		{
			/// <summary>	Gets or sets the type. </summary>
			/// <value>	The type. </value>
			[DataMember(Name = "type")]
			public string Type { get; set; }
		}

		/// <summary>	A resize server request. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class ResizeServerRequest
		{
			/// <summary>	Gets or sets the flavor reference. </summary>
			/// <value>	The flavor reference. </value>
			[DataMember(Name = "flavorRef")]
			public int FlavorReference { get; set; }
		}

		/// <summary>	A create image request. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class CreateImageRequest
		{
			/// <summary>	Gets or sets the name. </summary>
			/// <value>	The name. </value>
			[DataMember(Name = "name")]
			public string Name { get; set; }

			/// <summary>	Gets or sets the metadata. </summary>
			/// <value>	The metadata. </value>
			[DataMember(Name = "metadata")]
			public KeyValuePair<string, string>[] Metadata { get; set; } 
		}
	}
}