﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiServerController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for performing the base Server API Actions:
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.api;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary> 
	///  Interface for performing the base Server API Actions: 
	/// </summary>
	///  <apiComments>
	/// 	GET/v2/​{tenant_id}​/servers -> "Get Servers" 
	/// 	POST/v2/​{tenant_id}​/servers -> "Create Server" 
	/// 	GET/v2/​{tenant_id}​/servers/detail -> "Get Server details"
	/// 	GET/v2/​{tenant_id}​/servers/​{server_id}​ -> Get Server details (id)"
	/// 	PUT/v2/​{tenant_id}​/servers/​{server_id}​ -> "Update Server"
	/// 	DELETE/v2/​{tenant_id}​/servers/​{server_id}​ -> Remove Server
	/// 	</apiComments>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public interface IOpenStackApiServerController
	{
		/// <summary>
		/// 	Gets the limits. 
		/// 			OpenStack equivalent GET/v2/​{tenant_id}​/limits
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The limits. 
		/// </returns>
		Task<LimitsResponse> GetLimits(string tenantId);

		/// <summary>
		/// 	Gets server list.
		/// 			OpenStack equivalent : GET/v2/​{tenant_id}​/servers -&gt; "Get Servers"  
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The server list. 
		/// </returns>
		Task<BaseServerResponse> GetServerList(string tenantId);

		/// <summary>
		/// Creates a server. OpenStack equivalent: POST/v2/​{tenant_id}​/servers -&gt; "Create
		/// 	Server". 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="request">
		/// 	The request. 
		/// </param>
		/// <returns>
		/// 	The new server. 
		/// </returns>
		Task<ServerProvisioningResponse> CreateServer(string tenantId, ServerProvisioningRequest request);

		/// <summary>
		/// 	Gets server detail list.
		/// 			OpenStack equivalent: GET/v2/​{tenant_id}​/servers/detail -&gt; "Get Server details" 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	The server detail list. 
		/// </returns>
		Task<ServerDetailList> GetServerDetailList(string tenantId);

		/// <summary>
		/// 	Gets server detail. 
		/// 			OpenStack equivalent: GET/v2/​{tenant_id}​/servers/​{server_id}​ -&gt; Get Server details (id)"
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	The server detail. 
		/// </returns>
		Task<ServerDetailResponse> GetServerDetail(string tenantId, string serverId);

		/// <summary>
		/// 	Updates the server. PUT/v2/​{tenant_id}​/servers/​{server_id}​. 
		/// </summary>
		/// <param name="tenantId">
		/// 			  	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 			  	Identifier for the server. 
		/// </param>
		/// <param name="updateServerRequest">
		/// 	The update server request. 
		/// </param>
		/// <returns>
		/// 	The new server; 
		/// </returns>
		Task<ServerDetailResponse> UpdateServer(string tenantId, string serverId, dynamic updateServerRequest);

		/// <summary>
		/// 	Deletes the server.
		/// 			DELETE/v2/​{tenant_id}​/servers/​{server_id}​ -&gt; Remove Server 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	A Task. 
		/// </returns>
		Task DeleteServer(string tenantId, string serverId);

		/// <summary>
		/// 	List extensions
		/// 			OpenStack equivalent- &gt; GET/v2/​{tenant_id}​/extensions. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <returns>
		/// 	A list of. 
		/// </returns>
		Task<ExtensionCollectionResponse> ListExtensions(string tenantId);
	}
}
