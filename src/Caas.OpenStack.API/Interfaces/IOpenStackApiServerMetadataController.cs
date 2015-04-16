// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenStackApiServerMetadataController.cs" company="">
//   
// </copyright>
// <summary>
//   Interface for open stack API server metadata controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Threading.Tasks;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Interfaces
{
	/// <summary>	Interface for open stack API server metadata controller. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public interface IOpenStackApiServerMetadataController
	{
		/// <summary>
		/// 	Gets server metadata.
		/// 			OpenStack API equivalent - &gt;  GET/v2/​{tenant_id}​/servers/​{server_id}​/metadata 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	The server metadata. 
		/// </returns>
		Task<ServerMetadataResponse> GetServerMetadata(string tenantId, string serverId);

		/// <summary>
		/// 	Creates or update server metadata
		/// 			OpenStack API equivalent - &gt; PUT/v2/​{tenant_id}​/servers/​{server_id}​/metadata. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	The new or update server metadata. 
		/// </returns>
		Task<ServerMetadataResponse> CreateOrUpdateServerMetadata(string tenantId, string serverId);

		/// <summary>
		/// 	Updates the server metadata items
		/// 			OpenStack API equivalent - &gt; POST /v2/​{tenant_id}​/servers/​{server_id}​/metadata. . 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <returns>
		/// 	A Task&lt;ServerMetadataResponse&gt; 
		/// </returns>
		Task<ServerMetadataResponse> UpdateServerMetadataItems(string tenantId, string serverId);

		/// <summary>
		/// 	Gets metadata item details
		/// 			OpenStack API equivalent - &gt; GET/v2/​{tenant_id}​/servers/​{server_id}​/metadata/{key}. . 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <param name="key">
		/// 	   	The key. 
		/// </param>
		/// <returns>
		/// 	The metadata item details. 
		/// </returns>
		Task<ServerMetadataResponse> GetMetadataItemDetails(string tenantId, string serverId, string key);

		/// <summary>
		/// 	Updates the metadata item details
		/// 			OpenStack API equivalent PUT/v2/​{tenant_id}​/servers/​{server_id}​/metadata/​{key}​. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <param name="key">
		/// 	   	The key. 
		/// </param>
		/// <returns>
		/// 	A Task&lt;ServerMetadataResponse&gt; 
		/// </returns>
		Task<ServerMetadataResponse> UpdateMetadataItemDetails(string tenantId, string serverId, string key);

		/// <summary>
		/// 	Deletes the metadata item details
		/// 			OpenStack API equivalent DELETE/v2/​{tenant_id}​/servers/​{server_id}​/metadata/​{key}​. 
		/// </summary>
		/// <param name="tenantId">
		/// 	Identifier for the tenant. 
		/// </param>
		/// <param name="serverId">
		/// 	Identifier for the server. 
		/// </param>
		/// <param name="key">
		/// 	   	The key. 
		/// </param>
		/// <returns>
		/// 	A Task&lt;ServerMetadataResponse&gt; 
		/// </returns>
		Task<ServerMetadataResponse> DeleteMetadataItemDetails(string tenantId, string serverId, string key);
	}
}
