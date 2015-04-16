// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubnetDetail.cs" company="">
//   
// </copyright>
// <summary>
//   An allocation pool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	An allocation pool. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class AllocationPool
	{
		/// <summary>	Gets or sets the start. </summary>
		/// <value>	The start. </value>
		[DataMember(Name = "start")]
		public string Start { get; set; }

		/// <summary>	Gets or sets the end. </summary>
		/// <value>	The end. </value>
		[DataMember(Name = "end")]
		public string End { get; set; }
	}

	/// <summary>	A subnet detail. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class SubnetDetail
	{
		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	Gets or sets a value indicating whether the DHCP is enabled. </summary>
		/// <value>	true if enable DHCP, false if not. </value>
		[DataMember(Name = "enable_dhcp")]
		public bool EnableDhcp { get; set; }

		/// <summary>	Gets or sets the identifier of the network. </summary>
		/// <value>	The identifier of the network. </value>
		[DataMember(Name = "network_id")]
		public string NetworkId { get; set; }

		/// <summary>	Gets or sets the identifier of the tenant. </summary>
		/// <value>	The identifier of the tenant. </value>
		[DataMember(Name = "tenant_id")]
		public string TenantId { get; set; }

		/// <summary>	Gets or sets the DNS name servers. </summary>
		/// <value>	The DNS name servers. </value>
		[DataMember(Name = "dns_nameservers")]
		public List<object> DnsNameservers { get; set; }

		/// <summary>	Gets or sets the allocation pools. </summary>
		/// <value>	The allocation pools. </value>
		[DataMember(Name = "allocation_pools")]
		public List<AllocationPool> AllocationPools { get; set; }

		/// <summary>	Gets or sets the host routes. </summary>
		/// <value>	The host routes. </value>
		[DataMember(Name = "host_routes")]
		public List<object> HostRoutes { get; set; }

		/// <summary>	Gets or sets the IP version. </summary>
		/// <value>	The IP version. </value>
		[DataMember(Name = "ip_version")]
		public int IpVersion { get; set; }

		/// <summary>	Gets or sets the gateway IP. </summary>
		/// <value>	The gateway IP. </value>
		[DataMember(Name = "gateway_ip")]
		public string GatewayIp { get; set; }

		/// <summary>	Gets or sets the CIDR. </summary>
		/// <value>	The CIDR. </value>
		[DataMember(Name = "cidr")]
		public string Cidr { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }
	}
}