using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.network
{
	/// <summary>	A network. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	[DataContract]
	public class Network
	{
		/// <summary>	Gets or sets the status. </summary>
		/// <value>	The status. </value>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		/// <summary>	Gets or sets the subnets. </summary>
		/// <value>	The subnets. </value>
		[DataMember(Name = "subnets")]
		public string[] Subnets { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	Gets or sets the provider physical network. </summary>
		/// <value>	The provider physical network. </value>
		[DataMember(Name = "provider:physical_network")]
		public object ProviderPhysicalNetwork 
		{
			get;
			set;
		}

		/// <summary>	Gets or sets a value indicating whether the admin state up. </summary>
		/// <value>	true if admin state up, false if not. </value>
		[DataMember(Name = "admin_state_up")]
		public bool AdminStateUp { get; set; }

		/// <summary>	Gets or sets the identifier of the tenant. </summary>
		/// <value>	The identifier of the tenant. </value>
		[DataMember(Name = "tenant_id")]
		public string TenantId { get; set; }

		/// <summary>	Gets or sets the type of the provider network. </summary>
		/// <value>	The type of the provider network. </value>
		[DataMember(Name = "provider:network_type")]
		public string ProviderNetworkType { get; set; }

		/// <summary>	Gets or sets a value indicating whether the router is external. </summary>
		/// <value>	true if router is external, false if not. </value>
		[DataMember(Name = "router:external")]
		public bool RouterExternal { get; set; }

		/// <summary>	Gets or sets a value indicating whether the shared. </summary>
		/// <value>	true if shared, false if not. </value>
		[DataMember(Name = "shared")]
		public bool Shared { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the identifier of the segmentation. </summary>
		/// <value>	The identifier of the segmentation. </value>
		[DataMember(Name = "provider:segmentation_id")]
		public object SegmentationId 
		{
			get;
			set;
		}
	}
}