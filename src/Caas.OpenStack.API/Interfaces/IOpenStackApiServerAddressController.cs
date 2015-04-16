// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiServerAddressController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for open stack API server address controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API server address controller. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public interface IOpenStackApiServerAddressController
	{
		/// <summary>
		/// 	Gets server addresses
		/// 			GET/v2/​{tenant_id}​/servers/​{server_id}​/ips. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	The server addresses. 
		/// </returns>
		Task<ServerAddressesResponse> GetServerAddresses(string tenantId, string serverId);

		/// <summary>
		/// 	Gets server addresses by network
		/// 			GET/v2/​{tenant_id}​/servers/​{server_id}​/ips/​{network_label}​. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <param name="networkId">
		/// 	Identifier for the network. 
		/// </param>
		/// <returns>
		/// 	The server addresses by network. 
		/// </returns>
		Task<ServerAddressesResponse> GetServerAddressesByNetwork(string tenantId, string serverId, string networkId);
	}
}
