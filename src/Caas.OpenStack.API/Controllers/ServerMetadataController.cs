using System;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models.server;

namespace Caas.OpenStack.API.Controllers
{
    /// <summary>	A controller for handling server metadata. </summary>
    /// <remarks>	Anthony, 4/13/2015. </remarks>
    /// <seealso cref="T:System.Web.Http.ApiController"/>
    /// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController"/>
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
    public class ServerMetadataController : ApiController, IOpenStackApiServerMetadataController
    {
	    /// <summary> Gets server metadata. OpenStack API equivalent - >
	    /// 	GET/v2/​{tenant_id}​/servers/​{server_id}​/metadata. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <returns>	The server metadata. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.GetServerMetadata(string,string)"/>
	    [HttpGet]
		[Route("{tenantId}​/servers/​{serverId}​/metadata")]
	    public Task<ServerMetadataResponse> GetServerMetadata(string tenantId, string serverId)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Creates or update server metadata OpenStack API equivalent - >
	    /// 	PUT/v2/​{tenant_id}​/servers/​{server_id}​/metadata. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <returns>	The new or update server metadata. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.CreateOrUpdateServerMetadata(string,string)"/>
		[HttpPut]
		[Route("{tenantId}​/servers/​{serverId}​/metadata")]
	    public Task<ServerMetadataResponse> CreateOrUpdateServerMetadata(string tenantId, string serverId)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Updates the server metadata items OpenStack API equivalent - > POST
	    /// 	/v2/​{tenant_id}​/servers/​{server_id}​/metadata. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <returns>	A Task&lt;ServerMetadataResponse&gt; </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.UpdateServerMetadataItems(string,string)"/>
		[HttpPost]
		[Route("{tenantId}​/servers/​{serverId}​/metadata")]
	    public Task<ServerMetadataResponse> UpdateServerMetadataItems(string tenantId, string serverId)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Gets metadata item details OpenStack API equivalent - >
	    /// 	GET/v2/​{tenant_id}​/servers/​{server_id}​/metadata/{key}. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <param name="key">	   	The key. </param>
	    /// <returns>	The metadata item details. </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.GetMetadataItemDetails(string,string,string)"/>
		[HttpGet]
		[Route("{tenantId}​/servers/​{serverId}​/metadata/{key}")]
	    public Task<ServerMetadataResponse> GetMetadataItemDetails(string tenantId, string serverId, string key)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Updates the metadata item details OpenStack API equivalent
	    /// 	PUT/v2/​{tenant_id}​/servers/​{server_id}​/metadata/​{key}​. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <param name="key">	   	The key. </param>
	    /// <returns>	A Task&lt;ServerMetadataResponse&gt; </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.UpdateMetadataItemDetails(string,string,string)"/>
		[HttpPut]
		[Route("{tenantId}​/servers/​{serverId}​/metadata/{key}")]
	    public Task<ServerMetadataResponse> UpdateMetadataItemDetails(string tenantId, string serverId, string key)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary> Deletes the metadata item details OpenStack API equivalent
	    /// 	DELETE/v2/​{tenant_id}​/servers/​{server_id}​/metadata/​{key}​. </summary>
	    /// <remarks>	Anthony, 4/13/2015. </remarks>
	    /// <param name="tenantId">	Identifier for the tenant. </param>
	    /// <param name="serverId">	Identifier for the server. </param>
	    /// <param name="key">	   	The key. </param>
	    /// <returns>	A Task&lt;ServerMetadataResponse&gt; </returns>
	    /// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerMetadataController.DeleteMetadataItemDetails(string,string,string)"/>
		[HttpDelete]
		[Route("{tenantId}​/servers/​{serverId}​/metadata/{key}")]
	    public Task<ServerMetadataResponse> DeleteMetadataItemDetails(string tenantId, string serverId, string key)
	    {
		    throw new NotImplementedException();
	    }
    }
}