using System;
using System.Collections.Generic;
using Caas.OpenStack.API.Models.network;
using DD.CBU.Compute.Api.Contracts.Network;
using System.Linq;

namespace Caas.OpenStack.API.Translators
{
	/// <summary>	A network translators. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public static class NetworkTranslators
	{
		/// <summary>	Convert a CaaS network to an OpenStack network. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="network">	The network. </param>
		/// <returns>	A Network </returns>
		public static Network CaaSNetworkToNetwork(NetworkWithLocationsNetwork network)
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
				Subnets = new[] { network.privateNet },
				TenantId = String.Empty // TODO: Map tenant via variable
			};
		}

		/// <summary>	Caa s network to network. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="networks">	The network. </param>
		/// <returns>	A List&lt;Network&gt; </returns>
		public static IEnumerable<Network> CaaSNetworkToNetwork(IEnumerable<NetworkWithLocationsNetwork> networks)
		{
			return networks.Select(CaaSNetworkToNetwork).ToList();
		}
	}
}