// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerDetail.cs" company="">
//   
// </copyright>
// <summary>
//   A server detail.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Runtime.Serialization;
using Caas.OpenStack.API.Models.image;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server detail. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:Caas.OpenStack.API.Models.server.BaseServer"/>
	[DataContract]
	public class ServerDetail : BaseServer
	{
		/// <summary>	Gets or sets the access IPV4. </summary>
		/// <value>	The access IPV4. </value>
		[DataMember(Name = "accessIPv4")]
		public string AccessIPv4 { get; set; }

		/// <summary>	Gets or sets the access IPV6. </summary>
		/// <value>	The access IPV6. </value>
		[DataMember(Name = "accessIPv6")]
		public string AccessIPv6 { get; set; }

		/// <summary>	Gets or sets a collection of IP address. </summary>
		/// <value>	A Collection of IP address. </value>
		[DataMember(Name = "addresses")]
		public IpAddressCollection IpAddressCollection { get; set; }

		/// <summary>	Gets or sets the created date. </summary>
		/// <value>	The created date. </value>
		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		/// <summary>	Gets or sets the updated date. </summary>
		/// <value>	The updated date. </value>
		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }

		/// <summary>	Gets or sets the identifier of the host. </summary>
		/// <value>	The identifier of the host. </value>
		[DataMember(Name = "hostId")]
		public string HostId { get; set; }

		/// <summary>	Gets or sets the image. </summary>
		/// <value>	The image. </value>
		[DataMember(Name = "image")]
		public ServerImage Image { get; set; }

		/// <summary>	Gets or sets the metadata. </summary>
		/// <value>	The metadata. </value>
		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }

        /// <summary> Workaround for a bug in lib cloud that tries to lowercase a boolean! This field isn't in the API documentation. </summary>
		/// <seealso cref="http://github.com/apache/libcloud/commit/c3522251163208f975b478ce632ac09b8af411d6"/>
        [DataMember(Name = "config_drive")]
        public string ConfigDrive = "false";

        /// <summary>	Gets or sets the flavor. </summary>
        /// <value>	The flavor. </value>
        [DataMember(Name = "flavor")]
        public Flavor Flavor { get; set; }

		/// <summary>	Gets or sets the progress. </summary>
		/// <value>	The progress. </value>
		[DataMember(Name = "progress")]
		public int Progress { get; set; }

		/// <summary>	Gets or sets the server status string. </summary>
		/// <value>	The server status string. </value>
		[DataMember(Name = "status")]
		public string ServerStatusString
		{
			get
			{
				return Status.ToString().ToUpper();
			}

			set
			{
				ServerStatus status;
				if (Enum.TryParse(value, out status))
				{
					Status = status;
				}
			}
		}

		/// <summary>	Gets or sets the status. </summary>
		/// <value>	The status. </value>
		public ServerStatus Status { get; set; }

		/// <summary>	Gets or sets the identifier of the tenant. </summary>
		/// <value>	The identifier of the tenant. </value>
		[DataMember(Name = "tenant_id")]
		public string TenantId { get; set; }

		/// <summary>	Gets or sets the identifier of the user. </summary>
		/// <value>	The identifier of the user. </value>
		[DataMember(Name = "user_id")]
		public string UserId { get; set; }
	}
}