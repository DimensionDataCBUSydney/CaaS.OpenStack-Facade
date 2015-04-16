// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiNetworkController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for open stack API network controller.
//   POST/v2.0/networksCreate network
//   Creates a network.
//   detail
//   POST/v2.0/networksBulk create networks
//   Creates multiple networks in a single request.
//   detail
//   GET/v2.0/networks/​{network_id}​Show network
//   Shows information for a specified network.
//   detail
//   PUT/v2.0/networks/​{network_id}​Update network
//   Updates a specified network.
//   detail
//   DELETE/v2.0/networks/​{network_id}​Delete network
//   Deletes a specified network and its associated resources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.network;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API network controller.
	/// 			POST/v2.0/networksCreate network
	/// Creates a network.
	///
	///  detail
	/// POST/v2.0/networksBulk create networks
	/// Creates multiple networks in a single request.
	///
	///  detail
	/// GET/v2.0/networks/​{network_id}​Show network
	/// Shows information for a specified network.
	///
	///  detail
	/// PUT/v2.0/networks/​{network_id}​Update network
	/// Updates a specified network.
	///
	///  detail
	/// DELETE/v2.0/networks/​{network_id}​Delete network
	/// Deletes a specified network and its associated resources. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	public interface IOpenStackApiNetworkController
	{
		/// <summary>
		/// 	Creates a network.
		/// 			Equivalent -&gt; POST/v2.0/networks 
		/// </summary>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	The new network. 
		/// </returns>
		Task<NetworkDetailResponse> CreateNetwork(NetworkCreateRequest request);

		/// <summary>	Get all networks
		/// 			Equivalent -> GET/v2.0/networks. </summary>
		/// <returns>	A NetworkCollectionResponse. </returns>
		Task<NetworkCollectionResponse> GetNetworks();

		/// <summary>
		/// 	Shows the network.
		/// 			Equivalent -&gt; GET/v2.0/networks/{networkId} 
		/// </summary>
		/// <param name="networkId">
		/// 	Identifier for the network. 
		/// </param>
		/// <returns>
		/// 	A NetworkDetailResponse 
		/// </returns>
		Task<NetworkDetailResponse> ShowNetwork(string networkId);

		/// <summary>
		/// 	Updates the network. 
		/// 			Equivalent -&gt; PUT/v2.0/networks/{networkId}
		/// </summary>
		/// <param name="networkId">
		/// 	Identifier for the network. 
		/// </param>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	A NetworkDetailResponse 
		/// </returns>
		Task<NetworkDetailResponse> UpdateNetwork(string networkId, NetworkUpdateRequest request);

		/// <summary>
		/// 	Deletes the network described by networkId.
		/// 			Equivalent -&gt; DELETE/v2.0/networks/{networkId} 
		/// </summary>
		/// <param name="networkId">
		/// 	Identifier for the network. 
		/// </param>
		/// <returns>
		/// 	A Task. 
		/// </returns>
		Task DeleteNetwork(string networkId);
	}
}
