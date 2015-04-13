using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.server;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling server address. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
    /// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiServerAddressController"/>
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class ServerAddressController : ApiController, IOpenStackApiServerAddressController
    {
				/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
		public ServerAddressController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

	    /// <summary>	Gets server addresses GET/v2/​{tenant_id}​/servers/​{server_id}​/ips. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <returns>	The server addresses. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerAddressController.GetServerAddresses(string,string)"/>
	    public async Task<ServerAddressesResponse> GetServerAddresses(string tenantId, string serverId)
	    {
		    var server = (await _computeClient.GetDeployedServers()).First(serv => serv.id == serverId);
		    ServerAddressesResponse addressesResponse = new ServerAddressesResponse
		    {
			    Addresses = new IpAddressCollection
			    {
				    PrivateAddresses = new[]
				    {
					    new IpAddress(server.privateIp)
				    },
				    PublicAddresses = new[]
				    {
					    new IpAddress(server.publicIp)
				    }
			    }
		    };
			return addressesResponse;
	    }

	    /// <summary> Gets server addresses by network
	    /// 	GET/v2/​{tenant_id}​/servers/​{server_id}​/ips/​{network_label}​. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId"> 	Identifier for the tenant. </param>
	    /// <param name="serverId"> 	Identifier for the server. </param>
	    /// <param name="networkId">	Identifier for the network. </param>
	    /// <returns>	The server addresses by network. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerAddressController.GetServerAddressesByNetwork(string,string,string)"/>
	    public async Task<ServerAddressesResponse> GetServerAddressesByNetwork(string tenantId, string serverId, string networkId)
	    {
			// TODO : Map to network domains in MCP 2.0
			var server = (await _computeClient.GetDeployedServers()).First(serv => serv.id == serverId);
			ServerAddressesResponse addressesResponse = new ServerAddressesResponse
			{
				Addresses = new IpAddressCollection
				{
					PrivateAddresses = new[]
				    {
					    new IpAddress(server.privateIp)
				    },
					PublicAddresses = new[]
				    {
					    new IpAddress(server.publicIp)
				    }
				}
			};
			return addressesResponse;
	    }
    }
}