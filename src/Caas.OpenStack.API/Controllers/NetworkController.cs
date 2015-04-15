﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Exceptions;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.network;
using Caas.OpenStack.API.Translators;
using DD.CBU.Compute.Api.Client.Interfaces;
using DD.CBU.Compute.Api.Client.Network;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling networks. </summary>
    /// <remarks>	Anthony, 4/15/2015. </remarks>
    /// <seealso cref="T:System.Web.Mvc.Controller"/>
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class NetworkController : ApiController, IOpenStackApiNetworkController
    {
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
		public NetworkController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>	Creates a network. Equivalent -> POST/v2.0/networks. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="request">	The request. </param>
		/// <returns>	The new network. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.CreateNetwork(NetworkCreateRequest)"/>
		public Task<NetworkDetailResponse> CreateNetwork(NetworkCreateRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>	Get all networks Equivalent -> GET/v2.0/networks. </summary>
	    /// <remarks>	Anthony, 4/15/2015. </remarks>
	    /// <returns>	A NetworkCollectionResponse. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.GetNetworks()"/>
	    public async Task<NetworkCollectionResponse> GetNetworks()
	    {
		    var networks = await _computeClient.GetNetworksTask();
		    var openStackNetworks = NetworkTranslators.CaaSNetworkToNetwork(networks);

		    return new NetworkCollectionResponse
		    {
			    Networks = openStackNetworks.ToArray()
		    };
	    }

	    /// <summary>	Shows the network. Equivalent -> GET/v2.0/networks/{networkId} </summary>
	    /// <remarks>	Anthony, 4/15/2015. </remarks>
	    /// <param name="networkId">	Identifier for the network. </param>
	    /// <returns>	A NetworkDetailResponse. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.ShowNetwork(string)"/>
	    public async Task<NetworkDetailResponse> ShowNetwork(string networkId)
	    {
		    var network = (await _computeClient.GetNetworksTask()).FirstOrDefault(net => net.id == networkId);

		    if (network == null)
			    throw new NetworkNotFoundException();

		    return new NetworkDetailResponse
		    {
			    Network = NetworkTranslators.CaaSNetworkToNetwork(network)
		    };
	    }

	    /// <summary>	Updates the network. Equivalent -> PUT/v2.0/networks/{networkId} </summary>
	    /// <remarks>	Anthony, 4/15/2015. </remarks>
	    /// <param name="networkId">	Identifier for the network. </param>
	    /// <param name="request">  	The request. </param>
	    /// <returns>	A NetworkDetailResponse. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.UpdateNetwork(string,NetworkUpdateRequest)"/>
	    public Task<NetworkDetailResponse> UpdateNetwork(string networkId, NetworkUpdateRequest request)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Deletes the network described by networkId. Equivalent ->
	    /// 	DELETE/v2.0/networks/{networkId} </summary>
	    /// <remarks>	Anthony, 4/15/2015. </remarks>
	    /// <param name="networkId">	Identifier for the network. </param>
	    /// <returns>	A Task. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkController.DeleteNetwork(string)"/>
	    public Task DeleteNetwork(string networkId)
	    {
		    throw new NotImplementedException();
	    }
    }
}