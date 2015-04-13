using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A security group. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <summary>	A server provisioning response server. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerProvisioningResponseServer
	{
		/// <summary>	Gets or sets the groups the security belongs to. </summary>
		/// <value>	The security groups. </value>
		[DataMember(Name = "security_groups")]
		public SecurityGroup[] SecurityGroups { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the links. </summary>
		/// <value>	The links. </value>
		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		/// <summary>	Gets or sets the admin pass. </summary>
		/// <value>	The admin pass. </value>
		[DataMember(Name = "adminPass")]
		public string AdminPass { get; set; }
	}

	/// <summary>	A server provisioning response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerProvisioningResponse
	{
		/// <summary>	Gets or sets the server. </summary>
		/// <value>	The server. </value>
		[DataMember(Name = "server")]
		public ServerProvisioningResponseServer Server { get; set; }
	}
}