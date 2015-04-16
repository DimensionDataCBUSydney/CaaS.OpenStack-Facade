// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkController.cs" company="">
//   
// </copyright>
// <summary>
//   A controller for handling networks.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Exceptions;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.network;
using Caas.OpenStack.API.Translators;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.Network;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling networks. </summary>
    /// <remarks>	Anthony, 4/15/2015. </remarks>
    /// <seealso cref="T:System.Web.Mvc.Controller"/>
	[Authorize]
	[RoutePrefix(Constants.NetworkPrefix)]
    public class NetworkController : ApiController, IOpenStackApiNetworkController
    {
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initialises a new instance of the <see cref="NetworkController"/> class. 
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">
		/// The API client.
		/// </param>
		public NetworkController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>
		/// 	Creates a network. Equivalent -&gt; POST/v2.0/networks. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/15/2015. 
		/// </remarks>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	The new network. 
		/// </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.CreateNetwork(NetworkCreateRequest)"/>
		[HttpPost]
		[Route("networks")]
		public Task<NetworkDetailResponse> CreateNetwork(NetworkCreateRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>	Get all networks Equivalent -> GET/v2.0/networks. </summary>
	    /// <remarks>	Anthony, 4/15/2015. </remarks>
	    /// <returns>	A NetworkCollectionResponse. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.GetNetworks()"/>
	    [HttpGet]
		[Route("networks")]
	    public async Task<NetworkCollectionResponse> GetNetworks()
	    {
		    string account = _computeClient.Account.OrganizationId.ToString();
		    IEnumerable<NetworkWithLocationsNetwork> networks = await _computeClient.GetNetworksTask();
			IEnumerable<Network> openStackNetworks = NetworkTranslators.CaaSNetworksToNetworks(networks, account);

		    return new NetworkCollectionResponse
		    {
			    Networks = openStackNetworks.ToArray()
		    };
	    }

	    /// <summary>
	    /// 	Shows the network. Equivalent -&gt; GET/v2.0/networks/{networkId} 
	    /// </summary>
	    /// <remarks>
	    /// 	Anthony, 4/15/2015. 
	    /// </remarks>
	    /// <param name="networkId">
	    /// 	Identifier for the network. 
	    /// </param>
	    /// <returns>
	    /// 	A NetworkDetailResponse. 
	    /// </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.ShowNetwork(string)"/>
		[HttpGet]
		[Route("networks/{networkId}")]
	    public async Task<NetworkDetailResponse> ShowNetwork(string networkId)
	    {
		    NetworkWithLocationsNetwork network = (await _computeClient.GetNetworksTask()).FirstOrDefault(net => net.id == networkId);

		    if (network == null)
			    throw new NetworkNotFoundException();

		    return new NetworkDetailResponse
		    {
				Network = NetworkTranslators.CaaSNetworkToNetwork(network, _computeClient.Account.OrganizationId.ToString())
		    };
	    }

	    /// <summary>
	    /// 	Updates the network. Equivalent -&gt; PUT/v2.0/networks/{networkId} 
	    /// </summary>
	    /// <remarks>
	    /// 	Anthony, 4/15/2015. 
	    /// </remarks>
	    /// <param name="networkId">
	    /// 	Identifier for the network. 
	    /// </param>
	    /// <param name="request">
	    /// 	The request. 
	    /// </param>
	    /// <returns>
	    /// 	A NetworkDetailResponse. 
	    /// </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.UpdateNetwork(string,NetworkUpdateRequest)"/>
	    [HttpPut]
		[Route("networks/{networkId}")]
	    public Task<NetworkDetailResponse> UpdateNetwork(string networkId, NetworkUpdateRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Deletes the network described by networkId. Equivalent -&gt;
	    /// 	DELETE/v2.0/networks/{networkId} 
	    /// </summary>
	    /// <remarks>
	    /// 	Anthony, 4/15/2015. 
	    /// </remarks>
	    /// <param name="networkId">
	    /// 	Identifier for the network. 
	    /// </param>
	    /// <returns>
	    /// 	A Task. 
	    /// </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.DeleteNetwork(string)"/>
	    [HttpDelete]
		[Route("networks/{networkId}")]
	    public Task DeleteNetwork(string networkId)
	    {
		    throw new NotImplementedException();
	    }
    }
}