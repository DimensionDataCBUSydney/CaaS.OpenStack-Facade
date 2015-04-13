// <author>Anthony.Shaw@dimensiondata.com</author>
// <date>4/13/2015</date>
// <summary>API Actions for server management</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Exceptions;
using Caas.OpenStack.API.Interfaces;
using Caas.OpenStack.API.Models;
using Caas.OpenStack.API.Translators;
using Caas.OpenStack.API.UriFactories;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
	using Models.server;

	/// <summary>	A controller for handling servers. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:System.Web.Http.ApiController"/>
	/// <seealso cref="T:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController"/>
	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
	public class ServerController : ApiController, IOpenStackApiServerController
	{
		/// <summary>	The compute client. </summary>
		private readonly IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
        public ServerController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>	(An Action that handles HTTP GET requests) gets server list. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	The tenantId. </param>
		/// <returns>	The server list. </returns>
		[Route("{tenantId}/servers")]
		[HttpGet]
		public async Task<BaseServerResponse> GetServerList([FromUri] string tenantId)
		{
			ServerWithBackupType[] remoteServerCollection = (await _computeClient.GetDeployedServers()).ToArray();
			List<BaseServer> servers = new List<BaseServer>();

			for (int i = 0; i < servers.Count(); i++)
			{
				servers.Add(Request.CaaSServerToServer(remoteServerCollection[i], tenantId));
			}

			return new BaseServerResponse
			{
				Servers = servers.ToArray()
			};
		}

		/// <summary> Creates a server. OpenStack equivalent: POST/v2/​{tenantId}​/servers -> "Create
		/// 	Server". </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="request"> 	The request. </param>
		/// <returns>	The new server. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.CreateServer(string,ServerProvisioningRequest)"/>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.CreateServer(ServerProvisioningRequest)"/>
		[HttpPost]
		[Route("{tenantId}​/servers")]
		public async Task<ServerProvisioningResponse> CreateServer(string tenantId, [FromBody] ServerProvisioningRequest request)
		{
			// Get the image
			var imageResult = (await _computeClient.GetImages(String.Empty)).FirstOrDefault(image => image.id == request.Server.ImageRef);

			if (imageResult == null)
				throw new ImageNotFoundException();

			// Generate secret.
			byte[] buffer = new byte[9];
			using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
				rng.GetBytes(buffer);
			string adminPass = Convert.ToBase64String(buffer).Substring(0, 10).Replace('/', '0').Replace('+', '1');

			// Provision a server.
			Status status = await _computeClient.DeployServerImageTask(
				request.Server.Name,
				String.Empty,
				request.Server.Networks.First().Uuid, // NB: Support for multiple networks in MCP2.0
				request.Server.ImageRef,
				adminPass, 
				true);

			if (status.result == "SUCCESS")
			{
				var newServerId = status.additionalInformation.First(item => item.name == "serverId").value;
				return new ServerProvisioningResponse
				{
					Server = new ServerProvisioningResponseServer
					{
						Id = newServerId, // This is the server code.
						AdminPass = adminPass,
						Links = new[]
						{
							new RestLink(ServerUriFactory.GetServerUri(Request.RequestUri.Host, tenantId, newServerId), RestLink.Self)
						}
					}
				};
			}

			throw new ServerProvisioningRequestFailedException();
		}

		/// <summary> Gets the server detail list for a given tenant.</summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	The tenantId. </param>
		/// <returns>	The server detail list. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.GetServerDetailList(string)"/>
		[Route("{tenantId}/servers/detail")]
        [HttpGet]
		public async Task<ServerDetailList> GetServerDetailList([FromUri] string tenantId)
		{
			ServerWithBackupType[] servers = (await _computeClient.GetDeployedServers()).ToArray();
			ServerDetailList serverList = new ServerDetailList
			{
				Servers = new ServerDetail[servers.Count()]
			};

			for (int i = 0; i < servers.Count(); i++)
			{
				serverList.Servers[i] = Request.CaaSServerToServerDetail(servers[i], tenantId);
			}

			return serverList;
		}

		/// <summary>	Gets details about a particular server. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	The tenantId. </param>
		/// <param name="serverId">	The serverId. </param>
		/// <returns>	The server detail. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.GetServerDetail(string,string)"/>
		[Route("{tenantId}/servers/{serverId}")]
		[HttpGet]
		public async Task<ServerDetailResponse> GetServerDetail([FromUri]string tenantId, [FromUri]string serverId)
		{
			ServerWithBackupType caasServer = (await _computeClient.GetDeployedServers()).First(server => server.id == serverId);
			return
				new ServerDetailResponse
				{
					Server = Request.CaaSServerToServerDetail(caasServer, tenantId)
				};
		}

		/// <summary>	Updates the server. PUT/v2/​{tenant_id}​/servers/​{server_id}​. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">			  	Identifier for the tenant. </param>
		/// <param name="serverId">			  	Identifier for the server. </param>
		/// <param name="updateServerRequest">	The update server request. </param>
		/// <returns>	The new server; </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.UpdateServer(string,string,dynamic)"/>
		[Route("​{tenantId}​/servers/​{serverId}​")]
		[HttpPut]
		public Task<ServerDetailResponse> UpdateServer(string tenantId, string serverId, dynamic updateServerRequest)
		{
			// TODO : Process update fields.
			return GetServerDetail(tenantId, serverId);
		}

		/// <summary> Deletes the server. DELETE/v2/​{tenant_id}​/servers/​{server_id}​ -> Remove Server. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="tenantId">	Identifier for the tenant. </param>
		/// <param name="serverId">	Identifier for the server. </param>
		/// <returns>	A Task. </returns>
		/// <seealso cref="M:Caas.OpenStack.API.Interfaces.IOpenStackApiServerController.DeleteServer(string,string)"/>
		[Route("{tenantId}​/servers/​{serverId}")]
		[HttpDelete]
		public async Task DeleteServer(string tenantId, string serverId)
		{
			Status response = await _computeClient.ServerDelete(serverId);
		}
	}
}