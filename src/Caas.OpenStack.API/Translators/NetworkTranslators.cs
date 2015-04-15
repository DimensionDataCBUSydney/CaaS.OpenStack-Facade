using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Caas.OpenStack.API.Models.network;
using DD.CBU.Compute.Api.Contracts.Network;

namespace Caas.OpenStack.API.Translators
{
	/// <summary>	A network translators. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public static class NetworkTranslators
	{
		/// <summary>	Convert a CaaS network to an OpenStack network. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="network"> 	The network. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A Network. </returns>
		public static Network CaaSNetworkToNetwork(NetworkWithLocationsNetwork network, string tenantId)
		{
			return new Network
			{
				AdminStateUp = true,
				Id = network.id,
				Name = network.name,
				ProviderNetworkType = "local",
				ProviderPhysicalNetwork = null,
				RouterExternal = true,
				SegmentationId = null,
				Shared = true,
				Status = "ACTIVE",
				Subnets = new[] { network.id }, // Each network maps to a subnet with the same id.
				TenantId = tenantId 
			};
		}

		/// <summary>	Caa s network to network. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="networks">	The network. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A Network in OpenStack form. </returns>
		public static IEnumerable<Network> CaaSNetworksToNetworks(IEnumerable<NetworkWithLocationsNetwork> networks, string tenantId)
		{
			return networks.Select(net => CaaSNetworkToNetwork(net, tenantId)).ToList();
		}

		/// <summary>	CaaS network to subnet. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="network"> 	The network. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns>	A SubnetDetail. </returns>
		public static SubnetDetail CaaSNetworkToSubnet(NetworkWithLocationsNetwork network, string tenantId)
		{
			IPAddress networkAddress = IPAddress.Parse(network.privateNet);
			byte[] first3Segments = networkAddress.MapToIPv4().GetAddressBytes().Take(3).ToArray();
			byte[] firstAddress = first3Segments.Concat(new byte[] { 10 }).ToArray();
			byte[] lastAddress = first3Segments.Concat(new byte[] { 254 }).ToArray();
			byte[] gatewayAddress = first3Segments.Concat(new byte[] { 1 }).ToArray();

			return new SubnetDetail
			{
				AllocationPools = new List<AllocationPool> { new AllocationPool { Start = (new IPAddress(firstAddress)).ToString(), End = (new IPAddress(lastAddress)).ToString() } },
				Cidr = network.privateNet + "/24", // always /24 in MCP 1.0
				DnsNameservers = new List<object>(0),
				EnableDhcp = false,
				GatewayIp = (new IPAddress(gatewayAddress)).ToString(),
				HostRoutes = new List<object>(0),
				Id = network.id,
				IpVersion = 4,
				Name = network.name,
				NetworkId = network.id,
				TenantId = tenantId
			};
		}

		/// <summary>	Enumerates caa s networks to subnets in this collection. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="networks">	The network. </param>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <returns> An enumerator that allows foreach to be used to process caa s networks to subnets in
		/// 	this collection. </returns>
		public static IEnumerable<SubnetDetail> CaaSNetworksToSubnets(IEnumerable<NetworkWithLocationsNetwork> networks, string tenantId)
		{
			return networks.Select(net => CaaSNetworkToSubnet(net, tenantId)).ToList();
		}
	}
}