// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerProvisioningRequest.cs" company="">
//   
// </copyright>
// <summary>
//   A network reference.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A network reference. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Network
	{
		/// <summary>	Gets or sets the Unique Id of the network. </summary>
		/// <value>	The UUID. </value>
		[DataMember(Name = "uuid")]
		public string Uuid { get; set; }
	}

	/// <summary>	A server provisioning request server. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ServerProvisioningRequestServer
	{
		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	Gets or sets the image reference. </summary>
		/// <value>	The image reference. </value>
		[DataMember(Name = "imageRef")]
		public string ImageRef { get; set; }

		/// <summary>	Gets or sets the flavour reference. </summary>
		/// <value>	The flavour reference. </value>
		[DataMember(Name = "flavorRef")]
		public string FlavorRef { get; set; }

		/// <summary>	Gets or sets the number of maximums. </summary>
		/// <value>	The number of maximums. </value>
		[DataMember(Name = "max_count")]
		public int MaxCount { get; set; }

		/// <summary>	Gets or sets the number of minimums. </summary>
		/// <value>	The number of minimums. </value>
		[DataMember(Name = "min_count")]
		public int MinCount { get; set; }

		/// <summary>	Gets or sets the networks. </summary>
		/// <value>	The networks. </value>
		[DataMember(Name = "networks")]
		public Network[] Networks { get; set; }

		/// <summary>	Gets or sets the groups the security belongs to. </summary>
		/// <value>	The security groups. </value>
		[DataMember(Name = "security_groups")]
		public SecurityGroup[] SecurityGroups { get; set; }
	}

	/// <summary>	A server provisioning request. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public class ServerProvisioningRequest
	{
		/// <summary>	Gets or sets the server. </summary>
		/// <value>	The server. </value>
		[DataMember(Name = "server")]
		public ServerProvisioningRequestServer Server { get; set; }
	}
}