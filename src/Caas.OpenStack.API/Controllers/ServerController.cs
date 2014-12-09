using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

		public ServerController(Func<Uri, IComputeApiClient> apiClient)
		{
			_computeClient = apiClient(ConfigurationHelpers.GetApiUri());
		}

		[Route("{tenant_id}/servers/detail")]
		public ServerDetailList GetServerDetailList(string tenant_id)
		{
			_computeClient.GetDeployedServers();

			return new ServerDetailList();
		}

		[Route("{tenant_id}/servers/detail/{server_id}")]
		public ServerDetail GetServerDetail(string tenant_id, string server_id)
		{
			return new ServerDetail();
		}
	}
}