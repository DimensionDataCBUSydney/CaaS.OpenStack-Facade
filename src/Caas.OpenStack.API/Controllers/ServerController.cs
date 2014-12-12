using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Caas.OpenStack.API.Models;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
	using Models.server;
	using Caas.OpenStack.API.Models.image;
    using System.Net.Http;

	[Authorize]
	[RoutePrefix(Constants.CurrentApiVersion)]
	public class ServerController : ApiController
	{
		private IComputeApiClient _computeClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerController"/> class.
		/// </summary>
		/// <param name="apiClient">The API client.</param>
        public ServerController(Func<Uri, IComputeApiClient> apiClient)
        {
            _computeClient = apiClient(ConfigurationHelpers.GetApiUri());
        }

		/// <summary>
		/// Gets the server detail list for a given tenant
		/// TODO: implement tenant selection.
		/// </summary>
		/// <param name="tenant_id">The tenant_id.</param>
		/// <returns></returns>
		[Route("{tenant_id}/servers/detail")]
        [HttpGet]
		public async Task<ServerDetailList> GetServerDetailList([FromUri]string tenant_id)
		{
			ServerWithBackupType[] servers = (await _computeClient.GetDeployedServers()).ToArray();
			ServerDetailList serverList = new ServerDetailList();
			serverList.Servers = new ServerDetail[servers.Count()];

			for (int i = 0; i < servers.Count(); i++)
			{
				serverList.Servers[i] = CaaSServerToServerDetail(servers[i], tenant_id);
			}

			return serverList;
		}

		/// <summary>
		/// Gets the server URI.
		/// </summary>
		/// <param name="tenantId">The tenant identifier.</param>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		private static string GetServerUri(string tenantId, string id)
		{
			return String.Format(
				"{0}{1}/{2}/servers/{3}",
				ConfigurationHelpers.GetBaseUrl(),
				Constants.CurrentApiVersion,
				tenantId,
				id
				);
		}

		/// <summary>
		/// Gets the server detail.
		/// </summary>
		/// <param name="tenant_id">The tenant_id.</param>
		/// <param name="server_id">The server_id.</param>
		/// <returns></returns>
		[Route("{tenant_id}/servers/{server_id}")]
        [HttpGet]
		public async Task<ServerDetailResponse> GetServerDetail([FromUri]string tenant_id, [FromUri]string server_id)
		{
			ServerWithBackupType caasServer = (await _computeClient.GetDeployedServers()).First(server => server.id == server_id);
            return
                new ServerDetailResponse()
                {
                    Server = CaaSServerToServerDetail(caasServer, tenant_id)
                };
                
		}

		public ServerDetail CaaSServerToServerDetail(ServerWithBackupType server, string tenant_id)
		{
			return new ServerDetail()
			{
				AccessIPv4 = server.privateIp,
				AccessIPv6 = "", // IPv6 not supported at present
				CreatedDate = server.created.ToString("s"),
				HostId = server.name,
				Id = Guid.Parse(server.id),
				Image = new ServerImage()
				{
					Id = server.sourceImageId,
					Links = new RestLink[]
						{
							new RestLink(
								UrlGenerator.GetImageUri(tenant_id, server.sourceImageId), 
								RestLink.Bookmark
								)
						}
				},
				IpAddressCollection = new IPAddressCollection()
				{
					PrivateAddresses = new IPAddress[]
						{
							new IPAddress(server.privateIp)
						},
					PublicAddresses = new IPAddress[]
 						{
 							new IPAddress(server.publicIp)
 						}
				},
				Name = server.name,
				Links = new RestLink[]
					{
						new RestLink(ServerController.GetServerUri(tenant_id, server.id), RestLink.Self) 
					},
				Metadata = new KeyValuePair<string, string>(), // TODO: decide what metadata should be shown.
				Status = ServerStatus.Active // TODO : Map CaaS status.
			};
		}

		[Route("{tenant_id}/servers/{server_id}/action")]
		[HttpPost]
		public async Task<HttpResponseMessage> PerformServerAction([FromBody]ServerActionRequest request, [FromUri] string tenant_id, [FromUri] string server_id)
		{
			if (request.CreateImage != null)
			{
				// Get base image
                var servers = await _computeClient.GetDeployedServers();
                if (servers == null)
                    return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);

                var server = servers.First(s => s.id == server_id);
                if (server == null)
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
                response.Headers.Add("Location", UrlGenerator.GetImageUri(tenant_id, server.sourceImageId) );

                return response;
			}
            if (request.ChangePassword != null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
            }
		}
	}
}