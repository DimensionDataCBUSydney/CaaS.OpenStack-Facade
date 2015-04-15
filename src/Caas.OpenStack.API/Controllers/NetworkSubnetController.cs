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
	/// <summary>	A controller for handling network subnets. </summary>
	/// <remarks>	Anthony, 4/15/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	/// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController"/>
	[Authorize]
	[RoutePrefix(Constants.NetworkPrefix)]
	public class NetworkSubnetController : ApiController, IOpenStackApiNetworkSubnetsController
	{
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
		public NetworkSubnetController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>	Gets the subnets. Equivalent GET/v2.0/subnets. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <returns>	The subnets. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController.GetSubnets()"/>
		[HttpGet]
		[Route("subnets")]
		public async Task<SubnetCollectionResponse> GetSubnets()
		{
			// Get networks..
			IEnumerable<NetworkWithLocationsNetwork> caasNetworks = await _computeClient.GetNetworksTask();
			return new SubnetCollectionResponse
			{
				Subnets = NetworkTranslators.CaaSNetworksToSubnets(caasNetworks, _computeClient.Account.OrganizationId.ToString()).ToArray()
			};
		}

		/// <summary>	Creates a subnet. POST/v2.0/subnets. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="request">	The request. </param>
		/// <returns>	The new subnet. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController.CreateSubnet(SubnetCreateRequest)"/>
		[HttpPost]
		[Route("subnets")]
		public Task<SubnetDetailResponse> CreateSubnet(SubnetCreateRequest request)
		{
			throw new NotImplementedException();
		}

		/// <summary>	Gets a subnet. GET/v2.0/subnets/​{subnet_id} </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	The subnet. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController.GetSubnet(string)"/>
		[HttpGet]
		[Route("subnets/{subnetId}")]
		public async Task<SubnetDetailResponse> GetSubnet(string subnetId)
		{
			// Get networks..
			NetworkWithLocationsNetwork caasNetwork =
				(await _computeClient.GetNetworksTask()).FirstOrDefault(net => net.id == subnetId);

			if (caasNetwork == null)
				throw new NetworkNotFoundException();

			return new SubnetDetailResponse
			{
				Subnet = NetworkTranslators.CaaSNetworkToSubnet(caasNetwork, _computeClient.Account.OrganizationId.ToString())
			};
		}

		/// <summary>	Updates the subnet described by subnetId. PUT/v2.0/subnets/​{subnet_id}​. </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	A Task&lt;SubnetDetailResponse&gt; </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController.UpdateSubnet(string)"/>
		[HttpPut]
		[Route("subnets/{subnetId}")]
		public Task<SubnetDetailResponse> UpdateSubnet(string subnetId)
		{
			throw new NotImplementedException();
		}

		/// <summary> Deletes the subnet described by subnetId. DELETE/v2.0/subnets/​{subnet_id} </summary>
		/// <remarks>	Anthony, 4/15/2015. </remarks>
		/// <param name="subnetId">	Identifier for the subnet. </param>
		/// <returns>	A Task. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiNetworkSubnetsController.DeleteSubnet(string)"/>
		[HttpDelete]
		[Route("subnets/{subnetId}")]
		public Task DeleteSubnet(string subnetId)
		{
			throw new NotImplementedException();
		}
	}
}