using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using DD.CBU.Compute.Api.Client.Interfaces;

namespace Caas.OpenStack.API.Controllers
{
	using Models.server;

	[Authorize]
	[RoutePrefix("v2")]
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
		public async Task<ServerDetailList> GetServerDetailList(string tenant_id)
		{
			ServerWithBackupType[] servers = (await _computeClient.GetDeployedServers()).ToArray();
			ServerDetailList serverList = new ServerDetailList();
			serverList.Servers = new ServerDetail[servers.Count()];

			for (int i = 0; i < servers.Count(); i++)
			{
				serverList.Servers[i] = new ServerDetail()
				{
					AccessIPv4 = servers[i].privateIp,
					Name = servers[i].name
				};
			}

			return serverList;
		}

		[Route("{tenant_id}/servers/detail/{server_id}")]
		public ServerDetail GetServerDetail(string tenant_id, string server_id)
		{
			return new ServerDetail();
		}
	}
}